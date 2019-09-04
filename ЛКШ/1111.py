fin = open('dominoes.in', 'r')
fout = open('dominoes.out', 'w')
n = int(fin.readline())
a = []
for i in range(n - 1):
    a.append(fin.readline())
    a[i] = a[i][: len(a[i]) - 1]
a.append(fin.readline())
c = 0
for i in range(n):
    for j in range(i + 1, n):
        if (a[i] == a[j] or a[i][:: -1] == a[j]):
            c += 1
        elif (a[i][0] == a[j][0] or a[i][0] == a[j][2] or
            a[i][2] == a[j][0] or a[i][2] == a[j][2]):
            c += 1
fout.write(str(c))