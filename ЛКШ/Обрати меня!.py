fin = open('reverse.in', 'r')
fout = open('reverse.out', 'w')
n = int(fin.readline())
l = [[] for i in range(n + 1)]
for i in range(1, n + 1):
    s = fin.readline()
    if s:
        for j in [int(q) for q in s.split()]:
            l[j].append(i)
fout.write(str(n) + '\n')
for i in l:
    if i:
        fout.write(' '.join(map(str, i)) + '\n')
fin.close()
fout.close()
