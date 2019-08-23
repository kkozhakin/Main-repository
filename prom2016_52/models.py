from app import db


class User(db.Model):
    __tablename__ = 'user'
    id = db.Column(db.Integer, primary_key=True)
    login = db.Column(db.String(100))
    password = db.Column(db.String(100))
    name = db.Column(db.String(100))
    email = db.Column(db.String(100))
    comments = db.relationship('Comment', backref='author', lazy='dynamic')
    places = db.relationship('Place', backref='author', lazy='dynamic')


class Comment(db.Model):
    __tablename__ = 'comment'
    id = db.Column(db.Integer, primary_key=True)
    text = db.Column(db.String(100))
    place = db.Column(db.Integer, db.ForeignKey('place.id'))
    author = db.Column(db.Integer, db.ForeignKey('user.id'))
    picture = db.Column(db.Integer, db.ForeignKey('picture.id'))
    added = db.Column(db.DateTime)


class Place(db.Model):
    __tablename__ = 'place'
    id = db.Column(db.Integer, primary_key=True)
    owner = db.Column(db.Integer, db.ForeignKey('user.id'))
    latitude = db.Column(db.Integer)
    longitude = db.Column(db.Integer)
    direction = db.Column(db.Integer)
    height = db.Column(db.Integer)
    name = db.Column(db.String(100))
    description = db.Column(db.String(100))
    picture = db.Column(db.Integer, db.ForeignKey('picture.id'))
    comments = db.relationship('Comment', backref='place', lazy='dynamic')


class Picture(db.Model):
    __tablename__ = 'picture'
    id = db.Column(db.Integer, primary_key=True)
    url = db.Column(db.String(100))
    add_date = db.Column(db.DateTime)
    md5 = db.Column(db.Integer)
    exif = db.Column(db.Integer, db.ForeignKey('picture_exif.id'))
    comment = db.relationship('Comment', backref='picture', uselist=False, lazy='dynamic')
    place = db.relationship('Place', backref='place', uselist=False, lazy='dynamic')


class PictureExif(db.Model):
    __tablename__ = 'picture_exif'
    id = db.Column(db.Integer, primary_key=True)
    latitude = db.Column(db.Integer)
    longitude = db.Column(db.Integer)
    picture = db.relationship('Picture', backref='picture_exif', uselist=False, lazy='dynamic')