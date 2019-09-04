fin = open('numbers.in', 'r')
fout = open('numbers.out', 'w')
n, k = map(int, fin.readline().split())


def gen(c, pr = []):
    if c == 0:
        s = ''
        for i in pr:
            s = s + str(i) + ' '
        fout.write(s + '\n')
    else:
        for i in range(k):
            pr.append(i)
            gen(c - 1, pr) 
            pr.pop()

                                
gen(n)
fin.close()
fout.close()