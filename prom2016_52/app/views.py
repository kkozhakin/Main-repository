# -*- coding: utf8 -*-

##
# @file views.py
# @brief view-функции видимой части приложения

import os
import time
from hashlib import sha1

import flask_profiler
from PIL import Image
from flask import flash, send_from_directory, abort
from flask import redirect
from flask import render_template
from flask import request
from flask import session
from flask import url_for
from flask_wtf.csrf import CSRFError
from werkzeug.utils import secure_filename

from app import app, csrf
from app.checker_tools import can
from app.forms import RegistrationForm, LoginForm, ChangeUserInfoForm, \
    UploadForm, ChangePasswordForm, QuestForm, ChangeQuestInfoForm
from app.login_tools import get_user_name, get_user_id, get_base_data
from app.login_tools import login_not_required
from app.login_tools import login_required
from app.login_tools import login_user
from app.models import user_interface, event_interface, quest_interface
from app.models.models_bd import User, Event, Quest
from app.models.user_interface import change_user_info, get_user_email, \
    get_user_tokens_num, check_login, change_password, get_user_name1, \
    get_user_surname

SALT = app.config['SALT']
WrongAuthErrorMessage = "Wrong login or password"


@app.route('/index')
@app.route('/')
@flask_profiler.profile()
def index():
    """!
    @brief View главной страницы
    Висит на / и /index
    @return responce с готовой главной страницей
    """
    context = get_base_data()
    return render_template('index.html', **context)


@app.route('/places')
@flask_profiler.profile()
def places():
    """!
    @brief View карты
    Висит на /places
    @return responce с готовой cтраницей карты
    """
    context = get_base_data()
    return render_template('places.html', **context)


@app.route('/register', methods=['POST', 'GET'])
@login_not_required
@flask_profiler.profile()
def register():
    """!
    @brief View страницы регистрации
    Висит на /register
    @return responce с готовой страницей регистрации
    """
    form = RegistrationForm()
    context = dict(title='Register', form=form)
    if form.validate_on_submit():
        username = form.username._value()
        password = form.password._value()
        email = form.email._value()
        name = form.name._value()
        surname = form.surname._value()
        password = sha1(password + SALT).hexdigest()
        flag = user_interface.register(email, username, password, name, surname)
        if not flag:
            flash(flag)
            return redirect(url_for('register'))
        else:
            return login_user(username)
    else:
        for error in form.errors:
            flash(error)
        return render_template('register.html', **context)


@app.route('/login', methods=['POST', 'GET'])
@login_not_required
@flask_profiler.profile()
def login():
    """!
    @brief View страницы входа на сайт
    Висит на /login
    @return responce с готовой страницей
    """
    form = LoginForm()
    context = dict(title='Sign In', form=form)
    if form.validate_on_submit():
        username = form.login._value()
        password = form.password._value()
        password = sha1(password + SALT).hexdigest()
        flag = user_interface.login(username, password)
        if not flag:
            flash(WrongAuthErrorMessage)
            return redirect(url_for('login'))
        else:
            return login_user(username)
    else:
        if request.method == 'POST':
            flash('Please, type login and password')
        return render_template('login.html', **context)


@app.route('/logout')
@login_required
def logout():
    """!
    @brief View страницы деавторизации
    Висит на /logout
    @return перенаправление на главную страницу
    """
    session.pop('username', None)
    flash('You were logged out')
    return redirect(url_for('index'))


@app.route('/robots.txt')
def static_from_root():
    """!
    @brief отдаёт robots.txt
    @return файл robots.txt по запросу
    """
    return send_from_directory(app.static_folder, request.path[1:])


@app.route('/help')
def helppage():
    """!
    @brief View страницы помощи
    Висит на /help
    @return responce с готовой страницей
    """
    context = get_base_data()
    return render_template('help.html', **context)


@app.route('/user/')
@app.route('/user/<username>', methods=['POST', 'GET'])
@login_required
def userpage(username=None):
    """!
    @brief View страницы пользователя
    Висит на /user и /user/<username>
    @return responce с готовой страницей
    """
    context = get_base_data()

    if username is None:
        username = get_user_name()
    if not user_interface.check_login(username):
        abort(404)

    context['username'] = username
    context['name'] = get_user_name1(username)
    context['surname'] = get_user_surname(username)
    context['form'] = UploadForm()
    context['events'] = event_interface.get_user_marks(username)
    context['fileurl'] = '/static/' + get_user_avatar_filename(username)

    uid = get_user_id()
    context.update(
        dict(email=get_user_email(username), tokens=get_user_tokens_num(uid),
             time=str(time.time())))

    return render_template('users.html', **context)


