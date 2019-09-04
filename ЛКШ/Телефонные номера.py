fin = open('tele.in', 'r')
fout = open('tele.out', 'w')
n, k = map(int, fin.readline().split())
a = [[0] * (k + 1) for i in range(n + 1)]
for i in range(k + 1):
    if i < 10:
        a[1][i] = 1
for i in range(2, n + 1):
    for j in range(k + 1):
        q = j
        while q > -1 and q > j - 10:
            a[i][j] += a[i - 1][q]
            q -= 1
fout.write(str(a[n][k]) + '\n')
fin.close()
fout.close()
