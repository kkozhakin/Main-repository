import sys
sys.setrecursionlimit(10 ** 6)

fin = open('cycle2.in', 'r')
fout = open('cycle2.out', 'w')
n, m = map(int, fin.readline().split())
a = [[] for i in range(n + 1)]
color = [0] * (n + 1)
for i in range(m):
    b, c = map(int, fin.readline().split())
    a[b].append(c)
l = []
q = False


def dfs(v):
    global q
    color[v] = 1
    l.append(v)
    for k in a[v]:
        if color[k] == 0:
            dfs(k)
        elif (color[k] == 1) and not q:
            q = True
            fout.write('YES' + '\n' + ' '.join(map(str, l[l.index(k):])))
    l.pop()
    color[v] = 2


for i in range(1, n + 1):
    if color[i] == 0:
        dfs(i)
if not q:
    fout.write('NO')
fin.close()
fout.close()
