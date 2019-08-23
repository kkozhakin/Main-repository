# -*- coding: utf8 -*-
from math import pi, cos, sin, pow, sqrt, atan2
from random import randrange

from app import db
from app.models.models_bd import Event, User

EARTH_RADIUS = 6372795


def get_dist(lat1, long1, lat2, long2):
    """
    @brief Находит расстояние между двумя точками в метрах(км??))
    @param lat1:координата широты
    @param long1: координата долготы
    @param lat2: координата широты
    @param long2: координата долготы
    @return: расстояние между двумя точками(int)
    """
    # latitude = x
    # longitude = y
    lat2 = float(lat2)
    long2 = float(long2)

    lat1 = lat1 * pi / 180.0
    lat2 = lat2 * pi / 180.0
    long1 = long1 * pi / 180.0
    long2 = long2 * pi / 180.0
    cl1 = cos(lat1)
    cl2 = cos(lat2)
    sl1 = sin(lat1)
    sl2 = sin(lat2)
    delta = long2 - long1
    cdelta = cos(delta)
    sdelta = sin(delta)
    y = sqrt(pow(cl2 * sdelta, 2) + pow(cl1 * sl2 - sl1 * cl2 * cdelta, 2))
    x = sl1 * sl2 + cl1 * cl2 * cdelta
    ad = atan2(y, x)
    dist = ad * EARTH_RADIUS
    return dist


def get_event_by_rad(events, x, y, r):
    response = []
    for i in events:
        if get_dist(x, y, i.latitude, i.longitude) <= r:
            response.append(i)
    return response


def add_mark(d, _user):
    owner = User.query.filter_by(login=_user).first()
    db.session.add(Event(d['name'], d['desc'], 0, d['longitude'],
                         d['latitude'], d['city'], 'flags', d['inputDate3'], d['inputDate4'], owner.id,
                         d['adr']))


def get_random_events():
    '''
    @brief Находит пять рандомных событий
    @return: Пять рандомных событий или все события если их меньше пяти.
    '''
    events = Event.query.all()
    if len(events) > 5:
        rand_events = []
        for i in range(5):
            index = randrange(0, len(events))
            rand_events.append(events[index])
            del events[index]
        return rand_events
    else:
        return events


def new_search(_data):
    '''
    @brief Поиск событий по определенным параметрам
    @return: События, найденные при поиске
    '''
    search_dict = {}
    events = None
    for i in _data.keys():
        if _data[i] != '':
            search_dict[i] = _data[i]
    if search_dict == {u'owner': None}:
        return get_random_events()
    base_search_dict = {}
    if 'owner' in search_dict.keys():
        base_search_dict.update(owner=search_dict['owner'])
    if 'city' in search_dict.keys():
        base_search_dict.update(city=search_dict['city'])
    events = Event.query.filter_by(**base_search_dict)

    if 'x' in search_dict.keys():
        events = get_event_by_rad(events, search_dict['x'], search_dict['y'], search_dict['r'])
    return events


def get_user_marks(_user):
    _owner = User.query.filter_by(login=_user).first()
    data = Event.query.filter_by(owner=_owner.id).all()
    return data


def get_mark_by_id(_id):
    data = Event.query.filter_by(id=_id).first()
    return data


def change_event_info(new_name, new_text):
    event = Event.query.filter_by(id).update(dict(name=new_name, text=new_text))
    db.session.commit()


def id_event_owner(_id):
    return Event.query.filter_by(id=_id).first().owner


def event_exists(_id):
    if Event.query.filter_by(id=_id) is None:
        return False
    else:
        return True


def del_events(_id):
    Event.query.filter_by(id=_id).delete()
    db.session.commit()
