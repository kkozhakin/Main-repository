n = int(input())
dp = [[1 for j in range(10)] for i in range(n)]
for i in range(1, n):
    for j in range(1, 9):
        dp[i][j] = sum(dp[i - 1][z] for z in range(j - 1, j + 2))
    dp[i][0] = dp[i - 1][0] + dp[i - 1][1]
    dp[i][9] = dp[i - 1][9] + dp[i - 1][8]
print(sum(dp[n - 1][1::]))
