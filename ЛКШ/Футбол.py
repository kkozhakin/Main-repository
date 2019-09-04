fin = open('football.in', 'r')
fout = open('football.out', 'w')
n, k = map(int, fin.readline().split())
q = 0


def gen(c, k):
    global q
    if k == 0 and c == 0:
        q += 1
        return
    elif k == 0:
        return
    if k > 0:
        gen(c, k - 1)
    if n > 0:
        gen(c - 1, k - 1)
    if c > 2:
        gen(c - 3, k - 1)


gen(n, k)
fout.write(str(q))
fin.close()
fout.close()
