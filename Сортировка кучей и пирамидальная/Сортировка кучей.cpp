#include <vector>
#include "ReadWriter.h"
//iostream, fstream включены в ReadWriter.h
using namespace std;

//Можно создавать любое количество любых вспомогательных классов, структур и методов для решения задачи.
void Heapify(int *ages, int n, int i)
{
    int l = 2 * i + 1;
    int r = 2 * i + 2;
    int c = i;
    if (l < n && ages[l] > ages[c])
        c = l;
    if (r < n && ages[r] > ages[c])
        c = r;
    if (c != i)
    {
        swap(ages[i], ages[c]);
        Heapify(ages, n, c);
    }
}

//Функция для построения кучи
//Ответ должен лежать в массиве ages
void heapBuild(int *ages, int n)
{
    for (int i = n / 2 - 1; i != -1; i--)
        Heapify(ages, n, i);
}

//Не удалять и не изменять метод main без крайней необходимости.
//Необходимо добавить комментарии, если все же пришлось изменить метод main.
int main()
{
    //Объект для работы с файлами
    ReadWriter rw;

    int *brr = nullptr;
    int n;

    //Ввод из файла
    n = rw.readInt();

    brr = new int[n];
    rw.readArray(brr, n);

    //Запуск построения кучи, ответ в том же массиве (brr)
    heapBuild(brr, n);

    //Запись в файл
    rw.writeArray(brr, n);

    //освобождаем память
    delete[] brr;

    return 0;
}
