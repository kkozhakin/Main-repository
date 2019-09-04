fin = open('min.in', 'r')
fout = open('min.out', 'w')
n, k = map(int, fin.readline().strip().split())
a = [(i, None) for i in list(map(int, fin.readline().strip().split()))]
INF = float('inf')
h = [None]
l = {}
b = {}
d = {}
for i in range(n):
    if a[i][0] in b:
        b[a[i][0]] += 1
        d[a[i][0]] += 1
    else:
        b[a[i][0]] = 1
        d[a[i][0]] = 1


def su(h, c):
    while c > 1 and h[c] < h[c // 2]:
        h[c], h[c // 2] = h[c // 2], h[c]
        l[h[c]], l[h[c // 2]] = l[h[c // 2]], l[h[c]]
        c //= 2


def sd(h, c):
    while 2 * c < len(h):
        p = 2 * c
        if 2 * c + 1 < len(h) and h[2 * c + 1] < h[2 * c]:
            p = 2 * c + 1
        if h[p] < h[c]:
            l[h[p]], l[h[c]] = l[h[c]], l[h[p]] 
            h[p], h[c] = h[c], h[p]
            c = p
        else:
            break


def add(m):
    h.append(m)
    l[m] = len(h) - 1
    su(h, len(h) - 1)
        

def delete(h, m):
    if len(h) == 2 or l[m] == len(h) - 1:
        l.pop(h[l[m]])
        return h.pop()
    k = l[m]
    res = h[k]
    l[h[-1]] = k
    h[k] = h.pop()
    su(h, k)
    sd(h, k)
    return res


for i in range(n):
    a[i] = (a[i][0], d[a[i][0]] - b[a[i][0]])
    b[a[i][0]] -= 1
for i in range(k):
    add(a[i])
for i in range(n - k):
    fout.write(str(h[1][0]) + '\n')
    delete(h, a[i])
    add(a[i + k])
fout.write(str(h[1][0]) + '\n')
fin.close()
fout.close()
