fin = open('dictionary.in', 'r')
fout = open('dictionary.out', 'w')
f = fin.readlines()
d = dict()
s = set()
for i in f:
    a = i.rstrip().split(' - ')
    b = a[1].split(', ')
    s.update(b)
for j in s:
    d[j] = []
for i in f:
    a = i.rstrip().split(' - ')
    b = a[1].split(', ')
    for j in b:
        d[j].append(a[0])
fout.write(str(len(s)) + '\n')
for j in sorted(s):
    fout.write(j + ' - ' + ', '.join(d[j]) + '\n')
fin.close()
fout.close()