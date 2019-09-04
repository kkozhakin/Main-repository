fin = open('frequency.in', 'r')
fout = open('frequency.out', 'w')
s = fin.readlines()
d = dict()
for i in s:
    i = i.rstrip().split()
    if len(i) > 1:
        for j in i:
            if j in d:
                d[j] += 1
            else:
                d[j] = 1
    elif i[0] in d:
        d[i[0]] += 1
    else:
        d[i[0]] = 1
a = [[0, 0] for i in range(len(d))]
l = list(d.items())
for i in range(len(l)):
    a[i][0], a[i][1] = l[i][1], l[i][0]
a.sort()
for i in a:
    fout.write(i[1] + '\n')
fin.close()
fout.close()