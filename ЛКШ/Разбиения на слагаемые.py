fin = open('partition.in', 'r')
fout = open('partition.out', 'w')
n = int(fin.readline())


def fp(n, k):
    if n == 0:
        yield []
    else:
        for i in range(1, min(n + 1, k + 1)):
            for j in fp(n - i, i):
                yield [i] + j


for i in fp(n, n):
    print(*i, file = fout)
fin.close()
fout.close()
