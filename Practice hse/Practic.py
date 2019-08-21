
# coding: utf-8

# In[240]:


import numpy as np


# In[319]:


class Literature():
    count = 1
    
    def __init__(self, name, year=0):
        self.name = name
        self._year = year
    
    def __str__(self):
        return self.name +' '+ str(self._year)+' '+ str(self.count)+' '


# In[320]:


class Book(Literature):
    _authors = ''
    _publish = ''
    
    def __init__(self, name, authors, year, publish):
            super().__init__(name, year)
            self._publish = publish
            self._authors = authors

    def __str__(self):
        return super().__str__() + self._publish + ' ' + self._authors


# In[321]:


class Library():
    items = []
    users = []
    
    def _check(self, name, itype):
        for i in range(len(self.items)):
            if name == self.items[i].name and itype == type(self.items[i]):
                return (True, i)
        return (False, -1)
    
    def Add(self, x):
        t = self._check(x.name, type(x))
        if t[0]:
            self.items[t[1]].count += 1
        else:
            self.items.append(x)
    
    def Pop(self, i):
        if len(self.items) > i: 
            self.items[i].count -= 1
            if self.items[i].count == 0:
                del self.items[i]
                
    def Use(self, x):
        t = self._check(x.name, type(x))
        if t[0]:
            self.items[t[1]].count -= 1
            if self.items[t[1]].count == 0:
                del self.items[t[1]]
            c = -1
            for i in range(len(self.users)):
                if x.name == self.users[i].name and type(x) == type(self.users[i]):
                    self.users[i].count += 1
                    c = i
                    break
            if c == len(self.users) - 1:
                x.count = 1
                self.users.append(x)
        else:
            print("Not found!")
    
    def Reuse(self, x):
        c = -1
        for i in range(len(self.users)):
            if x.name == self.users[i].name and type(x) == type(self.users[i]):
                    self.users[i].count -= 1
                    c = i
                    break
        if c == -1:
            print('Not found!')
        else:
            if self.users[i].count == 0:
                del self.users[i]
            t = self._check(x.name, type(x))
            if t[0]:
                self.items[t[1]].count += 1
            else:
                x.count = 1
                self.items.append(x)
    
    def __str__(self):
        s = 'Library: ' + '\n'
        for i in self.items:
            s += str(i) + '\n'
        s += 'Using books: ' + '\n'
        for i in self.users:
            s += str(i) + '\n'
        return s


# In[322]:


class Magazine(Literature): 
    
    def __init__(self, name, year, publish = 0):
        super().__init__(name, year)
        self._publish = publish
    
    def __str__(self):
        return super().__str__() + str(self._publish)


# In[323]:


class CD():
    count = 0
    
    def __init__(self, name, cdformat='', adress=None):
            self.name = name
            self._format = cdformat
            self.count = 1
            self._adress = adress
    
    def __str__(self):
        return self.name+' '+ self._format+' '+ str(self.count)+' '+ self._adress


# In[324]:


q = Library()
q.items


# In[325]:


b = Book('a','b',1999,'e')
q.Add(b)
q.Add(Book('t','c',2000,'3'))
q.Add(CD('t','d','q'))


# In[326]:


print(q)


# In[327]:


q.Pop(2)


# In[328]:


print(q)


# In[329]:


q.Use(b)


# In[330]:


print(q)


# In[331]:


q.Reuse(b)


# In[332]:


print(q)


# In[335]:


n = int(input()) 
l = [] 
for i in range(1, n + 1): 
	user = (name, year, points) = eval(input()) 
	l.append(user) 
	l.sort(key=lambda i: i[1], reverse=1) 
for i in range(n): 
	for j in range(i, n): 
		if(l[i][1] == l[j][1]): 
			if(l[j][2] < l[i][2]): 
				l[j], l[i] = l[i], l[j] 
for i in range(n): 
	for j in range(i, n): 
		if(l[i][1] == l[j][1] and l[i][2] == l[j][2]): 
			if(l[j][0] < l[i][0]): 
				l[i], l[j] = l[j], l[i] 
for i in l: 
	print(i)

