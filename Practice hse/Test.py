
# coding: utf-8

# In[14]:


from math import factorial
def C(n, k):
    s = 1
    for i in range(n-k+1, n+1):
        s*=i    
    return s/factorial(k)
a,b = map(int, input().split())

if (a >= 0 and b >= 0 and a >= b):
    print(int(C(a,b)))
else:
    print('ERROR')


# In[20]:


l = list(map(int, input().split()))
s = sum(l)/len(l)
g = 1
for i in l:
	g *= i
print('%.3f' % s, '%.3f' % g**(1/len(l)))


# In[28]:


n = int(input())
l = []
for i in range(n):
    l.append(tuple(input().split(', ')))
for j in range(0, n):
    for i in range(1,n):
        if l[i][1] > l[i-1][1]:
            l[i], l[i-1] = l[i-1], l[i]
        elif l[i][1] == l[i-1][1]:
            if l[i][2] < l[i-1][2]:
                l[i], l[i-1] = l[i-1], l[i]
        elif l[i][2] == l[i-1][2]:
            if l[i][0] < l[i-1][0]:
                l[i], l[i-1] = l[i-1], l[i]
for i in l:
    print(', '.join(i))


# In[27]:


from math import sin

def a(n):
    return sin(1/n)/n**-1

def b(n):
    return (1 + 1/n)**n

e = int(input())
nextt = a(1)
d = 1
i = 2
while d > 10**(-e):
    prev = nextt
    nextt = a(i)
    i += 1
    d = nextt - prev
print(format(a(i-1), '.'+str(e)+'f'), i-1)
nextt = b(1)
d = 1
i = 2
while d > 10**(-e):
    prev = nextt
    nextt = b(i)
    i += 1
    d = nextt - prev
print(format(b(i - 1), '.'+str(e)+'f'), i-1)


# In[7]:


with open('input.txt', 'r') as f:
    m, n = map(int, f.read().split())
if m > 2:
    matrix = [[str((i+j+1) % 2) for j in range(n)] for i in range(2)]
    with open('output.txt', 'w') as f:
        while m >= 2:
            f.write('\n'.join(' '.join(ln) for ln in matrix) + '\n')
            m -= 2
        if m == 1:
            f.write(' '.join(matrix[0]))
else:
    matrix = [[str((i+j+1) % 2) for j in range(n)] for i in range(m)]
    with open('output.txt', 'w') as f:
        f.write('\n'.join(' '.join(ln) for ln in matrix))


# In[82]:


from math import factorial
def C(n, k):
    s = 1
    for i in range(n-k+1, n+1):
        s*=i    
    return s/factorial(k)
a = int(input())
for i in range(a+1):
    s = ''
    for j in range(i+1):
        s += str(int(C(i,j))) + ' '
    print(s)


# In[95]:


def fib(n):
    a = 0
    b = 1
    with open('output.txt','w') as f:
        for i in range(n):
            a, b = b, a + b
            if i == n - 1:
                f.write(str(a))
            else:
                f.write(str(a) + ' ')

with open('input.txt','r') as f:
    fib(int(f.read()))


# In[59]:


with open('input.txt', 'r') as f:
    n, m = map(int, f.read().split())
q = 2

with open('output.txt', 'w') as f:
    for i in range(n):
        l = ['1']*m
        for j in range(m - 1, -1, -1):
            if (i + j) % 2 != 0:
                l[j] = str(q)
                q += 1
        if i != n - 1:
            f.write('\t'.join(l) + '\n')
        else:
            f.write('\t'.join(l))


# In[42]:


l = [[]]
with open('input.txt', 'r') as f:
    l = [list(map(int, line.split())) for line in f]
q = []
for i in range(len(l)):    
    for j in range(len(l[0])):
        n = 0
        s = 0
        if (l[i][j] == 0):
            q.append((i, j))
            if i != 0:
                n += 1
                if (i - 1, j) not in q:
                    s += l[i-1][j]
            if i != len(l) - 1:
                n += 1
                if (i + 1, j) not in q:
                    s += l[i + 1][j]
            if j != 0:
                n += 1
                if (i, j - 1) not in q:
                    s += l[i][j - 1]
            if j != len(l[0]) - 1:
                n += 1
                if (i, j + 1) not in q:
                    s += l[i][j + 1]
            if n != 0:
                l[i][j] = s/n
l = [[('%.3f' % l[j][i]) for i in range(len(l[0]))] for j in range(len(l))]
with open('output.txt', 'w') as f:
	f.write('\n'.join(' '.join(ln) for ln in l))

