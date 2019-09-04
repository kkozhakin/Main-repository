a = input().split()
l = [int(i) for i in input().split()]
c = len(a)
for i in l[:: -1]:
    for j in a[i: c]:
        print (j, end = ' ')
    c = i
for i in a[0: c]:
    print (i, end = ' ')