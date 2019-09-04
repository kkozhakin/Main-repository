fin = open('mindist.in', 'r')
fout = open('mindist.out', 'w')
n, m = map(int, fin.readline().split())
a = [[0 for i in range(n)] for j in range(n)]
for i in range(n):
    a[i] = list(map(int, fin.readline().split()))
q = [m - 1]
used = [0] * n


def bfs(c):
    used[c] = 1
    h = 0
    t = 1
    while h < t:
        u = q[h]
        h += 1
        for v in range(n):
            if a[u][v] and not used[v]:
                q.append(v)
                used[v] = used[u] + 1
                t += 1


bfs(m - 1)
for i in used:
    fout.write(str(i - 1) + ' ')
fin.close()
fout.close()
