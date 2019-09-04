fin = open('distance.in', 'r')
fout = open('distance.out', 'w')
INF = float('inf')
n, m = map(int, fin.readline().split())
s, f = map(int, fin.readline().split())
a = [[] for i in range(n + 1)]
for i in range(m):
    b, c, w = map(int, fin.readline().split())
    a[b].append((c, w))
    a[c].append((b, w))
used = [False] * (n + 1)
d = [INF] * (n + 1)
d[s] = 0
l = [0] * (n + 1)
for i in range(n):
    m = 0
    for j in range(1, n + 1):
        if (d[m] > d[j]) and not used[j]:
            m = j
    used[m] = True
    for j in a[m]:
        if d[j[0]] > d[m] + j[1]:
            d[j[0]] = d[m] + j[1]
            l[j[0]] = m
i = l[f]
l1 = []
while i != 0:
    l1.append(i)
    i = l[i]
if d[f] != INF:
    fout.write(str(d[f]) + '\n' + ' '.join(map(str, l1[::-1])) + ' ' + str(f))
else:
    fout.write('-1')
fin.close()
fout.close()
