fin = open('components.in', 'r')
fout = open('components.out', 'w')
n = int(fin.readline())
a = [[0 for i in range(n)] for j in range(n)]
for i in range(n):
    a[i] = list(map(int, fin.readline().split()))
color = [0] * (n + 1)


def dfs(v):
    color[v] = 1
    for i in range(n):
        if not color[i] and a[v][i]:
            dfs(i)


c = 0
for i in range(n):
    if not color[i]:
        dfs(i)
        c += 1
fout.write(str(c))
fin.close()
fout.close()