def get_user_avatar_filename(username):
    """!
    @brief Функция получения filename'а пользователя.
    @param username имя пользователя
    @return имя файла, нахожящегося в /static
    @todo переместить эту функцию в соответствующий файл.
    """
    avatar_siteurl = "uploads/avatar_" + username + ".jpg"
    if os.path.isfile(
            '{}/uploads/avatar_{}.jpg'.format(app.static_folder, username)):
        filename = avatar_siteurl
    else:
        filename = "default_avatar.png"
    return filename


@app.route('/user/<username>/change_avatar', methods=['POST'])
@can(current_rules='mod')
def change_avatar(username=None):
    """!
    @brief View страницы изменения аватара
    Висит на /user/<username>/change_avatar
    @return редирект на /user/<username>
    """
    form = UploadForm()
    st = app.static_folder
    username = get_user_name()

    if form.validate_on_submit():
        filename = secure_filename(form.file.data.filename)
        extension = filename[filename.find('.'):]
        filepath = '{}/uploads/avatar_{}{}'.format(st, username, extension)
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

    return redirect(url_for('userpage'))


@app.errorhandler(CSRFError)
def csrf_error(reason):
    """!
    @brief Обработчик сообщения защиты о CSRF-атаках
    @return responce со страницей 400
    """
    return 'CSRF Protection ' + str(reason), 400


@app.errorhandler(404)
def not_found(e):
    """!
    @brief Обработчик сообщения 404 not found
    @return responce со страницей 404
    """
    context = get_base_data()
    context['error'] = e
    return render_template('404.html', **context), e.code


@app.errorhandler(500)
def error500(e):
    """!
    @brief Обработчик сообщения 500 internal server error
    @return responce со страницей 500
    """
    context = get_base_data()
    context['error'] = dict(code=500, name='Internal server error')
    return render_template('error.html', **context), 500


@app.route('/user/<username>/edit', methods=['POST', 'GET'])
@login_required
@can(current_rules='mod')
def render_edit_page(username=None):
    """!
    @brief View страницы редактирования пользователя
    Висит на /user/<username>/edit
    @return responce с готовой страницей или редирект на /user/<username>/
    """
    form = ChangeUserInfoForm()
    context = get_base_data()
    context['email'] = get_user_email(context['user'])
    context['username'] = context['user']
    context.update(dict(form=form))
    if form.validate_on_submit():
        new_email = form.new_email._value()
        new_login = form.new_login._value()
        flag = check_login(context['user'])
        if not flag:
            return redirect(url_for('render_edit_page', **context))
        else:
            change_user_info(context['user'], new_email, new_login)
            pattern = app.static_folder + '/uploads/avatar_'
            old_file = pattern + context['user'] + '.jpg'
            new_file = pattern + new_login + '.jpg'
            try:
                os.rename(old_file, new_file)
            except Exception:
                pass
            login_user(new_login)
            return redirect(url_for('userpage'))
    else:
        return render_template('editUserData.html', **context)


@app.route('/user/<username>/password_edit', methods=['POST', 'GET'])
@login_required
@can(current_rules='mod')
def render_password_page(username=None):
    """!
    @brief View страницы редактирования пароля
    Висит на /user/<username>/password_edit
    @return responce с готовой страницей
    """
    form = ChangePasswordForm()
    context = {}
    context.update(dict(form=form))
    if form.validate_on_submit():
        old_password = sha1(form.old_password.data + SALT).hexdigest()
        new_password = sha1(form.new_password.data + SALT).hexdigest()
        checker = change_password(get_user_id(), new_password, old_password)
        if type(checker) != unicode:
            return redirect(url_for('userpage'))
        else:
            context = get_base_data()
            context.update(dict(form=form))
            flash(checker)

            return render_template('password_change.html', **context)
    else:
        context = get_base_data()
        context.update(dict(form=form))
        return render_template('password_change.html', **context)


