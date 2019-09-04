fin = open('binary.in', 'r')
fout = open('binary.out', 'w')
n = int(input())
a = [[(0) for i in range(n + 1)] for j in range(36)]
a[0][0] = 1
if n == 1:
    print(2)
else:
    for i in range(n + 1):
        for j in range(3):
            if j != 0:
                a[i][j] = a[i - 1][j - 1]
            elif i != 0:
                a[i][j] = sum(a[i - 1])
    print(sum(a[n]))
