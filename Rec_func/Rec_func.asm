format PE GUI 4.0
entry Start

include 'win32a.inc'

section '.text' code readable executable

Start:
  xor bh, bh             ;начальные значения
  xor bl, bl
  xor ch, ch
  mov cl, 1
  mov esi, 3             ;значение n

  func:                  ;рекурсивная функция расчета элементов последовательности
    xor al, al           ;очищаем t_n
    add al, cl           ;считаем t_n и сдвигаем значения
    mov cl, ch 
    add al, ch
    mov ch, bl 
    add al, bl
    mov bl, bh 
    add al, bh
    mov bh, al                                   
    inc esi              ;увеличиваем значение n
    
    cmp al, 32           ;сравнием t_n с машинным словом для Win32
    jnl finish           ;если достигло, на выход  
    jmp func

  finish:    
    dec esi
     
    invoke wsprintfA, buff, msg, esi
    invoke MessageBox, NULL, buff, title, MB_OK
    invoke ExitProcess, 0
    
section '.data' data readable writeable

  title db 'Ответ', 0
  msg db 'Максимальное значение параметра числа последовательности = %d', 0
  buff db 50 DUP ?

section '.idata' import data readable writeable

  library kernel32, 'KERNEL32.DLL',\
	  user32, 'USER32.DLL'

  include 'api\kernel32.inc'
  include 'api\user32.inc'