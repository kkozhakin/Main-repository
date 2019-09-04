n = int(input())
m = list(map(int, input().split()))
c = list(map(int, input().split()))
dp = [[0 for i in range(n + 5)] for j in range(len(m) + 5)]
l = [[0 for i in range(n + 5)] for j in range(len(m) + 5)]
for i in range(1, len(m) + 1):
    for j in range(1, n + 1):
        if j - m[i - 1] >= 0:
            dp[i][j] = max(dp[i - 1][j], dp[i - 1][j - m[i - 1]] + c[i - 1])
        else:
            dp[i][j] = dp[i - 1][j]
a = len(m)
b = n
l1 = []
for i in range(len(m) - 1, - 1, - 1):
    if (b - m[i] >= 0) and (dp[a][b] == dp[a - 1][b - m[i]] + c[i]) and (dp[a][b] > dp[a - 1][b]):
        l1.append(i + 1)
        b -= m[i]
    a -= 1
for i in l1:
    print(i)
