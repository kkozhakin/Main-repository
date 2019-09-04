import sys
sys.setrecursionlimit(10 ** 6)

fin = open('matrix2.in', 'r')
fout = open('matrix2.out', 'w')
n, m = map(int, fin.readline().split())
a = [[] for i in range(n + 1)]
for i in range(m):
    b, c = map(int, fin.readline().split())
    a[b].append(c)
    a[c].append(b)
color = [0] * (n + 1)


def dfs(k):
    color[k] = q
    for v in a[k]:
        if not color[v]:
            dfs(v)


q = 1
for i in range(1, n + 1):
    if not color[i]:
        dfs(i)
        q += 1
l = [[] for i in range(q)]
l1 = [0] * q
fout.write(str(q - 1) + '\n')
for i in range(1, n + 1):
    l[color[i]].append(i)
    l1[color[i]] += 1
for i in range(1, q):
    if l1[i] and l[i]:
        fout.write(str(l1[i]) + '\n' + ' '.join(map(str, l[i])) + '\n')
fin.close()
fout.close()