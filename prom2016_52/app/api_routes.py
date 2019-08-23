# -*- coding: utf8 -*-
from flask import flash, request, jsonify, json, render_template, session, url_for, redirect, abort

from app import db
import os
from app import app
from app.checker_tools import can
from app.forms import RegistrationForm, LoginForm, ChangeUserInfoForm, UploadForm, ChangePasswordForm, MarkForm, \
    ReportForm, CommentForm
from app.json_tools import getEventShortInfo, getDictEvent
from app.login_tools import login_required, get_user_name, loggedin, get_user_id, get_base_data
from app.models import event_interface
from app.models.comment_interface import comment_event, get_comments_event
from app.models.event_interface import change_event_info, event_exists
from app.models.models_bd import Event
from app.models.user_interface import get_rules_by_id, use_token, get_user_tokens_num, get_login_by_id
from werkzeug.utils import secure_filename
from PIL import Image

WrongEventErrorMessage = "There is no such event"


@app.route('/api/search_event', methods=['POST'])
def filter_events():
    data = request.json['jsonData']
    new_data = event_interface.new_search(data)
    new_data = list(map(getEventShortInfo, new_data))
    a = jsonify({'events': [json.dumps(item) for item in new_data]})
    return a


@app.route('/api/add_event', methods=['POST', 'GET'])
@login_required
def add_event():
    """! обрабатывает добавление метки.

    @return Okey,если метка успшено добавлена, "Enter more Data", если не хватает данных

    """
    if request.method == 'POST':
        data = request.json['jsonData']
        form = MarkForm.from_json(data)
        data['longitude'] = str(round(float(data['longitude']), 3))
        data['latitude'] = str(round(float(data['latitude']), 3))
        _longitude = data['longitude']
        _latitude = data['latitude']
        events = Event.query.filter_by(longitude=_longitude).filter_by(latitude=_latitude).all()
        print(events)
        if form.validate_on_submit():
            userid = get_user_id()
            rules = get_rules_by_id(userid)
            if len(events) > 0:
                return jsonify(code=1, result='Событие уже существует! ')
            if rules == 'gold':
                event_interface.add_mark(data, session['username'])
                return jsonify(code=0, result='Событие добавлено! ')
            if use_token(userid):
                event_interface.add_mark(data, session['username'])
                tn = get_user_tokens_num(userid)
                new_str = 'Осталось токенов: ' + str(tn)
                return jsonify(code=0, result='Событие добавлено!')
            return jsonify(code=1, result="Ошибка. У вас недостаточно токенов.")
        else:
            return jsonify(code=1, result='Заполните все поля')

    else:
        form = MarkForm()
        context = dict(form=form)
        context['adress'] = request.args.get('adress')
        context['city'] = request.args.get('city')
        return render_template('add_mark_form.html', **context)


@app.route('/api/event/')
@app.route('/api/event/<id>', methods=['GET'])
def event(id=None):
    data = event_interface.get_mark_by_id(id)
    if data is None:
        abort(404)
    else:
        response = getDictEvent(data)
    response['fileurl'] = '/static/' + get_place_image_filename(id)
    return render_template('event_small_info.html', **response)


def get_place_image_filename(id):
    image_siteurl = "uploads/place_" + str(id) + ".jpg"
    if os.path.isfile('{}/uploads/place_{}.jpg'.format(app.static_folder, str(id))):
        filename = image_siteurl
    else:
        filename = "default_place.png"
    return filename


@app.route('/api/event/<id>/change_image/', methods=['POST'])
@can(current_rules='mod')
def change_image(id=None):
    """!
    @brief View страницы изменения аватара
    Висит на /user/<username>/change_avatar
    @return редирект на /user/<username>
    """
    form = UploadForm()
    st = app.static_folder
    if form.validate_on_submit():
        filename = secure_filename(form.file.data.filename)
        extension = filename[filename.find('.'):]
        filepath = '{}/uploads/place_{}{}'.format(st, str(id), extension)
        try:
            form.file.data.save(filepath)
        except IOError:
            os.makedirs(st + '/uploads/')
            form.file.data.save(filepath)
        Image.open(filepath).convert('RGB').save(filepath)
        i = Image.open(filepath)
        i.save(filepath[:filepath.find('.')] + '.jpg', "JPEG")
        if not '.jpg' in filepath:
            try:
                os.remove(filepath)
            except Exception:
                pass
    else:
        flash(u'Необходимо выбрать корректное изображение.')

    return redirect(url_for('ref_event', id=id))


@app.route('/api/event/<id>/edit', methods=['POST', 'GET'])
@login_required
@can(current_rules='mod')
def event_edit(id=None):
    form = MarkForm()
    form2 = UploadForm()
    data = event_interface.get_mark_by_id(id)
    if data is None:
        abort(404)
    context = get_base_data()
    context.update(getDictEvent(data))
    context['form'] = form
    context['form2'] = form2
    context['title'] = 'EditEvent'
    if request.method == 'POST':
        if form.validate_on_submit():
            new_name = form.name._value()
            new_city = form.city._value()
            new_text = form.desc._value()
            id = str(id)
            change_event_info(id, new_name, new_city, new_text)
            return redirect(url_for('index'))
        else:
            return render_template('eventEdit.html', **context)
    else:
        return render_template('eventEdit.html', **context)


@app.route('/event/<id>/', methods=['GET', 'POST'])
@app.route('/event/<id>', methods=['GET', 'POST'])
def ref_event(id=None):
    if request.method == 'GET':
        data = event_interface.get_mark_by_id(id)
        if data is None:
            abort(404)
        else:
            form = CommentForm()
            response = getDictEvent(data)
            comments_raw = get_comments_event(id)
            comments = []
            for i in comments_raw:
                comments.append([get_login_by_id(i.author), i.text])
            response['comments_before'] = comments
            response['form'] = form
            response['loggedin'] = loggedin()
            response['user'] = get_user_name()
            response['fileurl'] = '/static/' + get_place_image_filename(id)
        return render_template('event.html', **response)
    elif request.method == 'POST':
        if loggedin():
            data = request.json['jsonData']
            if '<' in json.dumps(data) or '&' in json.dumps(data):
                return jsonify(code=1, status='Комментарий имеет недопустимый формат')
            if not len(data['text']):
                return jsonify(code=2)
            if event_exists(data['id']):
                if comment_event(data['id'], data['text']):
                    return jsonify(code=0)
                else:
                    return jsonify(code=1, status='Вы уже написали похожий комментарий.')
            else:
                return jsonify(code=1, status='Упс! Событие не существует!')
        else:
            return jsonify(code=1, status='Войдите или зарегистрируйтесь')


@app.route('/api/event/visit_event', methods=['POST'])
def visit():
    if request.method == 'POST':
        data = request.json['jsonData']
        _id = data['id']
        if Event.query.filter_by(id=_id).first().visit is None:
            tn = 1
        else:
            tn = Event.query.filter_by(id=_id).first().visit + 1
        event = Event.query.filter_by(id=_id).update(dict(visit=tn))
        db.session.commit()
    return jsonify(code=0, status="OK")

