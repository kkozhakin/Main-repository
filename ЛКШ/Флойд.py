fin = open('floyd.in', 'r')
fout = open('floyd.out', 'w')
n = int(fin.readline())
d = [list(map(int, fin.readline().strip().split())) for j in range(n)]
for k in range(n):
    for i in range(n):
        for j in range(n):
            if d[i][j] > d[i][k] + d[k][j]:
                d[i][j] = d[i][k] + d[k][j]
for i in range(n):
    fout.write(' '.join(map(str, d[i])) + '\n')
fin.close()
fout.close()
