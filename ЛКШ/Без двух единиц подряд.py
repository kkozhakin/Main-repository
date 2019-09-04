fin = open('fibseq.in', 'r')
fout = open('fibseq.out', 'w')
n = int(fin.readline())


def gen(c, pr = []):
    if c == 0:
        s = ''
        for i in pr:
            s = s + str(i) + ' '
        fout.write(s + '\n')
    else:
        if (len(pr) > 0) and (pr[-1] == 1):
            pr.append(0)
            gen(c - 1, pr)
            pr.pop()
        else:
            for i in range(2):
                pr.append(i)
                gen(c - 1, pr)
                pr.pop()
            

gen(n)
fin.close()
fout.close()