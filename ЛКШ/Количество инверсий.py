n = int(input())
a = [int(i) for i in input().split()]
c = 0
l = []


def merge(l1, l2):
    global c
    u = r = t = 0
    l = []
    while r != len(l1) or t != len(l2):
        if r == len(l1):
            l.append(l2[t])
            t += 1
        elif t == len(l2):
            l.append(l1[r])
            while u < len(l2) and l2[u] < l1[r]:
                u += 1
            c += u
            r += 1
        elif l1[r] > l2[t]:
            l.append(l2[t])
            t += 1
        else:
            l.append(l1[r])
            while u < len(l2) and l2[u] < l1[r]:
                u += 1
            c += u
            r = r + 1
    return l


def mergesort(l):
    if len(l) < 2:
        return l
    else:
        l1, l2 = l[: len(l) // 2], l[len(l) // 2:]
        l1 = mergesort(l1)
        l2 = mergesort(l2)
        l = merge(l1, l2)
        return l

    
l = mergesort(a)
print(c)
