# -*- coding: utf8 -*-
from functools import wraps
from flask import flash, redirect, session, url_for, request

from app.models.user_interface import get_id_by_login, get_rules_by_login


def loggedin():
    """! проверяет залогинен ли юзер.

    @return True или False, в зависимости от того, залогинен ли пользователь

    """
    return 'username' in session


def login_required(function):
    """! Checking, that you are logged in.

    @return функция, которая редиректит на страницу входа, если нужно залогиниться
            или уведомление о логине, если AJAX-запрос

    """

    @wraps(function)
    def decorated_function(*args, **kwargs):
        if not loggedin():
            if request.url.find('api') == -1:
                flash('You need to login')
                return redirect(url_for('login'))
            else:
                return 'You need to login to perform this action'
        return function(*args, **kwargs)

    return decorated_function


def login_not_required(function):
    """! Checking, that you aren't logged in.

    @return функция, которая редиректит на страницу выхода, если нужно раззалогиниться

    """

    @wraps(function)
    def decorated_function(*args, **kwargs):
        if loggedin():
            flash('You need to logout before request')
            return redirect(url_for('index'))
        return function(*args, **kwargs)

    return decorated_function


def login_user(username):
    """! логинит юзера, записывает в сессию user_info.

    @return возвращает на главную

    """
    session['username'] = username
    session['id'] = get_id_by_login(username)
    return redirect(url_for('index'))


def get_user_name():
    """!

    @return возвращает логин юзера, который хранится в сессии

    """
    if loggedin():
        return session['username']
    else:
        return None


def get_user_id():
    """!

    @return возвращает id юзера, который хранится в сессии

    """
    if loggedin():
        return session['id']
    else:
        return None


def get_base_data():
    context = {
        'user': get_user_name(),
        'id': get_user_id(),
        'loggedin': loggedin(),
        'user_rules': get_rules_by_login(get_user_name())
    }
    return context