
# coding: utf-8

# In[1]:


from math import factorial
import numpy


# In[4]:


def C(n, k):
    return factorial(n)/(factorial(k)*factorial(n-k))

print(C(int(input()), int(input())))


# In[7]:


for i in range(0,11):
    print(factorial(i))


# In[2]:


from math import sqrt
n = int(input("n="))
lst=[]
for i in range(2, n+1):
    if (i > 10):
        if (i%2==0) or (i%10==5):
            continue
    for j in lst:
        if j > int((sqrt(i)) + 1):
            lst.append(i)
            break
        if (i % j == 0):
            break
    else:
        lst.append(i)
print(lst)


# In[10]:


try:
    n = int(input())
    if n == 0:
        print('Сейчас самое время почитать о Python')
    elif (n > 0 and n <= 5):
        print('Неплохо')
    elif (n > 5):
        print('Отлично!')
    else:
        print('Некорректный ввод')
except:
    print('Некорректный ввод')


# In[11]:


from math import sqrt
n = 546
lst=[]
for i in range(2, n+1):
    if (i > 10):
        if (i%2==0) or (i%10==5):
            continue
    for j in lst:
        if j > int((sqrt(i)) + 1):
            lst.append(i)
            break
        if (i % j == 0):
            break
    else:
        lst.append(i)
        
with open('prime_numbers.txt', 'w') as f:
    f.write(','.join(map(str, lst)))


# In[12]:


len(lst)


# In[13]:


try:
    lst1 = []
    f = open('prime_numbers.txt', 'r')
    s = f.read()
    while len(lst1) < 20:  
        lst1.append(s[:s.find(',')])
        s = s[s.find(',')+1:]
finally:
    f.close()
lst1


# In[109]:


Filenames = ['my_first file','second','more','last']
for file in Filenames:
    with open(file, 'tw', encoding='utf-8') as f:
        pass


# In[110]:


def func(x,a=0,b=0,c=0):
    return a * x**2 + b * x + c

print(func(2), func(2,1,3), func(2,1,3,4))


# In[114]:


def mn(x, n=0, l=[n+1]):
    z = 0;
    for i in range(len(l)):
        z += l[i] * x**i
    return z

print(mn(int(input()), int(input()), list(map(int, input().split()))))


# In[52]:


def delsp(file):
    with open(file, 'r') as f:
        s = f.read()
        i = 0
        d = 0
        while (i >= 0 and d < len(s)):
            i = s.find(' ')
            d+=1
            if s[i + 1] in [' ',',','.',';',':']:
                s = s[:s.find(' ')] + s[s.find(' ') + 1:]
                print(s[:s.find(' ')-1], s[s.find(' ') + 1:])
    with open(file, 'w') as f:
        f.write(s)
        
delsp('my_first file')


# In[49]:


import matplotlib.pyplot as plt
def a(n):
    return (1 + 1/n)**n
x = [1,2,3,4,5,6,7,8,9,10]
y = [a(1),a(2),a(3), a(4), a(5), a(6),a(7),a(8), a(9), a(10)]
plt.plot(x,y, 'g^')
plt.show()


# In[54]:


def SimpleCountingSort(A):
    scope = max(A) + 1
    C = [0] * scope
    for x in A:
        C[x] += 1
    A[:] = []
    for number in range(scope):
        A += [number] * C[number] 

l = [1,2,3,4,5,0,4,32,7,4]
SimpleCountingSort(l)
print(l)


# In[50]:


with open('prime_numbers.txt', 'r') as f:
    s = f.read().split('.')
    n = int(input())
    s[0] = 'В этом файле находится ' + str(n) + ' простых чисел.'
    d = s[1].split(',')
    s[1] = ' '
    for i in range(n):
        if i != n-1:
            s[1] += d[i] + ','
        else:
            s[1] += d[i]
with open('prime_numbers.txt', 'w') as f:
    f.write(s[0])
    f.write(s[1])


# In[15]:


get_ipython().run_cell_magic('writefile', 'My_name_magic.py', "print('Привет,', input('Как тебя зовут? '))")


# In[ ]:


# %load My_name_magic.py
print('Привет,', input('Как тебя зовут? '))


# In[18]:


