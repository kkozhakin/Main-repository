fin = open('photographer.in', 'r')
fout = open('photographer.out', 'w')
n = int(fin.readline().strip())
m = 10 ** 9 + 7
dp = [0] * (n + 4)
dp[1] = 1
dp[2] = 1
dp[3] = 2
for i in range(4, n + 1):
    dp[i] = ((dp[i - 3] + dp[i - 1] + 1)) % m
fout.write(str(dp[n]))
fin.close()
fout.close()
