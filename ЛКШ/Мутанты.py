n = int(input())
a = [int(i) for i in input().split()]
k = int(input())
b = [int(i) for i in input().split()]


def floor(w):
    r = n
    l = -1
    while (r - l) > 1:
        m = (r + l) // 2
        if a[m] >= w:
            r = m
        else:
            l = m
    if (-1 < r < n) and (a[r] == w):
        return r           
    else:
        return -1  
            
        
def ceil(w):
    r = n
    l = -1
    while (r - l) > 1:
        m = (r + l) // 2
        if a[m] > w:
            r = m
        else:
            l = m      
    if a[l] == w:
        return r           
    else:
        return -1 
    

for i in b:
    if floor(i) != -1:
        print(ceil(i) - floor(i))
    else:
        print('0')
