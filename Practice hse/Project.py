
# coding: utf-8

# In[18]:


import numpy as np
#0 - empty
#1 - operator
#2 - table
#3 - need free, windows
#4 - case
#5 - stand
#6 - chest
#7 - wardrobs
#8 - wall case
#9 - socket
#10 - doors
#11 - computer
#12 - printer


# # Class Furniture

# In[19]:


class Furniture():
    _x, _y = -1, -1
    
    def __init__(self, length = 0, width = 0):
        self.length = length
        self.width = width
        
    def x(self):
        return self._x
    
    def y(self):
        return self._y
    
    def place(self, x, y):
        return False
    
    def _check(self,x,y,p,pos='r'):# проверяет, можно ли поставить на указанное место
        if (x < 0) or (y < 0) or (x >= np.shape(room)[1]) or (y >= np.shape(room)[2]):
            return False
        if np.size(np.shape(self.space)) < 2:
            return False
        if pos=='r' or pos=='l':
            if x + np.shape(self.space)[0] - 1 >= np.shape(room)[1]:
                return False
            if y + np.shape(self.space)[1] - 1 >= np.shape(room)[2]:
                return False
            for i in range(0, np.shape(self.space)[0]):
                for j in range(0, np.shape(self.space)[1]):
                    if p in [4,5,7]:
                        if room[0, x + i, y + j] > 0 or room[1, x + i, y + j] > 0 or room[2, x + i, y + j] > 0:
                            return False
                    elif p in [2, 6]:
                        if room[0, x + i, y + j] > 0:
                            return False
                    elif p== 8:
                        if room[2, x + i, y + j] > 0:
                            return False
        elif pos=='u' or pos=='d':
            if x + np.shape(self.space)[1] - 1 >= np.shape(room)[1]:
                return False
            if y + np.shape(self.space)[0] - 1 >= np.shape(room)[2]:
                return False
            for i in range(0, np.shape(self.space)[1]):
                for j in range(0, np.shape(self.space)[0]):
                    if p in [4,5,7]:
                        if room[0, x + i, y + j] > 0 or room[1, x + i, y + j] > 0 or room[2, x + i, y + j] > 0:
                            return False
                    elif p in [2, 6]:
                        if room[0, x + i, y + j] > 0:
                            return False
                    elif p== 8:
                        if room[2, x + i, y + j] > 0:
                            return False
        else:
            print('Not correct!')
            return False
        return True
    
    def _set(self, x, y, p, pos='r'):
        self._x = x
        self._y = y
        self._pos = pos
        self._p = p
        if p in [4, 5, 7]:
            if pos=='r':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(0, np.shape(self.space)[1]):
                        room[:, x + i, y + j] = self.space[i, j]
            elif pos=='l':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(np.shape(self.space)[1] - 1, -1, -1):
                        room[:, x + i, y + j] = self.space[i, np.shape(self.space)[1] - j - 1]
            elif pos=='d':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(0, np.shape(self.space)[1]):
                        room[:, x + j, y + i] = self.space[i, j]
            elif pos=='u':
                for i in range(np.shape(self.space)[0] - 1, -1, -1):
                    for j in range(0, np.shape(self.space)[1]):
                        room[:, x + j, y + i] = self.space[i, np.shape(self.space)[1] - j - 1]
            else:
                print('Not correct!')
        elif p in [2, 6]:
            if pos=='r':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(0, np.shape(self.space)[1]):
                        room[0, x + i, y + j] = self.space[i, j]
            elif pos=='l':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(np.shape(self.space)[1] - 1, -1, -1):
                        room[0, x + i, y + j] = self.space[i, np.shape(self.space)[1] - j - 1]
            elif pos=='d':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(0, np.shape(self.space)[1]):
                        room[0, x + j, y + i] = self.space[i, j]
            elif pos=='u':
                for i in range(np.shape(self.space)[0] - 1, -1, -1):
                    for j in range(0, np.shape(self.space)[1]):
                        room[0, x + j, y + i] = self.space[i, np.shape(self.space)[1] - j - 1]
            else:
                print('Not correct!')
        elif p==8:
            if pos=='r':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(0, np.shape(self.space)[1]):
                        room[2, x + i, y + j] = self.space[i, j]
            elif pos=='l':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(np.shape(self.space)[1] - 1, -1, -1):
                        room[2, x + i, y + j] = self.space[i, np.shape(self.space)[1] - j - 1]
            elif pos=='d':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(0, np.shape(self.space)[1]):
                        room[2, x + j, y + i] = self.space[i, j]
            elif pos=='u':
                for i in range(np.shape(self.space)[0] - 1, -1, -1):
                    for j in range(0, np.shape(self.space)[1]):
                        room[2, x + j, y + i] = self.space[i, np.shape(self.space)[1] - j - 1]
            else:
                print('Not correct!')
                
    def delete(self):        
        if self._p in [4, 5, 7]:
            if self._pos=='r' or self._pos=='l':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(0, np.shape(self.space)[1]):
                        room[:, self._x + i, self._y + j] = 0
            elif self._pos=='d' or self._pos=='u':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(0, np.shape(self.space)[1]):
                        room[:, self._x + j, self._y + i] = 0
        elif self._p in [2, 6]:
            if self._pos=='r' or self._pos=='l':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(0, np.shape(self.space)[1]):
                        room[:1, self._x + i, self._y + j] = 0
            elif self._pos=='d' or self._pos=='u':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(0, np.shape(self.space)[1]):
                        room[:1, self._x + j, self._y + i] = 0
        elif self._p==8:
            if self._pos=='r' or self._pos=='l':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(0, np.shape(self.space)[1]):
                        room[2, self._x + i, self._y + j] = 0
            elif self._pos=='d' or  self._pos=='u':
                for i in range(0, np.shape(self.space)[0]):
                    for j in range(0, np.shape(self.space)[1]):
                        room[2, self._x + j, self._y + i] = 0
        self._x = -1
        self._y = -1
        self._pos = 'r'
    
    def to_door(self, x, y):
        visited = [[False for i in range(np.shape(room)[2])] for j in range(np.shape(room)[1])]
 
        def dfs(x, y):
            if room[0, x, y] == 10:
                return True
            visited[x][y] = True
            for dx, dy in [[-1, 0], [0, -1], [0, 1], [1, 0]]:    
                if (x + dx >= 0) and (y + dy >= 0) and (x + dx < np.shape(room)[1]) and (y + dy < np.shape(room)[2]):
                    if visited[x + dx][y + dy] == False and room[0, x + dx, y + dy] in [0, 1, 3, 10]:
                        return dfs(x + dx, y + dy)
            return False

        return (dfs(x, y) or dfs(x + self.length - 1, y + self.width - 1))
    
    def __str__(self):
        return '\tx = ' + str(self._x) + ', y = ' + str(self._y) + '\n' +'\tsize = ' + str(self.length) + 'x' + str(self.width)


