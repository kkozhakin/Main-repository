fin = open('wishbox.in', 'r')
fout = open('wishbox.out', 'w')
k, n = map(int, fin.readline().strip().split())


def gen(n, k, m = 0, pr = [], s = set()):
    if n == 0:
        if m == k:
            fout.write(' '.join(map(str, pr)) + '\n')
        return
    else:
        if k - m <= n:
            for i in range(1, k + 1):
                pr.append(i)
                if i in s:
                    f = True
                else:
                    f = False
                    m += 1 
                s.add(i)
                gen(n - 1, k, m, pr, s)
                if not f:
                    m -= 1
                    s.discard(i)
                pr.pop()


gen(n, k)
fin.close()
fout.close()
