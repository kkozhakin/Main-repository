b = list(map(int, input().split()))
dp = [(1) for i in range(len(b))]
for i in range(len(b)):
    for j in range(i):
        if b[i] % b[j] == 0 and  dp[i] <= dp[j]:
            dp[i] = dp[j] + 1
print(max(dp))