# # Class Table

# In[20]:


class Table(Furniture):
    OPER = 1
    
    def __init__(self, length, width):
        super().__init__(length, width)
        self.space = np.ones((length, width + self.OPER)) * 2
        self.space[0:length, width:width + self.OPER] = 1

    def place(self, x, y, pos='r'):
        if self.to_door(x, y) == False or self._check(x, y, 2, pos) == False:
            print('Impossible')
            return False
        self._set(x, y, 2, pos)
        return True
    
    def __str__(self):
        return 'Table:' + '\n' + super().__str__()


# # Class Case

# In[21]:


class Case(Furniture):
    length, width = 0, 0 
    FREE_PLACE = 1
    
    def __init__(self, length, width):
        super().__init__(length, width)
        self.space = np.ones((length, width + self.FREE_PLACE)) * 4
        self.space[0:length, width:width + self.FREE_PLACE] = 3
        
    def place(self, x, y, pos='r'):
        if self.to_door(x, y) == False or self._check(x, y, 4, pos) == False:
            print('Impossible')
            return False
        self._set(x, y, 4, pos)
        return True
    
    def __str__(self):
        return 'Case:' + '\n' + super().__str__()


# # Class Stand

# In[22]:


class Stand(Furniture):
    length, width = 0, 0 
    FREE_PLACE = 1
    
    def __init__(self, length, width):
        super().__init__(length, width)
        self.space = np.ones((length, width + self.FREE_PLACE)) * 5
        self.space[0:length, width:width + self.FREE_PLACE] = 3
        
    def place(self, x, y, pos='r'):
        if self.to_door(x, y) == False or self._check(x, y, 5, pos) == False:
            print('Impossible')
            return False
        self._set(x, y, 5, pos)
        return True
    
    def __str__(self):
        return 'Stand:' + '\n' + super().__str__()


