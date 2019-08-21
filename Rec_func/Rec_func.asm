format PE GUI 4.0
entry Start

include 'win32a.inc'

section '.text' code readable executable

Start:
  xor bh, bh             ;��������� ��������
  xor bl, bl
  xor ch, ch
  mov cl, 1
  mov esi, 3             ;�������� n

  func:                  ;����������� ������� ������� ��������� ������������������
    xor al, al           ;������� t_n
    add al, cl           ;������� t_n � �������� ��������
    mov cl, ch 
    add al, ch
    mov ch, bl 
    add al, bl
    mov bl, bh 
    add al, bh
    mov bh, al                                   
    inc esi              ;����������� �������� n
    
    cmp al, 32           ;�������� t_n � �������� ������ ��� Win32
    jnl finish           ;���� ��������, �� �����  
    jmp func

  finish:    
    dec esi
     
    invoke wsprintfA, buff, msg, esi
    invoke MessageBox, NULL, buff, title, MB_OK
    invoke ExitProcess, 0
    
section '.data' data readable writeable

  title db '�����', 0
  msg db '������������ �������� ��������� ����� ������������������ = %d', 0
  buff db 50 DUP ?

section '.idata' import data readable writeable

  library kernel32, 'KERNEL32.DLL',\
	  user32, 'USER32.DLL'

  include 'api\kernel32.inc'
  include 'api\user32.inc'