a = int(input())
w = list(map(int, input().split()))
w.sort()
print(w[-a])