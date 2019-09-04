inf = 1 << 150
n, m = map(int, input().split())
dp = [list(map(int, input().split())) + [inf] for x in range(n)] + [[inf] * (m + 1)]
a = [[[-1, -1] for i in range(m)] for j in range(n)]
for i in range(n):
    for j in range(m):
        if i == j == 0:
            continue
        if dp[i][j - 1] > dp[i - 1][j]:
            dp[i][j] += dp[i - 1][j]
            a[i][j] = (i - 1, j)
        else:
            dp[i][j] += dp[i][j - 1]
            a[i][j] = (i, j - 1)
print(dp[n - 1][m - 1])
print(n + m - 1)
p = []
i = n - 1
j = m - 1
while not (i == j == -1):
    p.append((i + 1, j + 1))
    i, j = a[i][j]
for i in p[::-1]:
    print(i[0], i[1])