# # Class Chest

# In[23]:


class Chest(Furniture):
    length, width = 0, 0 
    FREE_PLACE = 2
    
    def __init__(self, length, width):
        super().__init__(length, width)
        self.space = np.ones((length, width + self.FREE_PLACE)) * 6
        self.space[0:length, width:width + self.FREE_PLACE] = 3
        
    def place(self, x, y, pos='r'):
        if self.to_door(x, y) == False or self._check(x, y, 6, pos) == False:
            print('Impossible')
            return False
        self._set(x, y, 6, pos)
        return True
    
    def __str__(self):
        return 'Chest:' + '\n' + super().__str__()


# # Class Wardrobe

# In[24]:


class Wardrobe(Furniture):
    length, width = 0, 0 
    FREE_PLACE = 1
    
    def __init__(self, length, width):
        super().__init__(length, width)
        self.space = np.ones((length, width + self.FREE_PLACE)) * 7
        self.space[0:length, width:width + self.FREE_PLACE] = 3
        
    def place(self, x, y, pos='r'):
        if pos=='r' and y != 0:
            print('Impossible')
            return False
        elif pos=='l' and y != np.shape(room)[2] - np.shape(self.space)[1]:
            print('Impossible')
            return False
        elif pos=='d' and x != 0:
            print('Impossible')
            return False
        elif pos=='u' and x != np.shape(room)[1] - np.shape(self.space)[0]:
            print('Impossible')
            return False
        if self.to_door(x, y) == False or self._check(x, y, 7, pos) == False:
            print('Impossible')
            return False
        self._set(x, y, 7, pos)
        return True
    
    def __str__(self):
        return 'Wardrobe:' + '\n' + super().__str__()


# # Class Wardrobe_2X

# In[25]:


class Wardrobe_2x(Furniture):
    length, width = 0, 0 
    FREE_PLACE = 2
    
    def __init__(self, length, width):
        super().__init__(length, width)
        self.space = np.ones((length, width + self.FREE_PLACE)) * 7
        self.space[0:length, width:width + self.FREE_PLACE] = 3
        
    def place(self, x, y, pos='r'):
        if pos=='r' and y != 0:
            print('Impossible')
            return False
        elif pos=='l' and y != np.shape(room)[2] - np.shape(self.space)[1]:
            print('Impossible')
            return False
        elif pos=='d' and x != 0:
            print('Impossible')
            return False
        elif pos=='u' and x != np.shape(room)[1] - np.shape(self.space)[0]:
            print('Impossible')
            return False
        if self.to_door(x, y) == False or self._check(x, y, 7, pos) == False:
            print('Impossible')
            return False
        self._set(x, y, 7, pos)
        return True
    
    def __str__(self):
        return 'Wardrobe_2x:' + '\n' + super().__str__()


# # Class Wall_Case 

# In[26]:


class Wall_Case(Furniture):
    length, width = 0, 0 
    FREE_PLACE = 0
    
    def __init__(self, length, width):
        super().__init__(length, width)
        self.space = np.ones((length, width + self.FREE_PLACE)) * 8
        self.space[0:length, width:width + self.FREE_PLACE] = 3
        
    def place(self, x, y, pos='r'):
        if pos=='r' and y != 0:
            print('Impossible')
            return False
        elif pos=='l' and y != np.shape(room)[2] - np.shape(self.space)[1]:
            print('Impossible')
            return False
        elif pos=='d' and x != 0:
            print('Impossible')
            return False
        elif pos=='u' and x != np.shape(room)[1] - np.shape(self.space)[0]:
            print('Impossible')
            return False
        if self.to_door(x, y) == False or self._check(x, y, 8, pos) == False:
            print('Impossible')
            return False
        self._set(x, y, 8, pos)
        return True
    
    def __str__(self):
        return 'Wall case:' + '\n' + super().__str__()


# # Class Corner_Wardrobe

# In[27]:


