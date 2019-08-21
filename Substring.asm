format PE
entry start

include 'win32a.inc'

section '.data' data readable writeable

szTitle1 db 'Replace', 0
szTitle2 db 'Original String ', 0
szTitle3 db 'Pattern String ', 0
szTitle4 db 'Replace String ', 0

szStr1 db 255, ?, 255 Dup(?)
szStr2 db 255, ?, 255 Dup(?)
szStr  db 255, ?, 255 Dup(?)
s db '%s', 0

buff rb 1000h

;---------------------------------------------

section '.code' code readable executable

  start:
        cinvoke printf, szTitle2                             
        cinvoke scanf, s, szStr 
        cinvoke printf, szTitle3                             
        cinvoke scanf, s, szStr1  
        cinvoke printf, szTitle4                             
        cinvoke scanf, s, szStr2 

        invoke  MessageBox, NULL, szStr, szTitle2, MB_OK
        invoke  MessageBox, NULL, szStr1, szTitle3, MB_OK
        invoke  MessageBox, NULL, szStr2, szTitle4, MB_OK
        
        ; Заменить все вхождения
        stdcall _replace, szStr, szStr1, szStr2, buff, 0
        invoke  MessageBox, NULL, buff, szTitle1, MB_OK

        invoke  ExitProcess, 0

;--------------------------------------------------------------
; Функция замены подстроки в строке
;--------------------------------------------------------------
; lpSrc - указатель на исходную строку
; lpDst - указатель на буфер для полученной строки
; lpPattern - указатель на заменяемую подстроку
; lpReplace - указатель на строку для замены
; dNum - количество замен (0 - заменить все)
;--------------------------------------------------------------
proc    _replace lpSrc:DWORD, lpPattern:DWORD, lpReplace:DWORD,\
                 lpDst:DWORD, dNum:DWORD

        pusha

        ; Указатель на буфер-приемник
        mov edx, [lpDst]

        ; Счетчик замен
        xor ebx, ebx

        ; Исходная строка не пустая?
        mov ecx, [lpSrc]
        cmp byte [ecx], 0
        jz  .loc_ret

        ; Заменяемая строка не пустая?
        mov eax, [lpPattern]
        cmp byte [eax], 0
        jz  .loc_copy_all

.loc_scan:
        mov esi, ecx
        mov edi, [lpPattern]

        ; Исходная строка закончилась?
        cmp byte [esi], 0
        je  .loc_end_replace

@@:
        ; Строки совпали с паттерном?
        cmp byte [edi],0
        je  .loc_move_replace
        lodsb

        ; Заменять все вхождения?
        cmp [dNum], 0
        je .loc_skip_counter

        ; Уже заменили нужное количество?
        cmp ebx, [dNum]
        je  .loc_move_one_char

.loc_skip_counter:
        cmp al, byte [edi]
        jne .loc_move_one_char
        inc edi
        jmp @b

.loc_move_replace:
        ; Увеличить счетчик замен
        inc ebx
        mov ecx, esi

        ; Записать заменяющую строку
        mov esi, [lpReplace]
        mov edi, edx

@@:
        lodsb
        or al, al
        jz .loc_scan
        stosb
        inc edx
        jmp @b

.loc_move_one_char:
        ; Скопировать один символ
        mov al, byte [ecx]
        mov byte [edx], al
        inc edx
        inc ecx
        jmp .loc_scan

.loc_end_replace:
        ; Записать финальный 0 в строку
        mov byte [edx],0
        jmp .loc_ret

.loc_copy_all:
        ; Просто скопировать исходную строку
        mov esi, [lpSrc]
        mov edi, [lpDst]

@@:
        lodsb
        stosb
        or al,al
        jnz @b

.loc_ret:
        popa
        ret
endp

section '.idata' import data readable writeable

  library kernel32, 'KERNEL32.DLL',\
	  user32, 'USER32.DLL' , msvcrt, 'MSVCRT.DLL'

  include 'api\kernel32.inc'
  include 'api\user32.inc'
  import msvcrt, scanf, 'scanf',\
    printf, 'printf'