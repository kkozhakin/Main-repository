fin = open('crazycalc.in', 'r')
fout = open('crazycalc.out', 'w')
s, f = map(int, fin.readline().split())
q = [s]
n = 10000
used = [0] * n


def bfs(num):
    used[num] = 1
    h = 0
    t = 1
    while h < t:
        u = q[h]
        h += 1
        m = sum(map(int, list(str(u))))
        if (u * 3 < n) and not used[u * 3]:
            q.append(u * 3)
            used[u * 3] = used[u] + 1
            t += 1
        if (u + m < n) and not used[u + m]:
            q.append(u + m)
            used[u + m] = used[u] + 1
            t += 1
        if (u - 2 > 0) and not used[u - 2]:
            q.append(u - 2)
            used[u - 2] = used[u] + 1
            t += 1


bfs(s)
fout.write(str(used[f] - 1))
fin.close()
fout.close()