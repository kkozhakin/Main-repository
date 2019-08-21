#include "ReadWriter.h"
//iostream, fstream включены в ReadWriter.h
using namespace std;

//Можно создавать любое количество любых вспомогательных классов, структур и методов для решения задачи.

//Необходимо реализовать алгоритм быстрой сортировки.
//В качестве опорного элемента выбирать случайный
void quickSort(int *numbers, int first, int last)
{
    int i = first, j = last;
    int tmp;
    int x = numbers[(first + last) / 2];
    //int x = numbers[first + rand() % (last - first + 1)];
    //int x = numbers[last];

    do
        {
        while (numbers[i] < x)
            i++;
        while (numbers[j] > x)
            j--;

        if (i <= j)
        {
            if (i < j)
            {
                tmp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = tmp;
            }
            i++;
            j--;
        }
    } while (i <= j);

    if (i < last)
        quickSort(numbers, i, last);
    if (first < j)
        quickSort(numbers, first, j);
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

    //Запуск сортировки, ответ в том же массиве (brr)
    quickSort(brr, 0, n - 1);

    //Запись в файл
    rw.writeArray(brr, n);

    //освобождаем память
    delete[] brr;

    return 0;
}
