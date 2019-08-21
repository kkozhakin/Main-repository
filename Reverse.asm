format PE GUI 4.0
entry Start

include 'win32ax.inc'

section '.text' code readable executable

Start:
      cinvoke GetCommandLine                          ;���� ������
      mov [IpCommandLine], eax
      cinvoke sscanf, [IpCommandLine], "%s%s", name, text
        
      invoke lstrlen, text                            ;���������� ����� ������
      stdcall StrRev, text, eax

      invoke MessageBox, NULL, text, title, MB_OK     ;�����
      invoke ExitProcess, 0

proc StrRev strAddr, strSize    ;������� ���������� ������
      push esi
      push edi
      mov esi, [strAddr]
      mov eax, [strSize]
      lea edi, [esi+eax]
      cmp eax, 2    ;���� ����� ������ ������ 2, �� �����
      jb Exit
      cmp eax, 9    ;���� ����� ������ ������ 9 �� ������������ �� ���������
      jb Rev2
   Rev1:                ;����������� ����� �� 4
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
   Rev2:                ;����������� �����������
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