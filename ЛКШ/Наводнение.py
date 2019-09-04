from collections import deque

fin = open('flood.in', 'r')
fout = open('flood.out', 'w')
a, b = map(int, fin.readline().split())
l = [[] for i in range(a + 1)]
d = dict()
for i in range(b):
    m = list(map(int, fin.readline().split()))
    l[m[0]].append(m[1])
    l[m[1]].append(m[0])
    if (m[0], m[1]) in d:
        d[(m[0], m[1])] = max(d[(m[0], m[1])], m[2])
        d[(m[1], m[0])] = max(d[(m[1], m[0])], m[2])
    else:
        d[(m[0], m[1])] = m[2]
        d[(m[1], m[0])] = m[2]


def bfs(v):
    q = deque([v])
    while q:
        u = q.popleft()
        if not used[u - 1]:
            used[u - 1] = True
            for k in l[u]:
                if d[(k, u)] > w:
                    q.append(k)


L = 0
R = 10 ** 9 + 1
while R - L > 1:
    w = (R + L) // 2
    used = [False] * a
    c = 0    
    for i in range(1, a + 1):
        if not used[i - 1]:
            bfs(i)
            c += 1
    if c > 1:
        R = w
    else:
        L = w
w = 0
used = [False] * a
c = 0    
for i in range(1, a + 1):
    if not used[i - 1]:
        bfs(i)
        c += 1
if c > 1:
    fout.write('0\n')
else:
    fout.write(str(R) + '\n')
fin.close()
fout.close()
