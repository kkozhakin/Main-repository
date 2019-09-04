fin = open('eqsubstr.in', 'r')
fout = open('eqsubstr.out', 'w')


def hash(i, j):
    return (h[j] - h[i - 1] * (p[j - i + 1])) % m
    

x = 13
m = (10 ** 9) + 7
s = fin.readline()
n = int(fin.readline())
h = [0] * (len(s) + 1)
p = [x] * (len(s) + 1)
for i in range(2, len(s) + 1):
    p[i] = (p[i] * p[i - 1]) % m
for i in range(len(s)):
    h[i + 1] = (h[i] * x + ord(s[i])) % m
for i in range(n):
    l1, r1, l2, r2 = map(int, fin.readline().split())
    if hash(l1, r1) == hash(l2, r2):
        fout.write('+')
    else:
        fout.write('-')
fin.close()
fout.close()