n = int(input())
l = [int(n) for n in
    input().split()]
n1 = int(input())
l1 = [int(n1) for n1 in
    input().split()]


def binsearch(x):
    lt = -1
    r = n
    while r - lt > 1:
        c = (lt + r) // 2
        if l[c] < x:
            lt = c
        else:
            r = c
    if (r < n and r >= 0 and l[r] == x):
        print('YES')
    else:
        print('NO')


for j in range(n1):
    binsearch(l1[j])
