s = input()
f = True
c = len(s)
for i in range(len(s) - 1):
    if s[i] == s[i + 1] == 'b':
        f = False
for i in range(len(s) * 2):
    s = s + str(i)
for i in range(1, c // 3 + 1):
    for j in range(0, c + 1):
        if s[j: i + j] == s[i + j: i * 2 + j] == s[i * 2 + j: i * 3 + j]:
            f = False
if f:
    print('YES')
else:
    print('NO')
