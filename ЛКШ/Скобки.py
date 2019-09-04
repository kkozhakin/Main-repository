n = input()
a = []
q = True
for i in n:
    if (i == '(' or i == '[' or i == '{'):
        a.append(i)
    else:
        if (not a == []) and (a[-1] == '(' and i == ')' or
            a[-1] == '[' and i == ']' or
            a[-1] == '{' and i == '}'):
            a.pop()
        else:
            q = False
if (q and a == []):
    print('YES')
else:
    print('NO')
