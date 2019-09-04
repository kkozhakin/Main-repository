n, m = list(map(int, input().split()))
a = [[(0) for i in range(m)] for j in range(n)]
a[0][0] = 1
for i in range(n):
    for j in range(m):
        if i >= 2 and j >= 2:
            a[i][j] = a[i - 1][j - 2] + a[i - 2][j - 1]
        elif i >= 2 and j == 1:
            a[i][j] = a[i - 2][j - 1]
        elif i == 1 and j >= 2:
            a[i][j] = a[i - 1][j - 2]
print(a[-1][-1])
