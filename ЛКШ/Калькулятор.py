inf = 1 << 150
n = int(input())
a = [-1] * (n + 1)
dp = [inf] * (n + 1)
dp[1] = 0
a[1] = 0
for i in range(n):
    if dp[i] != inf:
        if dp[i + 1] > dp[i] + 1:
            dp[i + 1] = dp[i] + 1
            a[i + 1] = i
        if (i * 2 <= n) and (dp[i * 2] > dp[i] + 1):
            dp[i * 2] = dp[i] + 1
            a[i * 2] = i
        if (i * 3 <= n) and (dp[i * 3] > dp[i] + 1):
            dp[i * 3] = dp[i] + 1
            a[i * 3] = i
b = []
print(dp[n])
while n != 0:
    b.append(n)
    n = a[n]
for i in b[::-1]:
    print(i, end = ' ')
