format PE GUI 4.0
entry Start

include 'win32ax.inc'

section '.text' code readable executable

Start:
        cinvoke GetCommandLine
        mov [IpCommandLine], eax
        cinvoke sscanf, [IpCommandLine], "%s%s", name, text
        
        mov edi, text ;начало строки
        invoke lstrlen, text
        mov esi, eax ;длина строки
        mov ecx, esi
        shr ecx,1;         // Вычисляю количество итераций
 
        .loop:
          mov edx, edi
          sub edx, ecx;             // [edi+esi-ecx]
          mov al, byte [edx+esi];   // загружаю байт справа
          cmp al, byte [edi+ecx-1]; // сравниваю с байтом слева
          jnz No;         // Выхожу из цикла если они не равны
          dec ecx;           // Уменьшаю счетчик
          jnz .loop;         // При нулевом счетчике выход из цикла

          invoke MessageBox, NULL, yes, title, MB_OK
          invoke ExitProcess, 0
          
          No:
             invoke MessageBox, NULL, no, title, MB_OK
             invoke ExitProcess, 0
section '.data' data readable writeable

  IpCommandLine dd ?
  text db 256 DUP ?
  name db 256 DUP ?
  title db 'answer', 0
  
  yes db 'Yes', 0
  no db 'No', 0

section '.idata' import data readable writeable

  library kernel32, 'KERNEL32.DLL',\
	  user32, 'USER32.DLL', msvcrt, 'MSVCRT.DLL'

  include 'api\kernel32.inc'
  include 'api\user32.inc'
  
  import msvcrt,\
   sscanf, 'sscanf'