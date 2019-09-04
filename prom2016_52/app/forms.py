# -*- coding: utf8 -*-
import datetime
import imghdr

import wtforms_json
from flask_wtf import Form, FlaskForm
from flask_wtf.recaptcha import RecaptchaField
from wtforms import StringField, BooleanField, PasswordField, validators, RadioField, FileField, IntegerField, \
    DateField
from wtforms.validators import ValidationError
from wtforms.widgets import TextArea
from jinja2 import utils

from app.models.user_interface import check_login

wtforms_json.init()


def check_xss(form, field):
    data = field.data
    if data != utils.escape(data):
        raise ValidationError(u"Please, don't hack me")


def validate_name(form, field):
    check = check_login(field.data)
    if check:
        raise ValidationError(u'Логин уже использутеся.')


class ImageFileRequired(object):
    def __init__(self, message=None):
        self.message = message

    def __call__(self, form, field):
        if field.data is None or imghdr.what('unused', field.data.read()) is None:
            message = self.message or 'An image file is required'
            raise validators.StopValidation(message)

        field.data.seek(0)


class LoginForm(FlaskForm):
    """! форма для логина"""
    login = StringField('login', [validators.length(min=1, max=25, message=u'Поле должно быть заполнено.')])
    password = PasswordField('password', [validators.length(min=1, message=u'Поле должно быть заполнено.')])


class QuestForm(FlaskForm):
    """! форма для квеста"""
    nameq = StringField('nameq', [validators.length(min=1, max=25, message=u'Поле должно быть заполнено.')])
    count = StringField('count', [validators.length(min=1, max=2, message=u'Поле должно быть заполнено.')])
    complexity = RadioField('complexity', choices=[('1', '1'), ('2', '2'), ('3', '3'), ('4', '4'), ('5', '5')])
    task = StringField('task', [validators.length(min=1, message=u'Поле должно быть заполнено.')])
    text = StringField('text', [validators.length(min=1, message=u'Поле должно быть заполнено.')])


class ChangeQuestInfoForm(FlaskForm):
    new_nameq = StringField('nameq', [validators.length(min=1, max=25, message=u'Поле должно быть заполнено.')])
    new_count = StringField('count', [validators.length(min=1, max=2, message=u'Поле должно быть заполнено.')])
    new_complexity = RadioField('complexity', choices=[('1', '1'), ('2', '2'), ('3', '3'), ('4', '4'), ('5', '5')])
    new_task = StringField('task', [validators.length(min=1, message=u'Поле должно быть заполнено.')])
    new_text = StringField('text', [validators.length(min=1, message=u'Поле должно быть заполнено.')])


class RegistrationForm(FlaskForm):
    """! форма для регистрации"""
    username = StringField('Username',
                           [validators.Length(min=4, max=25, message=u'Длина логина должна быть от 4 до 25'),
                            validate_name])
    email = StringField('Email Address', [validators.Email(message=u'Неверный формат.')])
    password = PasswordField('New Password', [validators.EqualTo('confirm', message=u'Пароли должны совпадать'),
                                              validators.Length(min=1, message=u'Поле должно быть заполнено.')])
    confirm = PasswordField('Repeat Password')
    name = StringField('Name',
                           [validators.Length(min=4, max=25, message=u'Длина имени должна быть от 4 до 25'),
                            validate_name])
    surname = StringField('Surname',
                           [validators.Length(min=4, max=25, message=u'Длина фамилии должна быть от 4 до 25'),
                            validate_name])
    recaptcha = RecaptchaField()


class ChangeUserInfoForm(FlaskForm):
    """ форма для изменения данных пользователя"""
    new_login = StringField('Username',
                            [validators.length(min=4, max=25, message=u'Длина логина должна быть от 4 до 25'),
                             validate_name])
    new_email = StringField('Email Address', [validators.Email(message=u'Неверный формат.')])


class ChangePasswordForm(FlaskForm):
    """ форма для изменения данных пользователя"""
    old_password = PasswordField('Old Password', [validators.Length(min=1, message=u'Поле должно быть заполнено.')])
    new_password = PasswordField('New Password', [validators.EqualTo('confirm', message=u'Пароли должны совпадать'),
                                                  validators.Length(min=1, message=u'Поле должно быть заполнено.')])
    confirm = PasswordField('Repeat Password', [validators.Length(min=1, message=u'Поле должно быть заполнено.')])


class MarkForm(Form):
    """! форма для добавления метки"""
    name = StringField('name', [validators.Length(min=1, message=u'Поле должно быть заполнено.'), check_xss])
    city = StringField('city', [validators.Length(min=1, message=u'Поле должно быть заполнено.'), check_xss])
    desc = StringField('desc', [validators.Length(min=1, message=u'Поле должно быть заполнено.'), check_xss])
    adr =  StringField('adr', [validators.data_required(), check_xss])


class AdminForm(FlaskForm):
    name = StringField('name', [validators.Length(min=1, message=u'Введите имя пользователя.')])


class ReportForm(FlaskForm):
    types = RadioField('Label', choices=[('spam', u'Спам'),
                                         ('violent_lang', u'Мат'),
                                         ('insult', u'Оскорбление'),
                                         ('propaganda', u'Экстремизм'),
                                         ('other', u'Другое')])
    text = StringField('description')


class CommentForm(FlaskForm):
    body = StringField(u'Text', [validators.data_required(), check_xss], widget=TextArea())


class DelForm(FlaskForm):
    accept = BooleanField([validators.required(message=u'Поле должно быть заполнено.')])


class UploadForm(FlaskForm):
    file = FileField(validators=[ImageFileRequired()])
