from app import db
from app.login_tools import get_user_id
from app.models.models_bd import Comment


def comment_event(_event, _text):
    a = Comment.query.filter_by(event=_event, text=_text, author=get_user_id()).all()
    if not len(a):
        db.session.add(Comment(_event, get_user_id(), _text))
        db.session.commit()
        return 1
    return 0


def get_comments_event(_event):
    return Comment.query.filter_by(event=_event).all()


def del_comments_with_event(_event):
    Comment.query.filter_by(event=_event).delete()
    db.session.commit()
