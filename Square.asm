format PE GUI 4.0
entry Start

include 'win32ax.inc'

section '.text' code readable executable

Start:
    
    cinvoke GetCommandLine
    mov [IpCommandLine], eax      
    cinvoke sscanf, [IpCommandLine], "%s%d%d%d%d%d%d%d%d", name, x1, y1, x2, y2, x3, y3, x4, y4 

    xor ax, ax
    xor si, si 
    mov bl, byte[x1]
    mov bh, byte[y1]
    mov cl, byte[x2]
    mov ch, byte[y2]
    sub cl, bl
    sub ch, bh
    mov al, cl
    imul cl
    add si, ax
    mov al, ch
    imul ch
    add si, ax

    xor ax, ax
    xor di, di
    mov cl, byte[x3]
    mov ch, byte[y3]
    sub cl, bl
    sub ch, bh
    mov al, cl
    imul cl
    add di, ax
    mov al, ch
    imul ch
    add di, ax

    xor ax, ax
    xor dx, dx
    mov cl, byte[x4]
    mov ch, byte[y4]
    sub cl, bl
    sub ch, bh
    mov al, cl
    imul cl
    add dx, ax
    mov al, ch
    imul ch
    add dx, ax
    
    cmp si, di
    je M1
    cmp si, dx
    je M2
    cmp dx, di
    je M3
    jmp No
    
    M1:  
      xor si, si
      xor ax, ax 
      mov bl, byte[x2]
      mov bh, byte[y2]
      mov cl, byte[x3]
      mov ch, byte[y3]
      sub cl, bl
      sub ch, bh
      mov al, cl
      imul cl
      add si, ax
      mov al, ch
      imul ch
      add si, ax
      cmp si, dx
      jne No
      
      xor ax, ax 
      xor si, si
      mov cl, byte[x4]
      mov ch, byte[y4]
      sub cl, bl
      sub ch, bh
      mov al, cl
      imul cl
      add si, ax
      mov al, ch
      imul ch
      add si, ax
      cmp si, di
      jne No
      
      xor ax, ax 
      xor si, si
      mov bl, byte[x3]
      mov bh, byte[y3]
      mov cl, byte[x4]
      mov ch, byte[y4]
      sub cl, bl
      sub ch, bh
      mov al, cl
      imul cl
      add si, ax
      mov al, ch
      imul ch
      add si, ax
      cmp si, di
      jne No
      jmp Yes
      
    M2:
      xor si, si
      xor ax, ax 
      mov bl, byte[x2]
      mov bh, byte[y2]
      mov cl, byte[x4]
      mov ch, byte[y4]
      sub cl, bl
      sub ch, bh
      mov al, cl
      imul cl
      add si, ax
      mov al, ch
      imul ch
      add si, ax
      cmp si, di
      jne No
      
      xor ax, ax 
      xor si, si
      mov cl, byte[x3]
      mov ch, byte[y3]
      sub cl, bl
      sub ch, bh
      mov al, cl
      imul cl
      add si, ax
      mov al, ch
      imul ch
      add si, ax
      cmp si, dx
      jne No
      
      xor ax, ax 
      xor si, si
      mov bl, byte[x3]
      mov bh, byte[y3]
      mov cl, byte[x4]
      mov ch, byte[y4]
      sub cl, bl
      sub ch, bh
      mov al, cl
      imul cl
      add si, ax
      mov al, ch
      imul ch
      add si, ax
      cmp si, dx
      jne No
      jmp Yes
      
      M3:
      xor dx, dx
      xor ax, ax 
      mov bl, byte[x3]
      mov bh, byte[y3]
      mov cl, byte[x4]
      mov ch, byte[y4]
      sub cl, bl
      sub ch, bh
      mov al, cl
      imul cl
      add dx, ax
      mov al, ch
      imul ch
      add dx, ax
      cmp si, dx
      jne No
      
      xor ax, ax 
      xor dx, dx
      mov bl, byte[x2]
      mov bh, byte[y2]
      mov cl, byte[x3]
      mov ch, byte[y3]
      sub cl, bl
      sub ch, bh
      mov al, cl
      imul cl
      add dx, ax
      mov al, ch
      imul ch
      add dx, ax
      cmp di, dx
      jne No
      
      xor ax, ax 
      xor dx, dx
      mov cl, byte[x4]
      mov ch, byte[y4]
      sub cl, bl
      sub ch, bh
      mov al, cl
      imul cl
      add dx, ax
      mov al, ch
      imul ch
      add dx, ax
      cmp di, dx
      jne No
      jmp Yes
      
    Yes:
      invoke MessageBox, NULL, yes, title, MB_OK
      invoke ExitProcess, 0
    
    No:
      invoke MessageBox, NULL, no, title, MB_OK
      invoke ExitProcess, 0
      
section '.data' data readable writeable

  title db 'Ответ', 0
  no db 'No', 0
  yes db 'Yes', 0
  x1 dd 0
  x2 dd 0
  x3 dd -1
  x4 dd 1
  y1 dd 1
  y2 dd -1
  y3 dd 0
  y4 dd 0
  msg db "%d", 0
  buff db 50 DUP ?
  name db 256 DUP ?
  IpCommandLine dd ?

section '.idata' import data readable writeable

  library kernel32, 'KERNEL32.DLL',\
	  user32, 'USER32.DLL', msvcrt, 'MSVCRT.DLL'

  include 'api\kernel32.inc'
  include 'api\user32.inc'
  
  import msvcrt,\
  sscanf, 'sscanf'