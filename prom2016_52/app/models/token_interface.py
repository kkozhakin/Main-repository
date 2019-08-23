from datetime import datetime, timedelta
from app import db
from app.models.models_bd import TokenData


def save_token_time(_usr):
    delta = timedelta(days=30)
    now = datetime.utcnow()
    time = delta + now
    db.session.add(TokenData(time, _usr.id))
    db.session.commit()
