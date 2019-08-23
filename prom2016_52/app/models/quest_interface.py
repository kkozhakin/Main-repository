# -*- coding: utf8 -*-
from flask import flash

from app import db, app
from app.models.models_bd import User, TokenData, Quest
from app.models.token_interface import save_token_time
from datetime import datetime


def add(_nameq, _complexity, _count, _text, _task, _owner):
    db.session.add(Quest(_nameq, _complexity, _count, _text, _task, _owner))
    db.session.commit()
    return True


def update(quest_id, nameq, complexity, count, text, task):
    try:
        event = Quest.query.filter_by(id=quest_id).update(dict(nameq=nameq, complexity=complexity, count=count, text=text, task=task))
        db.session.commit()
    except Exception:
        flash("Oops! Something went wrong")


def get_id_quest(_nameq):
    return Quest.query.filter_by(nameq=_nameq).first().id


def get_quest_by_id(_id):
    data = Quest.query.filter_by(id=int(_id)).first()
    return data
