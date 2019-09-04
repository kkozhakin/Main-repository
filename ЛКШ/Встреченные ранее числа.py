fin = open('metbefore.in', 'r')
fout = open('metbefore.out', 'w')
l = list(map(int, fin.readline().split()))
a = set()
for i in range(len(l)):
    if l[i] not in a:
        fout.write('NO' + '\n')
        a.add(l[i])
    else:
        fout.write('YES' + '\n')
fin.close()
fout.close()
