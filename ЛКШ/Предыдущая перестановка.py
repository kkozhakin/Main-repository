fin = open('prev.in', 'r')
fout = open('prev.out', 'w')
t = int(fin.readline().strip())
a = list(map(int, fin.readline().strip().split()))
t -= 2
b = []
while t >= 0:
    if a[t] < a[t + 1]:
        t -= 1
    else:
        for i in range(len(a) - 1, t, -1):
            if a[i] < a[t]:
                a[t], a[i] = a[i], a[t]
                break
        b = a[t + 1: len(a)]
        b.sort()
        b = b[:: -1]
        a[t + 1: len(a)] = b
        break
if t != -1:
    for i in a:
        fout.write(str(i) + ' ')
else:
    a = a[:: -1]
    for i in a:
        fout.write(str(i) + ' ')
fin.close()
fout.close()
