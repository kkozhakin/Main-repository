fin = open('details.in', 'r')
fout = open('details.out', 'w')
a = [int(i) for i in fin.readline().split()]
b = [[] for i in range(len(a) + 1)]
for i in range(1, len(a) + 1):
    f = fin.readline()
    if f:
        b[i] = list(map(int, f.split()))
q = []
used = [0] * (len(a) + 1)


def bfs(k):
    l = 0
    h = 0
    t = 0
    used[k] = 1
    q.append(k)
    t += 1
    while h < t:
        v = q[h]
        h += 1
        for i in b[v]:
            if not used[i]:
                used[i] = used[v] + 1
                q.append(i)
                t += 1
                l += a[i - 1]
    return(l)


fout.write(str(bfs(1) + a[0]))
fin.close()
fout.close()