get_ipython().run_line_magic('run', 'My_name_magic.py')


# In[19]:


get_ipython().run_line_magic('history', '')


# In[31]:


get_ipython().run_line_magic('history', '-f history.txt')


# In[45]:


get_ipython().run_line_magic('matplotlib', 'inline')
# это магия!
import numpy as np
import matplotlib.pyplot as plt
X = np.linspace(-np.pi, 2*np.pi, 256, endpoint=True)
C, S = np.cos(X), np.sin(X)
plt.figure(figsize=(10, 6), dpi=80)
plt.grid(True)
#Задаем цвет, стиль и толщину линий
plt.plot(X, S/C, color="blue", linewidth=2.5, linestyle="-")
#Устанавливаем границы по осям
plt.xlim(X.min() * 1.1, X.max() * 1.1)
plt.ylim(C.min() * 1.1, C.max() * 1.1)
#Устанавливаем подписи по осям
plt.xticks([-np.pi, -np.pi/2, 0, np.pi/2, np.pi])
plt.yticks([-10, 0, +10])
#Устанавливаем изображение подписей по осям
plt.xticks([-np.pi, -np.pi/2, 0, np.pi/2, np.pi, 3* np.pi/2, 2*np.pi],[r'$-\pi$', r'$-\pi/2$', r'$0$', r'$\pi/2$', r'$\pi$', r'3$\pi$/2', r'2$\pi$'])
plt.yticks([-1, 0, +1],[r'$-1$', r'$0$', r'$+1$'])
t = np.pi / 3
plt.scatter([t, ], [np.tan(t), ], 50, color='red')
plt.annotate(r'$tan(\frac{\pi}{3})=\sqrt{3}$',
xy=(t, np.tan(t)), xycoords='data',
xytext=(+30, +30), textcoords='offset points', fontsize=16,
arrowprops=dict(arrowstyle="->", connectionstyle="arc3,rad=.2"))
t = np.pi / 4
plt.scatter([t, ], [np.tan(t), ], 50, color='green')
plt.annotate(r'$tan(\frac{\pi}{4})=1$',
xy=(t, np.tan(t)), xycoords='data',
xytext=(-60, +30), textcoords='offset points', fontsize=16,
arrowprops=dict(arrowstyle="->", connectionstyle="arc3,rad=.2"))
t = np.pi / 6
plt.scatter([t, ], [np.tan(t), ], 50, color='black')
plt.annotate(r'$tan(\frac{\pi}{6})=1/ \sqrt{3}$',
xy=(t, np.tan(t)), xycoords='data',
xytext=(-60, -50), textcoords='offset points', fontsize=16,
arrowprops=dict(arrowstyle="->", connectionstyle="arc3,rad=.2"))


# In[32]:


import numpy as np
import matplotlib.pyplot as plt
X = np.linspace(-np.pi, np.pi, 256, endpoint=True)
plt.plot(X, np.sin(X), color="blue", linewidth=2.5, linestyle="-")
plt.plot(X, np.cos(X), color="red", linewidth=2.5, linestyle="-")
plt.show()


# In[ ]:


import socket
HOST='localhost'
PORT=23235
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((HOST,PORT))
sock.send(input().encode('utf-8'))
result = sock.recv(1024)
sock.close()
print(result.decode('utf-8'))


# In[ ]:


import socket, string
HOST='localhost'
PORT=23235
srv = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
srv.bind((HOST,PORT))
l = ['Выведите 3 последних сообщения', 'Выведите все сообщения']

def do_something(x):
    y = x.decode('utf-8')
    words = y.split(' ')
    d = []
    if words[1] == 'все':
        return l
    else:
        for i in range(int(words[3]) - 1, -1, -1):
            d.append(l[i])
        return d

while 1:
    srv.listen(1)
    sock, addr = srv.accept()
    while 1:
        received = sock.recv(1024)
        l.append(received)
        if not received:
            break
        to_send = do_something(received)
        sock.send(to_send)
        print(to_send)
        sock.close()


# In[15]:


from socket import *

 

HOST = 'localhost'  # адрес хоста (сервера) пустой означает использование любого доступного адреса

PORT = 21121  # номер порта на котором работает сервер (от 0 до 65525, порты до 1024 зарезервированы для системы, порты TCP и UDP не пересекаются)

