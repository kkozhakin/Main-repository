fin = open('mindist2.in', 'r')
fout = open('mindist2.out', 'w')
n, m = map(int, fin.readline().split())
a = [[] for i in range(n + 1)]
s, f = map(int, fin.readline().split())
for i in range(m):
    b, c = map(int, fin.readline().split())
    a[b].append(c)
    a[c].append(b)
q = [s]
used = [0 for i in range(n + 1)]
l1 = [0] * (n + 1)


def bfs(k):
    used[k] = 1
    h = 0
    t = 1
    while h < t:
        u = q[h]
        h += 1
        for v in a[u]:
            if not used[v]:
                l1[v] = u
                q.append(v)
                used[v] = used[u] + 1
                t += 1


bfs(s)
fout.write(str(used[f] - 1) + '\n')
l = []
while f != 0:
    l.append(f)
    f = l1[f]
for i in l[::-1]:
    fout.write(str(i) + ' ')
fin.close()
fout.close()