class Corner_Wardrobe(Furniture):
    length, width = 0, 0 
    FREE_PLACE = 1
    
    def __init__(self, length):
        super().__init__(length, length)
        self.space = np.ones((length + 1, length + self.FREE_PLACE)) * 7
        self.space[0:length, length:length + self.FREE_PLACE] = 3
        self.space[length,:] = 3
        
    def place(self, x, y, pos='r'):
        if pos=='r':
            if not (y == 0 and (x == 0 or x == np.shape(room)[1] - self.length)):
                print('Impossible')
                return False
        elif pos=='l':
            if not (y == np.shape(room)[2] - self.length and (x == 0 or x == np.shape(room)[1] - self.length)):
                print('Impossible')
                return False
        elif pos=='u':
            if not (x == np.shape(room)[1] - lenght and (y == 0 or y == np.shape(room)[1] - self.width)):
                print('Impossible')
                return False
        elif pos=='d':
            if not (x == 0 and (y == 0 or y == np.shape(room)[1] - self.width)):
                print('Impossible')
                return False
        if self.to_door(x, y) == False or self._check(x, y, 7, pos) == False:
            print('Impossible')
            return False
        self._set(x, y, 7, pos)
        return True
    
    def __str__(self):
        return 'Corner wardrobe:' + '\n' + super().__str__()


# # Class Appliance

# In[28]:


class Appliance():
    _x, _y = -1, -1
    
    def __init__(self, length = 0):
        self.length = length
        
    def x(self):
        return self._x
    
    def y(self):
        return self._y
    
    def place(self, x, y):
        return False
    
    def _check(self,x,y,p):# проверяет, можно ли поставить на указанное место
        if (x < 0) or (y < 0) or (x >= np.shape(room)[1]) or (y >= np.shape(room)[2]):
            return False
        if np.size(np.shape(self.space)) < 2:
            return False
        if x + np.shape(self.space)[0] - 1 >= np.shape(room)[1]:
            return False
        if y + np.shape(self.space)[1] - 1 >= np.shape(room)[2]:
            return False
        for i in range(0, np.shape(self.space)[0]):
            for j in range(0, np.shape(self.space)[1]):
                if p == 11:
                    if room[0, x + i, y + j] != 2 or room[1, x + i, y + j] > 0:
                        return False
                elif p == 12:
                    if (room[0, x + i, y + j] != 2 and room[0, x + i, y + j] != 6) or room[1, x + i, y + j] > 0:
                        return False
        for i in range(0, np.shape(self.space)[0]):
            if y > 0 and room[0, x + i, y - 1] == 1:
                return True
            if y < np.shape(room)[1] - 1 and room[0, x + i, y + 1] == 1:
                return True
            if p == 12:
                if y > 0 and room[0, x + i, y - 1] == 3:
                    return True
                if y < np.shape(room)[1] - 1 and room[0, x + i, y + 1] == 3:
                    return True
        for i in range(0, np.shape(self.space)[1]):
            if x > 0 and room[0, x - 1, y + i] == 1:
                return True
            if x < np.shape(room)[2] - 1 and room[0, x + 1, y + i] == 1:
                return True
            if p == 12:
                if x > 0 and room[0, x - 1, y + i] == 3:
                    return True
                if x < np.shape(room)[2] - 1 and room[0, x + 1, y + i] == 3:
                    return True
        return False
    
    def _set(self, x, y):
        self._x = x
        self._y = y
        
        for i in range(0, np.shape(self.space)[0]):
            for j in range(0, np.shape(self.space)[1]):
                room[1, x + i, y + j] = self.space[i, j]
                
    def delete(self):        
        for i in range(0, np.shape(self.space)[0]):
            for j in range(0, np.shape(self.space)[1]):
                room[1, self._x + i, self._y + j] = 0
                
        self._x = -1
        self._y = -1
    
    def to_socket(self, x, y):
        visited = [[False for i in range(np.shape(room)[2])] for j in range(np.shape(room)[1])]
 
        def dfs(x, y, i):
            print(x,y,i)
            if room[2, x, y] == 9:
                return True
            if i == 4:
                return False
            visited[x][y] = True
            i += 1
            for dx, dy in [[-1, 0], [0, -1], [0, 1], [1, 0]]:    
                if (x + dx >= 0) and (y + dy >= 0) and (x + dx < np.shape(room)[1]) and (y + dy < np.shape(room)[2]):
                    if visited[x + dx][y + dy] == False and room[0, x + dx, y + dy] in [0, 2, 3, 6, 9]:
                        return dfs(x + dx, y + dy, i)
            return False

        return (dfs(x, y, 0) or dfs(x + self.length - 1, y, 0) or dfs(x, y + self.length - 1, 0) or dfs(x + self.length - 1, y + self.length - 1, 0))
    
    def __str__(self):
        return '\tx = ' + str(self._x) + ', y = ' + str(self._y) + '\n' +'\tsize = ' + str(self.length) + 'x' + str(self.length)


