fin = open('hemoglobin.in.txt', 'r')
fout = open('hemoglobin.out.txt', 'w')
n = int(fin.readline().strip())
pr = [0]
m = 0
l = []
for i in range(n):
    s = fin.readline().strip()
    if s[0] == '+':
        q = int(s[1:])
        l.append(q)
        m += 1
        if pr:
            pr.append(pr[-1] + q)
        else:
            pr.append(q)
    elif s == '-':
        fout.write(str(l.pop()) + '\n')
        m -= 1
        pr.pop()
    else:
        s = int(s[1:])
        fout.write(str(pr[-1] - pr[m - s]) + '\n')
fin.close()
fout.close()
