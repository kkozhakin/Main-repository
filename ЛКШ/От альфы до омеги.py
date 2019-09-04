w = list(map(int, input().split()))
a = w[0]
b = w[1]

print(a)


def ss(s):
    if s == b:
        exit
    else:
        print(s + 1)
        ss(s + 1)

ss(a)
