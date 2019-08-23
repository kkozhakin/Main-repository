# -*- coding:utf8 -*-

import json

from app.models.user_interface import get_login_by_id


def getJsonData(json_filename):
    """! читает строку файла, передает ее в парсер из json'a в объект
     @param json_filename имя файла с json строкой
     @return возвращает объект, распарсенный из первой строки файла
    """

    with open(json_filename) as f:
        data = f.read()
        parsed_data = json.loads(data)
    return parsed_data


def getDictEvent(event):
    """! из объекта event  делает словарь
     @param  объект Event из 'models_bd.py'
     @return возвращает словарь с событием event
    """
    if event is None:
        return None
    data_dict = event.__dict__
    for i in data_dict.keys():
        if i[0] == '_':
            del data_dict[i]
    data_dict['owner'] = get_login_by_id(data_dict['owner'])
    return data_dict


def getEventShortInfo(event):
    data_dict = {'id': event.id, 'text': event.text, 'name': event.name, 'latitude': event.latitude,
                 'longitude': event.longitude, 'owner': event.owner, 'adr': event.adr}
    return data_dict

