fin = open('parentheses.in', 'r')
fout = open('parentheses.out', 'w')
n = int(fin.readline()) * 2


def gen(n, balanc = 1, prefix = ['(']):
    if n == 0:
        for i in prefix:
            fout.write(str(i))
        fout.write('\n')
    else:
        if n > balanc:
            gen(n - 1, balanc + 1, prefix + ['('])
        if balanc > 0:
            gen(n - 1, balanc - 1, prefix + [')'])


gen(n)
fin.close()
fout.close()
