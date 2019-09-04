from flask import redirect
from flask import url_for
from flask_admin.contrib.sqla import ModelView

from app import admin, db
from app.login_tools import get_user_name, get_base_data
from app.models.models_bd import User, Event, Comment
from app.models.user_interface import get_rules_by_login


class MyModelView(ModelView):
    def is_accessible(self):
        if get_rules_by_login(get_user_name()) == 'admin':
            return True
        else:
            return False

    def inaccessible_callback(self, name, **kwargs):
        context = get_base_data()
        return redirect(url_for('index', **context))


admin.add_view(MyModelView(User, db.session))
admin.add_view(MyModelView(Event, db.session))
admin.add_view(MyModelView(Comment, db.session))
