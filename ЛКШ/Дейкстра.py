fin = open('input.txt', 'r')
fout = open('output.txt', 'w')
INF = float('inf')
n, s, f = map(int, fin.readline().split())
used = [False] * n
d = [INF] * (n + 1)
d[s - 1] = 0
a = [[] for i in range(n)]
for i in range(n):
    a[i] = list(map(int, fin.readline().split()))
for i in range(n):
    m = -1
    for j in range(n):
        if (d[m] > d[j]) and not used[j]:
            m = j  
    used[m] = True
    for j in range(n):
        if (a[m][j] != - 1) and (d[m] + a[m][j] < d[j]):
            d[j] = d[m] + a[m][j]
if d[f - 1] != INF:
    fout.write(str(d[f - 1]))
else:
    fout.write('-1')
fin.close()
fout.close()
