from math import *
a = int(input())
l = []


def prime(q):
    i = 2
    while i <= floor(sqrt(q)) + 1:
        while q % i == 0:
            q = q // i 
            l.append(i)
        i += 1
    if q != 1:
        l.append(q)
    return l


print(prime(a))
