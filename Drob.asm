format PE Console 4.0
entry Start

include 'win32a.inc'

section '.text' code readable executable

Start:
     
  mov eax, 32                ;входные данные
  mov ebx, 174
  mov cx, 4
  
  mov edx, 1

  L1: cmp cx, 0              ;вычисление числителя и знаменателя
    jle L2
    imul eax, 10
    jo error
    imul edx, 10
    jo error 
    sub cx, 1
    jmp L1
  L2:
    
  add eax, ebx
  jo error
  mov esi, edx 
  mov ebx, eax
   
  N1: cmp eax, edx           ;НОД
    je N3
    ja N2
    xchg eax, edx
  N2:  sub eax, edx
    jmp N1
  N3:
  
  mov edi, eax               ;деление на НОД
  mov eax, ebx
  xor edx, edx
  div edi
  mov ecx, eax
  mov eax, esi
  div edi
  mov ebx, eax
  mov eax, ecx
  
  push eax                 ;Вывод
  push mes
  call [printf]
  sub esp, 8
  push 0
  
  push mes1
  call [printf]
  sub esp, 8
  push 0
  
  push ebx
  push mes
  call [printf]
  sub esp, 8
  push 0
  int 21h
  
error:                     ;обработка переполнения
  push err_msg
  call [printf]
  sub esp, 8
  push 0
  int 21h                      

section '.data' data readable writeable

  mes         db '  %d', 10, 0
  mes1         db ' -------', 10, 0
  err_msg   db 'Error: overflow detected.',13,10

section '.idata' import data readable

  library msvcrt, 'msvcrt.dll'

  import msvcrt, printf, 'printf'