BUFSIZ = 1024  # размер буфера 1Кбайт

ADDR = (HOST, PORT)  # адрес сервера

l = []

def do_something(x):
    y = x.decode('utf-8')
    words = y.split(' ')
    d = []
    if words[1] == 'все':
        return l
    else:
        if int(words[3]) > len(l):
            for i in range(len(l) - 1, -1, -1):
                d.append(l[i])
        else:
            for i in range(int(words[3]) - 1, -1, -1):
                d.append(l[i])
        return d
 

tcpSerSock = socket(AF_INET, SOCK_STREAM)  #создаем сокет сервера

tcpSerSock.bind(ADDR)  # связываем сокет с адресом

tcpSerSock.listen(5)  # устанавливаем максимальное число клиентов одновременно обслуживаемых

 

while True:  # бесконечный цикл сервера

    print('Waiting for client...')

    tcpCliSock, addr = tcpSerSock.accept()  # ждем клиента, при соединении .accept() вернет имя сокета клиента и его адрес (создаст временный сокет tcpCliSock)

    print('Connected from: {}'.format(addr))
    
    while True:  # цикл связи

        data = tcpCliSock.recv(BUFSIZ)  # принимает данные от клиента

        if not data:

            break  # разрываем связь если данных нет
        
        l.append(data)
        
        data = do_something(data)

        tcpCliSock.send(str(data).encode('utf8'))  # отвечаем клиенту его же данными

    tcpCliSock.close()  # закрываем сеанс (сокет) с клиентом    

tcpSerSock.close()  # закрытие сокета сервера


# In[ ]:


from socket import *

 

HOST = 'localhost'  # локальный адрес localhost или 127.0.0.1

PORT = 21121  # порт на котором работает сервер

BUFSIZ = 1024

ADDR = (HOST, PORT)

 

tcpCliSock = socket(AF_INET, SOCK_STREAM)

tcpCliSock.connect(ADDR)  # установка связи с сервером

 

while True:

    data = input('>')  # ввод данных для отправки

    if not data:

        break

    tcpCliSock.send(data.encode())  # отправка данных в bytes

    data = tcpCliSock.recv(BUFSIZ)  # ожидание (получение) ответа

    if not data:

        break

    print(data.decode('utf8'))
    tcpCliSock.close()


# In[16]:


get_ipython().run_line_magic('matplotlib', 'inline')
import matplotlib.pyplot as plt
plt.rcParams['figure.figsize'] = 5, 5
import numpy as np
n = 70000
x1 = []
y1 = []
x2 = []
y2 = []
x3 = []
y3 = []
x4 = []
y4 = []
x5 = []
y5 = []
x6 = []
y6 = []
x7 = []
y7 = []
for i in range(1, n):
    x = np.random.uniform(0, 10)
    y = np.random.uniform(0, 10)
    if (((x>4)and(x<6))and ((y>4)and(y<6))):
        x1.append(x)
        y1.append(y)
    elif(((x>3.5)and(x<6.5))and ((y>3.5)and(y<6.5))):
        x2.append(x)
        y2.append(y)
    elif(((x>3)and(x<7))and ((y>3)and(y<7))):
        x3.append(x)
        y3.append(y)
    elif(((x>2.5)and(x<7.5))and ((y>2.5)and(y<7.5))):
        x4.append(x)
        y4.append(y)    
    elif(((x>2)and(x<8))and ((y>2)and(y<8))):
        x5.append(x)
        y5.append(y)
    elif(((x>1.5)and(x<8.5))and ((y>1.5)and(y<8.5))):
        x6.append(x)
        y6.append(y)
        
    else:
        x7.append(x)
        y7.append(y)
plt.xlim(0 , 10)
plt.ylim(0, 10)
plt.scatter(x1,y1,s=1,c='r') 
plt.scatter(x2,y2,s=1,c='orange')
plt.scatter(x3,y3,s=1,c='y')
plt.scatter(x4,y4,s=1,c='g') 
plt.scatter(x5,y5,s=1,c='blue')
plt.scatter(x6,y6,s=1,c='lightblue')
plt.scatter(x7,y7,s=1,c='purple') 

