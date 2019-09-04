n, m = map(int, input().split())
dp = [[0 for i in range(m + 5)] for j in range(n + 5)]
dp[3][2] = 1
dp[2][3] = 1


def hor(a, b):
    while (a <= n) and (b >= 1):
        if dp[a][b] != 0:
            dp[a + 1][b + 2] += dp[a][b]
            dp[a - 1][b + 2] += dp[a][b]
            dp[a + 2][b - 1] += dp[a][b]
            dp[a + 2][b + 1] += dp[a][b]
        a += 1
        b -= 1


for j in range(1, m + 1):
    hor(1, j)
for i in range(2, n + 1):
    hor(i, m)
print(dp[n][m])
