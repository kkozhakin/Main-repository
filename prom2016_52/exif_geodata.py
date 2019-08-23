# -*- coding: utf8 -*-

from PIL import Image
from PIL.ExifTags import TAGS


def get_exif(fn): ### достаёт мето данные из фото
    ret = {}
    i = Image.open(fn)
    info = i._getexif()
    for tag, value in info.items():
        decoded = TAGS.get(tag, tag)
        ret[decoded] = value
    return ret


def selection1(l):    ### широта
    d = []
    i = 0
    while i < 3:
        q = l[i]
        s = q[0]
        w = q[1]
        if w == 1:
            d.append(s)
        else:
            d.append("%.5f" % (float(s) / w))
        i += 1
    h = "%.5f" % (d[0] + float(d[1]) / 60 + float(d[2]) / 3600)
    return float(h)


def selection2(p):   ###долгота
    d = []
    f = 0
    while f < 3:
        q = p[f]
        s = q[0]
        w = q[1]
        if w == 1:
            d.append(s)
        else:
            d.append("%.5f" % (float(s) / w))
        f += 1
    h = "%.5f" % (d[0] + float(d[1]) / 60 + float(d[2]) / 3600)
    return float(h)


def inspection(s, r, y, a):  ### обработка проверка данных True False
    h = get_exif(s)  ### достаёт мето данные из фото
    l = None   ###широта
    p = None   ###долгота
    try:
        j = h.get('GPSInfo', [None, None])
        l = j.get(2, None)
        p = j.get(4, None)
    except AttributeError:
        j = [None, None]
    if l is None and p is None:
        j = [None, None]
    else:
        e = selection1(l)    ###широта
        w = selection2(p)    ###долгота

    if j == [None, None]:    ### провеанныхряет отсутствие данных иначе проверяет на совподение с возможными
        f = True
    else:
        e -= r   ### разница координат
        q = 0.012 * a    ### возможн погрешность
        if e < 0:
            e = -e
        f = (e < q)   ### проверка I

        w -= y       ### разница координат
        if w < 0:
            w = -w
        x = (w < q)   ### проверка II

        if not x:        ### окончательная проверка
            f = False

    return f


def main():
    s = '2017-02-24-234753.jpg'  ### s это имя файла
    r = 55.92799  ### r y это заданные координаты
    y = 37.78325
    a = 1  ### a это допустимая точность (задаётся в километрах). По умолчанию - 1 км.
    print inspection(s, r, y, a)
main()
