format PE GUI 4.0
entry Start

include 'win32ax.inc'

section '.text' code readable executable

Start:
      cinvoke GetCommandLine                          ;ввод данных
      mov [IpCommandLine], eax
      cinvoke sscanf, [IpCommandLine], "%s%s", name, text
        
      invoke lstrlen, text                            ;вычисление длины строки
      stdcall StrRev, text, eax

      invoke MessageBox, NULL, text, title, MB_OK     ;вывод
      invoke ExitProcess, 0

proc StrRev strAddr, strSize    ;функци€ переворота строки
      push esi
      push edi
      mov esi, [strAddr]
      mov eax, [strSize]
      lea edi, [esi+eax]
      cmp eax, 2    ;если длина строки меньше 2, то выход
      jb Exit
      cmp eax, 9    ;если длина строки меньше 9 то переставл€ем по символьно
      jb Rev2
   Rev1:                ;переставл€ю куски по 4
      sub edi, 4
      mov edx, dword [edi]
      mov eax, dword [esi]
      bswap eax
      bswap edx
      mov dword [esi], edx
      mov dword [edi], eax
      add esi, 4
      cmp esi, [edi+8]
      jb Rev1
   Rev2:                ;переставл€ю посимвольно
      sub edi, 1
      mov dh, [edi]
      mov dl, [esi]
      mov [esi], dh
      mov [edi], dl
      inc esi
      cmp esi, edi
      jb Rev2
   Exit:
      pop edi
      pop esi
      ret
endp

section '.data' data readable writeable

  IpCommandLine dd ?
  text db 256 DUP ?
  name db 256 DUP ?
  title db 'answer', 0

section '.idata' import data readable writeable

  library kernel32, 'KERNEL32.DLL',\
	  user32, 'USER32.DLL', msvcrt, 'MSVCRT.DLL'

  include 'api\kernel32.inc'
  include 'api\user32.inc'
  
  import msvcrt,\
   sscanf, 'sscanf'