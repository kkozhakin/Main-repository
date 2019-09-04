# -*- coding: utf8 -*-

from app import db, app
from app.models.models_bd import User,TokenData
from app.models.token_interface import save_token_time
from datetime import datetime


def login(_user, _password):
    """! есть ли в базе юзер с таким логином и паролем

     @param _user желаемый логин
     @param _password желаемый пароль
     @return True - есть, String - ошибка, нет
    """

    user = User.query.filter_by(login=_user).filter_by(password=_password).first()
    if user is None:
        return False

    # user_login = User.query.filter_by(login=_user)
    # if user_login.first() is None:
    #     return 'Wrong username!'
    # user_passw = user_login.filter_by(password=_password)
    # if user_passw.first() is None:
    #     return 'Wrong password!'
    return True


def register(_email, _user, _password, _name, _surname):
    """! регистрирует нового юзера

     @param _email введенная почта
     @param _user введенный логин
     @param _password введенный пароль
     @return True - успешно, String - ошибка, не зарегестрирован
    """

    user = User.query.filter_by(login=_user).first()
    if user is not None:
        return 'User already exists!'
    db.session.add(User(_user, _email, _password, _name, _surname, 'simple'))
    db.session.commit()
    return True


def change_user_info(username, new_email, new_login):
    User.query.filter_by(login=username).update(dict(login=new_login, email=new_email))
    db.session.commit()


def change_password(_id, _new_password, _old_password):
    if _old_password == User.query.filter_by(id=_id).first().password:
        user = User.query.filter_by(id=_id).update(dict(password=_new_password))
        db.session.commit()
        if not user is None:
            return True
        else:
            return u'Пользователь не найден!'
    return u'Старый пароль неверен!'


def check_login(_user):
    """!есть ли в базе юзер с таким логином

     @param _user желаемый логин
     @return True/False - есть/нет
    """

    user = User.query.filter_by(login=_user).first()
    if user is not None:
        return True
    else:
        return False


def get_id_by_login(_user):
    """! получает id пользователя по логину

    @return id user'a
    """
    owner = User.query.filter_by(login=_user).first().id
    return owner


def get_login_by_id(_id):
    owner = User.query.filter_by(id=_id).first().login
    return owner


def get_user_email(username):
    """!
    @param username: логин данного юзера
    @return возвращает email юзера, который хранится в базе данных
    """
    user = User.query.filter_by(login=username).first()
    if user is not None:
        email = user.email
        return email
    else:
        return None

def get_user_name1(username):
    """!
    @param username: логин данного юзера
    @return возвращает имя юзера, который хранится в базе данных
    """
    user = User.query.filter_by(login=username).first()
    if user is not None:
        name = user.name
        return name
    else:
        return None

def get_user_surname(username):
    """!
    @param username: логин данного юзера
    @return возвращает фамилию юзера, который хранится в базе данных
    """
    user = User.query.filter_by(login=username).first()
    if user is not None:
        surname = user.surname
        return surname
    else:
        return None


def get_rules_by_login(_user):
    """! получает rule пользователя по логину

    @return rule user'a
    """
    user = User.query.filter_by(login=_user).first()
    if user:
        return user.rules.encode("utf-8")
    else:
        return None


def get_rules_by_id(_id):
    return User.query.filter_by(id=_id).first().rules.encode("utf-8")


def change_users_rules(_user, rule):
    user = User.query.filter_by(login=_user).update(dict(rules=rule))
    db.session.commit()


def get_user_tokens_num(_id):
    user = User.query.filter_by(id=_id).first()
    if user is None:
        return None
    else:
        return user.tokens_num


def set_user_token_num(_id):
    user = User.query.filter_by(id=_id).first()
    if user is None:
        return False
    else:
        upd = dict(tokens_num=int(app.config['TOKEN_NUMS']))
        user = User.query.filter_by(id=_id).update(upd)
        db.session.commit()
        return True


def use_token(_id):
    user = User.query.filter_by(id=_id).first()
    if user is None:
        return False
    now = datetime.utcnow()
    token_date = TokenData.query.filter_by(owner=_id).first()
    current_day = datetime.strftime(now,"%x")
    if not token_date is None:
        token_day = datetime.strftime(token_date.date,"%x")
        if current_day == token_day:
            set_user_token_num(_id)
    tn = user.tokens_num
    if tn == int(app.config['TOKEN_NUMS']):
        save_token_time(user)

    if int(tn) <= 0:
        return False
    tn -= 1
    user = User.query.filter_by(id=_id).update(dict(tokens_num=tn))
    db.session.commit()
    return True
