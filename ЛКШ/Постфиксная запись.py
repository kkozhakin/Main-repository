a = input().split()
s = []
for i in a:
    if i == '-':
        s[-2] = s[-2] - s[-1]
        s.pop()
    elif i == '+':
        s[-2] = s[-2] + s[-1]
        s.pop()
    elif i == '*':
        s[-2] = s[-2] * s[-1]
        s.pop()
    else:
        s.append(int(i))
print(s[0])
