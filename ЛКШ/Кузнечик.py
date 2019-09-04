n, k = map(int, input().split())
a = [0] * (n + k)
a[0] = 1
for i in range(n):
    for j in range(1, k + 1):
        a[i] += a[i - j]
print(a[-1])
