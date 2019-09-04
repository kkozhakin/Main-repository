from math import factorial as fact

fin = open('bynumber.in', 'r')
fout = open('bynumber.out', 'w')
n = int(fin.readline())
c = int(fin.readline())
a = [i for i in range(n)]
l = []
for i in range(n):
    for j in range(n):
        f = fact(n - i - 1) * j
        if f > c:
            l.append(a[j - 1] + 1)
            a.pop(j - 1)
            c -= fact(n - i - 1) * (j - 1)
            break
        elif j == (n - 1):
            l.append(a[j] + 1)
            a.pop(j)
            c -= f
            break 
fout.write(' '.join(map(str, l)))
fin.close()
fout.close()
