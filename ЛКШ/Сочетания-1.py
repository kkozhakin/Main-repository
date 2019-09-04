fin = open('binary.in', 'r')
fout = open('binary.out', 'w')
n, k = map(int, fin.readline().split())


def gen(n, c, pr = []):
    if (n == 0) and (c == 0):
        fout.write(''.join(map(str, pr)) + '\n')
    elif (n != 0) and (n >= c):       
            pr.append(0)
            gen(n - 1, c, pr)
            pr.pop()
            if c != 0:
                pr.append(1)
                gen(n - 1, c - 1, pr)
                pr.pop()

            
gen(n, k)
fin.close()
fout.close()