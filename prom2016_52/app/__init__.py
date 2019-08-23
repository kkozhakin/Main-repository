# -*- coding: utf8 -*-
import flask_profiler
from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from flask_wtf import CSRFProtect
from flask_admin import Admin

app = Flask(__name__)

csrf = CSRFProtect()
CSRFProtect(app)
csrf.init_app(app)

app.config.from_object('config')

app.config["DEBUG"] = True

app.config["flask_profiler"] = {
    "enabled": app.config["DEBUG"],
    "storage": {
        "engine": "sqlite"
    },
    "basicAuth": {
        "enabled": True,
        "username": "admin",
        "password": "123"
    },
    "ignore": ["^/static/.*"]
}

flask_profiler.init_app(app)

# Автоперезагрузка сервера при отладке шаблонов
app.jinja_env.auto_reload = True
app.config['TEMPLATES_AUTO_RELOAD'] = True

db = SQLAlchemy(app)

admin = Admin(app, name='Fotograff', template_mode='bootstrap3')

from app import views, api_routes, admin_routes