@app.route('/quests', methods=['GET'])
@login_required
def list_quests():
    """!
    @brief View списка квестов
    Висит на /quests
    @return responce с готовой страницей
    """
    # TODO: Get quest list and show it
    context = get_base_data()
    q = Quest.query.all()
    context["quests"] = list(item.__dict__ for item in q)

    # Adding image paths
    for i in range(len(context['quests'])):
        context['quests'][i]['file'] = get_quest_avatar_filename(context['quests'][i]['id'])
    return render_template('quests_list.html', **context)


def get_quest_avatar_filename(quest_id):
    """!
    @brief Функция получения filename'а пользователя.
    @param username имя пользователя
    @return имя файла, нахожящегося в /static
    @todo переместить эту функцию в соответствующий файл.
    """
    quest_siteurl = "uploads/quest_image_{}.jpg".format(quest_id)
    if os.path.isfile(
            '{}/uploads/quest_image_{}.jpg'.format(app.static_folder, quest_id)):
        filename = quest_siteurl
    else:
        filename = "quest_default.png"
    return filename


@app.route('/quests/<quest_id>/change_image', methods=['POST'])
@login_required
# @can(current_rules='mod')
def change_quest_image(quest_id):
    """!
    @brief View страницы изменения картинки квеста
    @return редирект на /user/<username>/add_quest
    """
    context = get_base_data()
    context['username'] = context['user']
    form2 = UploadForm()
    st = app.static_folder
    if form2.validate_on_submit():
        filename = secure_filename(form2.file.data.filename)
        extension = filename[filename.find('.'):]
        filepath = '{}/uploads/quest_image_{}{}'.format(st, quest_id, extension)
        try:
            form2.file.data.save(filepath)
        except IOError:
            os.makedirs(st + '/uploads/')
            form2.file.data.save(filepath)
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

    return redirect(url_for('edit_quest', quest_id=quest_id))


@app.route('/quests/add', methods=['POST', 'GET'])
@login_required
# @can(current_rules='mod')
def add_quest():
    """! обрабатывает добавление квеста.
    @return Okey,если квест успшено добавлена, "Enter more Data", если не хватает данных
    """
    form1 = QuestForm()
    context = get_base_data()
    context['form']=form1
    context['fileurl'] = '/static/' + 'quest_default.png'
    if form1.validate_on_submit():
        owner = get_user_id()
        nameq = form1.nameq._value()
        complexity = form1.complexity.data
        count = form1.count._value()
        task = form1.task._value()
        text = form1.text._value()
        flag = quest_interface.add(nameq, complexity, count, text, task, owner)
        if not flag:
            flash(flag)
        return redirect(url_for('list_quests'))
    else:
        context['form1'] = form1
    return render_template('add_quest.html', **context)


@app.route('/quests/<quest_id>', methods=['GET'])
@login_required
def get_quest(quest_id):
    quest = quest_interface.get_quest_by_id(quest_id)
    context = get_base_data()
    context['fileurl'] = get_quest_avatar_filename(quest_id)
    context['userid'] = get_user_id()
    if quest is None:
        abort(404)
    data_dict = quest.__dict__

    for i in data_dict.keys():
        if i[0] == '_':
            del data_dict[i]
    context.update(data_dict)
    return render_template('quest_page.html', **context)


@app.route('/quests/<quest_id>/edit', methods=['POST', 'GET'])
@login_required
def edit_quest(quest_id):
    # TODO: get quest, change info
    quest = quest_interface.get_quest_by_id(quest_id)
    context = get_base_data()
    form1 = QuestForm()
    form2 = UploadForm()
    context['fileurl'] = get_quest_avatar_filename(quest_id)
    context['form'] = form1
    context['form2'] = form2
    context.update(dict(form=form1))
    if quest is None:
        abort(404)
    data_dict = quest.__dict__

    for i in data_dict.keys():
        if i[0] == '_':
            del data_dict[i]
    context.update(data_dict)
    if request.method == "POST":
        if form1.validate_on_submit():
            new_nameq = form1.nameq.data
            new_complexity = form1.complexity.data
            new_text = form1.text.data
            new_count = form1.count.data
            new_task = form1.task.data
            quest_interface.update(quest_id, new_nameq, new_complexity, new_count, new_text, new_task)
            return redirect(url_for('get_quest', quest_id=quest_id))
        else:
            flash(form1.errors)
    return render_template('edit_quest.html', **context)