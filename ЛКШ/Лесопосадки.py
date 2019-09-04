fin = open('tree.in', 'r')
fout = open('tree.out', 'w')
n = int(fin.readline().strip())
c = 0
a = [[0 for i in range(n)] for j in range(n)]
for i in range(n):
    a[i] = list(map(int, fin.readline().split()))
    c += a[i].count(1)
color = [0] * (n + 1)


def dfs(v):
    color[v] = 1
    for i in range(n):
        if not color[i] and a[v][i]:
            dfs(i)


dfs(0)
if ((c / 2) == (n - 1)) and (color.count(1) == n):
    fout.write('YES')
else:
    fout.write('NO')
fin.close()
fout.close()
