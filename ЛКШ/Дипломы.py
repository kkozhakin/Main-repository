a = input().split()
w = int(a[0])
h = int(a[1])
n = int(a[2])
l = -1
if h > w:
    r = h * n
else:
    r = w * n
while r - l > 1:
    c = (r + l) // 2
    if ((c // w) * (c // h)) < n:
        l = c
    else:
        r = c
print(r)
