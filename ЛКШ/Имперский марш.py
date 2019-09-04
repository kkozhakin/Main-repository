n = int(input())
a = [int(i) for i in input().split()]
q = 140


def minimum(c):
        q = c[0]
        for i in range(len(c)):
                if c[i] < q:
                        q = c[i]
        return q


m = minimum(a)
l = [0] * (q)
for i in range(n):
    a[i] -= m
    l[a[i]] += 1
for i in range(q):
    while l[i] != 0:
        print(i + m, end = ' ')
        l[i] -= 1
