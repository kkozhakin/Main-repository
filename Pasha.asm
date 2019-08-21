format PE GUI 4.0
entry Start

include 'win32ax.inc'

section '.text' code readable executable

Start:

  cinvoke GetCommandLine
  mov [IpCommandLine], eax      
  cinvoke sscanf, [IpCommandLine], "%s%d", name, year 
               
  mov bx, 19
  mov ax, [year]
  xor dx, dx
  div bx
  mov ax, dx
  mul bx
  add ax, 15
  mov bx, 30
  xor dx, dx
  div bx
  mov cx, dx
  
  mov bx, 4
  mov ax, [year]  
  xor dx, dx  
  div bx
  mov ax, dx
  mov bx, 2
  mul bx
  mov di, ax   
  mov bx, 7
  mov ax, [year] 
  xor dx, dx
  div bx        
  mov ax, dx
  mov bx, 4
  mul bx
  add di, ax
  add di, 6
  mov ax, 6
  mul cx
  add di, ax
  xor ax, dx
  mov ax, di
  mov bx, 7
  xor dx, dx
  div bx
  add cx, dx
  
  xor eax, eax
  cmp cx, 9
  ja A
  
  add cx, 22
  mov ax, cx   
  invoke wsprintfA, buff, march, eax
  invoke MessageBox, NULL, buff, title, MB_OK
  invoke ExitProcess, 0
  
A:
   
  sub cx, 9
  mov ax, cx   
  invoke wsprintfA, buff, april, eax
  invoke MessageBox, NULL, buff, title, MB_OK
  invoke ExitProcess, 0 
  
section '.data' data readable writeable

  title db 'Ответ', 0
  march db '%d марта ст. стиля', 0
  april db '%d апреля ст. стиля', 0
  name db 256 DUP ?
  IpCommandLine dd ?
  year dw 0
  buff db 50 DUP ?

section '.idata' import data readable writeable

  library kernel32, 'KERNEL32.DLL',\
	  user32, 'USER32.DLL', msvcrt, 'MSVCRT.DLL'

  include 'api\kernel32.inc'
  include 'api\user32.inc'
  
  import msvcrt,\
  sscanf, 'sscanf'