# # Class Computer

# In[29]:


class Computer(Appliance):
    length = 0
    
    def __init__(self, length):
        super().__init__(length)
        self.space = np.ones((length, length)) * 11
        
    def place(self, x, y):
        if self.to_socket(x, y) == False or self._check(x, y, 11) == False:
            print('Impossible')
            return False
        self._set(x, y)
        return True
    
    def __str__(self):
        return 'Computer:' + '\n' + super().__str__()


# # Class Printer

# In[30]:


class Printer(Appliance):
    length = 0
    
    def __init__(self, length):
        super().__init__(length)
        self.space = np.ones((length, length)) * 12
        
    def place(self, x, y):
        if self.to_socket(x, y) == False or self._check(x, y, 12) == False:
            print('Impossible')
            return False
        self._set(x, y)
        return True
    
    def __str__(self):
        return 'Printer:' + '\n' + super().__str__()


# # Class Door

# In[31]:


class Door():
    _x, _y = -1, -1
    
    def __init__(self, x, y):
        self._x = x
        self._y = y
        if self._check(x, y) == False:
            print('Impossible')
            return None
        self._set(x,y)
    
    def _check(self,x,y):# проверяет, можно ли поставить на указанное место
        if (x < 0) or (y < 0) or (x >= np.shape(room)[1]) or (y >= np.shape(room)[2]):
            print('Impossible')
            return False
        if (x == 0 or x == np.shape(room)[1] - 1) and y < np.shape(room)[2] - 1:
            self.space = [[10, 10]]
            return True
        elif (y == 0 or y == np.shape(room)[2] - 1) and x < np.shape(room)[1] - 1:
            self.space = [[10], [10]]
            return True
        else:
            print('Not correct!')
            return False
    
    def _set(self, x, y):
        self._x = x
        self._y = y
        for i in range(0, np.shape(self.space)[0]):
                for j in range(0, np.shape(self.space)[1]):
                    room[:, x + i, y + j] = self.space[i][j]


# # Class Window

# In[32]:


class Window():
    _x, _y = -1, -1
    
    def __init__(self, x, y):
        self._x = x
        self._y = y
        if self._check(x, y) == False:
            print('Impossible')
            return None
        self._set(x,y)
    
    def _check(self,x,y):# проверяет, можно ли поставить на указанное место
        if (x < 0) or (y < 0) or (x >= np.shape(room)[1]) or (y >= np.shape(room)[2]):
            print('Impossible')
            return False
        if (x == 0 or x == np.shape(room)[1] - 1) and y < np.shape(room)[2] - 1:
            self.space = [[3, 3]]
            return True
        elif (y == 0 or y == np.shape(room)[2] - 1) and x < np.shape(room)[1] - 1:
            self.space = [[3], [3]]
            return True
        else:
            print('Not correct!')
            return False
    
    def _set(self, x, y):
        self._x = x
        self._y = y
        for i in range(0, np.shape(self.space)[0]):
                for j in range(0, np.shape(self.space)[1]):
                    room[1, x + i, y + j] = self.space[i][j]


# In[ ]:


