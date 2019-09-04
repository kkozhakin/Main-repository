n = int(input())
s = [int(i) for i in input().split()]
l = []
for i in range(1, n + 1):
    l.append((s[i - 1], i))
for i in range(n):
    for j in range(n - 1):
        if l[j][0] > l[j + 1][0]:
            l[j], l[j + 1] = l[j + 1], l[j]
for i in l[:: -1]:
    print(i[1], end = ' ')