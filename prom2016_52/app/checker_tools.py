# coding=utf-8
from functools import wraps
from flask import request, url_for, flash, redirect
from app.models.event_interface import id_event_owner
from app.models.user_interface import get_rules_by_login
from app.login_tools import get_user_id, get_user_name


rules_weights = {'simple': 0, 'mod': 1, 'admin': 2}


def can(current_rules='simple'):
    def decorator(method):
        @wraps(method)
        def f(*args, **kwargs):
            rules = get_rules_by_login(get_user_name())
            r = request.url
            if rules_weights[rules] < rules_weights[current_rules]:
                if r.find('event') != -1:
                    if int(id_event_owner(int(kwargs['id']))) == int(get_user_id()):
                        return method(*args, **kwargs)
                if r.find('user') != -1:
                    if kwargs['username'] == get_user_name():
                        return method(*args, **kwargs)
                flash('You do not have access')
                return redirect(url_for('index'))
            else:
                return method(*args,**kwargs)
        return f
    return decorator


