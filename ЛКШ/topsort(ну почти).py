import sys
sys.setrecursionlimit(10 ** 6)

fin = open('topsort.in.txt', 'r')
fout = open('topsort.out', 'w')
n, m = map(int, fin.readline().split())
f = True
a = [[] for i in range(n)]
for c in range(m):
    i, j = map(int, fin.readline().split())
    a[i - 1].append(j - 1)
c = []
used = [False] * n


def dfs(v, p):
    global f
    used[v] = True
    for i in range(n):
        if i in a[v]:
            if not used[i]:
                dfs(i, p)
            if i == p:
                f = False
                exit
    c.append(v + 1)


print(c)
for i in range(n):
    if not used[i]:
        print(dfs(i, i))
if not f:
    fout.write(str(-1))
else:
    for i in range(n - 1, -1, -1):
        fout.write(str(c[i]) + ' ')
fin.close()
fout.close()
