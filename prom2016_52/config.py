# -*- coding: utf8 -*-
import os
basedir = os.path.abspath(os.path.dirname(__file__))

CSRF_ENABLED = True
SECRET_KEY = 'you-will-never-guess'

DB_USER = 'map_admin'
DB_PASS = 'wikipedia.org'
DB_NAME = 'map_db'
DB_HOST = 'localhost'
SALT = "SALT"
secret_key = 'Please,change me'
DB_DIRECTORY = 'db_repository'

TOKEN_NUMS = 300

SQLALCHEMY_DATABASE_URI = 'mysql://{}:{}@{}/{}'.format(DB_USER, DB_PASS, DB_HOST, DB_NAME)
SQLALCHEMY_MIGRATE_REPO = os.path.join(basedir, DB_DIRECTORY)
SQLALCHEMY_TRACK_MODIFICATIONS = True

RECAPTCHA_PUBLIC_KEY = '6LeYIbsSAAAAACRPIllxA7wvXjIE411PfdB2gt2J'
RECAPTCHA_PRIVATE_KEY = '6LeYIbsSAAAAAJezaIq3Ft_hSTo0YtyeFG-JgRtu'
