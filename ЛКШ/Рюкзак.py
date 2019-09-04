fin = open('gold.in', 'r')
fout = open('gold.out', 'w')
m, n = map(int, fin.readline().split())
b = list(map(int, fin.readline().split()))
dp = [[0 for i in range(n + 1)] for j in range(m + 1)]
for i in range(m):
    for j in range(n + 1):
        if (j >= b[i]) and (dp[i - 1][j - b[i]] + b[i] > dp[i - 1][j]):
            dp[i][j] = dp[i - 1][j - b[i]] + b[i]
        else:
            dp[i][j] = dp[i - 1][j]
fout.write(str(dp[m - 1][n]))