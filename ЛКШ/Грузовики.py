a = input().split()
n = int(a[0])
k = int(a[1])


def f(a):
        if a <= k:
                return 1
        return f(a // 2) + f((a + 1) // 2)


print(f(n))
