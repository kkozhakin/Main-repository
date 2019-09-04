n = int(input())
c = []
for i in range(n):
    a = list(map(int, input().split()))
    c.append([a[0] * 60 + a[1], a[2]])
line = 1
t = c[0][0]
c[0][0] += 20
for i in range(1, n):
    while c[i][0] >= t + 20 and line > 0:
        t += 20
        line -= 1
    if line == 0:
        t = c[i][0]
        line += 1
        c[i][0] += 20
    elif line <= c[i][1]:
        last = c[i][0] - t
        c[i][0] += line * 20
        c[i][0] += 20 - last
        line += 1
for i in range(n):
    h = c[i][0] // 60
    m = c[i][0] - h * 60
    print(h, m)