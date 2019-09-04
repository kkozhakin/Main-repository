fin = open('bipartite.in', 'r')
fout = open('bipartite.out', 'w')
n, m = map(int, fin.readline().split())
a = [[] for i in range(n + 1)]
for i in range(m):
    b, c = map(int, fin.readline().split())
    a[b].append(c)
    a[c].append(b)
color = [0] * (n + 1)


def dfs(k):
    f = False
    for v in a[k]:
        if color[v] == color[k]:
            return True
        elif not color[v]:
            color[v] = 3 - color[k]
            dfs(v)
            if not f:
                f = dfs(v)
    return f

for i in range(1, n + 1):
    if not color[i]:
        color[i] = 1
        if dfs(i):   
            fout.write('NO')
            break
else:
    fout.write('YES')
fin.close()
fout.close()