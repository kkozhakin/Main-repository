a = input().split()
n = a[0]
k1 = a[1]
a = []
n = int(n)
k1 = int(k1)
for i in range(n):
    a.append(int(input()))
l = -1
r = 1000000000


def f(l1):
    k = 0
    for i in range(n):
        k = k + a[i] // l1
    return k


if sum(a) > k1:
    while r - l > 1:
        c = (r + l) // 2
        if f(c) >= k1:
            l = c
        else:
            r = c
    print(l)
else:
    print(0)