fur = []
app = []
e = -1
while e != 0:
    try:
        e = int(input('Enter 0 for exit, 1 - for create room, 2 - for create furniture, 3 - for create appliance,\n4 - for delete furniture, 5 - for delete appliance. '))
        if e == 1:
            fur = []
            app = []
            n, m = map(int, input('Enter length and width of room: ').split())
            room=np.zeros((3, n, m))
            n = int(input('Enter count of doors: '))
            for i in range(n):
                a, b = map(int, input('Enter doors coordinates: ').split())
                Door(a, b)
            n = int(input('Enter count of windows: '))
            for i in range(n):
                a, b = map(int, input('Enter windows coordinates: ').split())
                Window(a, b)
            n = int(input('Enter count of sockets: '))
            for i in range(n):
                a, b = map(int, input('Enter sockets coordinates: ').split())
                if room[2, a , b] > 0:
                    print('Impossible')
                else:
                    room[2, a , b] = 9
        elif e == 2:
            print('0 - table, 1 - case, 2 - stand, 3 - chest, 4 - wardrob, 5 - wardrob_2x, 6 - corner wardrob, 7 - wall case')
            m = int(input('Enter type of furniture: '))
            x, y = map(int, input('Enter coordinates: ').split())
            if m == 0:
                l, w = map(int, input('Enter length and width of table: ').split())
                fur.append(Table(l, w))
                pos = input('Enter position of table (r, l, u, d): ')
                if not fur[len(fur) - 1].place(x, y, pos):
                    fur.pop(len(fur) - 1)
            elif m == 1:
                l, w = map(int, input('Enter length and width of case: ').split())
                fur.append(Case(l, w))
                pos = input('Enter position of case (r, l, u, d): ')
                if not fur[len(fur) - 1].place(x, y, pos):
                    fur.pop(len(fur) - 1)
            elif m == 2:
                l, w = map(int, input('Enter length and width of stand: ').split())
                fur.append(Stand(l, w))
                pos = input('Enter position of stand (r, l, u, d): ')
                if not fur[len(fur) - 1].place(x, y, pos):
                    fur.pop(len(fur) - 1)
            elif m == 3:
                l, w = map(int, input('Enter length and width of chest: ').split())
                fur.append(Chest(l, w))
                pos = input('Enter position of chest (r, l, u, d): ')
                if not fur[len(fur) - 1].place(x, y, pos):
                    fur.pop(len(fur) - 1)
            elif m == 4:
                l, w = map(int, input('Enter length and width of wardrob: ').split())
                fur.append(Wardrobe(l, w))
                pos = input('Enter position of wardrob (r, l, u, d): ')
                if not fur[len(fur) - 1].place(x, y, pos):
                    fur.pop(len(fur) - 1)
            elif m == 5:
                l, w = map(int, input('Enter length and width of wardrob_2x: ').split())
                fur.append(Wardrobe_2x(l, w))
                pos = input('Enter position of wardrob_2x (r, l, u, d): ')
                if not fur[len(fur) - 1].place(x, y, pos):
                    fur.pop(len(fur) - 1)
            elif m == 6:
                l = int(input('Enter size of corner wardrob: '))
                fur.append(Corner_Wardrobe(l))
                pos = input('Enter position of corner wardrob (r, l, u, d): ')
                if not fur[len(fur) - 1].place(x, y, pos):
                    fur.pop(len(fur) - 1)
            elif m == 7:
                l, w = map(int, input('Enter length and width of wall case: ').split())
                fur.append(Wall_Case(l, w))
                pos = input('Enter position of wall case (r, l, u, d): ')
                if not fur[len(fur) - 1].place(x, y, pos):
                    fur.pop(len(fur) - 1)
            else:
                print('Not correct!')
        elif e == 3:
            print('0 - computer, 1 - printer')
            m = int(input('Enter type of appliance: '))
            x, y = map(int, input('Enter coordinates: ').split())
            if m == 0:
                l = int(input('Enter size of computer: '))
                app.append(Computer(l))
                app[len(app) - 1].place(x, y)
            elif m == 1:
                l = int(input('Enter size of printer: '))
                app.append(Printer(l))
                app[len(app) - 1].place(x, y)
            else:
                print('Not correct!')
        elif e == 4:
            for i in range(len(fur)):
                  print(i, fur[i])
            i = int(input('Enter number of furniture for delete: '))
            fur[i].delete()
            fur.pop(i)
        elif e == 5:
            for i in range(len(app)):
                  print(i, app[i])
            i = int(input('Enter number of appliance for delete: '))
            app[i].delete()
            app.pop(i)
        else:
            break
        print(room)
    except:
        print('Not correct!')

