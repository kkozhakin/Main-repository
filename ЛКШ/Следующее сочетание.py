fin = open('nextcomb.in', 'r')
fout = open('nextcomb.out', 'w')
k, n = map(int, fin.readline().split())
a = list(map(int, fin.readline().split()))
t = False
for i in range(n - 1, -1, -1):
    if a[i] != k:
        a[i] += 1
        t = True
        for j in range(i + 1, n):
            a[j] = a[j - 1] + 1
        break
    k -= 1
if not t:
    fout.write('0')
else:
    fout.write(' '.join(map(str, a)))
fin.close()
fout.close()
            
