# -*- coding: utf-8 -*-

from app import db, app  # from backend_map.py import, which contains Flask() object


class User(db.Model):
    """! класс для работы с записями пользователей"""

    id = db.Column(db.Integer, primary_key=True)
    login = db.Column(db.String(80), unique=True)
    email = db.Column(db.String(120))
    name = db.Column(db.String(80))
    surname = db.Column(db.String(80))
    password = db.Column(db.String(40))
    # session = db.Column(db.String(1000))
    rules = db.Column(db.String(20))
    tokens_num = db.Column(db.Integer, nullable=False)
    tokens = db.relationship('TokenData', backref='token_owner', lazy='dynamic')
    events = db.relationship('Event', backref='event_owner', lazy='dynamic')

    def __init__(self, *args):
        """иницииализирует класс пользователя переданными аргументами
         @param args логин, почта, пароль, правила
        """

        self.login, self.email, self.password, self.name, self.surname, self.rules = args
        self.tokens_num = int(app.config['TOKEN_NUMS'])

    def __repr__(self):
        """! строковое представление

         @return строковое представление класса
        """

        return '<User %r>' % self.login


class Event(db.Model):
    """! класс для работы с записями событий

     @todo придумать структуру
    """

    visit = db.Column(db.Integer)
    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.Text)
    text = db.Column(db.Text)
    city = db.Column(db.Text)
    owner = db.Column(db.Integer, db.ForeignKey(User.id))
    longitude = db.Column(db.Text)
    latitude = db.Column(db.Text)
    flags = db.Column(db.Text)
    adr = db.Column(db.Text)

    def __init__(self, *args):
        """! иницииализирует класс события
         @param args все поля события
        """

        self.name, self.text, self.longitude, self.latitude, self.city, self.flags, self.owner, self.adr = args

    def __repr__(self):
        """! строковое представление
         @return строковое представление класса
        """

        return '<Event %r>' % self.name


class Quest(db.Model):
    """! класс для работы с записями квеста

     @todo придумать структуру
    """

    id = db.Column(db.Integer, primary_key=True)
    nameq = db.Column(db.Text)
    complexity = db.Column(db.Integer)
    count = db.Column(db.Integer)
    task = db.Column(db.Text)
    text = db.Column(db.Text)
    owner = db.Column(db.Integer, db.ForeignKey(User.id))

    def __init__(self, *args):
        """! иницииализирует класс события
         @param args все поля события
        """

        self.nameq, self.complexity, self.count, self.text, self.task, self.owner = args

    def __repr__(self):
        """! строковое представление
         @return строковое представление класса
        """

        return '<Quest %r>' % self.name


class TokenData(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    date = db.Column(db.DateTime)
    owner = db.Column(db.Integer, db.ForeignKey(User.id))

    def __init__(self, *args):
        self.date, self.owner = args


class Comment(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    event = db.Column(db.Integer, db.ForeignKey(Event.id))
    author = db.Column(db.Integer, db.ForeignKey(User.id))
    text = db.Column(db.Text)

    def __init__(self, *args):
        self.event, self.author, self.text = args

    def __repr__(self):
        """!строковое представление
         @return строковое представление класса
        """

        return '<Comment %r>' % self.text
