fin = open('lcs.in.txt', 'r')
fout = open('lcs.out.txt', 'w')
e = int(fin.readline())
a = list(map(int, fin.readline().split()))
f = int(fin.readline())
b = list(map(int, fin.readline().split()))
dp = [[(0) for i in range(f + 1)] for j in range(e + 1)]
mem = []
cout = 0
for i in range(e):
    for j in range(f):
        if a[i] == b[j]:
            dp[i][j] = dp[i - 1][j - 1] + 1
            if cout < dp[i][j]:
                cout += 1
                mem.append(a[j])
        else:
            dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])
#cont = dp[-2][-2]
#while cont != 0:
#   if a[i] == b[j]:
#        mem.append(a[i])
#        cont -= 1
#        i -= 1
#        j -= 1
#    elif dp[i - 1][j] > dp[i][j - 1]:
#        i -= 1
#    else:
#        j -= 1

for i in range(len(mem)):
    fout.write(str(mem[-i - 1]) + ' ')