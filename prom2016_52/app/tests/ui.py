# -*- coding:utf8 -*-

import unittest
from sqlalchemy.orm import make_transient
from app import db
from app.models.models_bd import User
from app.models.user_interface import login


class TestLogin(unittest.TestCase):
    valid_user = User('test_user', 'test@test.net', 'testpass', 'simple')

    def setUp(self):
        a = self.valid_user
        make_transient(a)
        db.session.add(a)
        db.session.commit()

    def tearDown(self):
        db.session.delete(self.valid_user)
        db.session.commit()

    def test_login(self):
        self.assertEqual(login('test_user', 'testpass'), True)

    def test_login_fail_wrong_pass(self):
        self.assertEqual(login('test_user', 'wrongpass'), 'Wrong username or password!')

    def test_login_fail_wrong_login(self):
        self.assertEqual(login('test_usr', 'testpass'), 'Wrong username or password!')


class TestRegister(unittest.TestCase):
    valid_user = User('user2', '1111@abc.net', 'password1', 'simple')

    def setUp(self):
        a = self.valid_user
        make_transient(a)
        db.session.add(a)
        db.session.commit()

    def tearDown(self):
        db.session.delete(self.valid_user)
        db.session.commit()

    def test_success_reg(self):
        self.assertEqual(
            db.session.add(User('user_test', 'test@test.test', 'pass_test', 'simple')),
                           True)

    def test_fail_login_reg(self):
        self.assertEqual(
            db.session.add(User('user2', 'test@test.test', 'pass_test', 'simple')),
                           'User already exists!')

