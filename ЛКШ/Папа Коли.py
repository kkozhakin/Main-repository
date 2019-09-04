import sys
sys.setrecursionlimit(10 ** 6)
fin = open('father.in', 'r')
fout = open('father.out', 'w')
n = int(fin.readline())
a = [[] for i in range(n + 1)]
if n != 1:
    b = list(map(int, fin.readline().split()))
for i in range(n - 1):
    a[b[i]].append(i + 2)
cnt = [0 for i in range(n + 1)]


def dfs(v, p):
    global cnt
    for i in a[v]:
        dfs(i, v)
        cnt[v] = cnt[v] + cnt[i] + 1


dfs(1, 0)
fout.write(' '.join(map(str, cnt[1:])))
fin.close()
fout.close()