import random

fin = open('qsort.in', 'r')
fout = open('qsort.out', 'w')
l = list(map(int, fin.readline().split()))


def qsort(a):
    if len(a) < 2:
        return a
    else:
        q = random.choice(a)
        l = [i for i in a if i < q]
        r = [i for i in a if i > q]
        l = qsort(l)
        r = qsort(r)
        return l + [q] * (len(a) - len(l) - len(r)) + r


l = qsort(l)
for i in range(len(l)):
    fout.write(str(l[i]) + ' ')
fin.close()
fout.close()
