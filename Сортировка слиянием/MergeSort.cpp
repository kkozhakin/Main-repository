#include "ReadWriter.h"
#include "MergeSort.h"
//iostream, fstream включены в ReadWriter.h

//Не рекомендуется добавлять собственные вспомогательные классы и методы.
//Необходимо использовать уже имеющиеся классы и методы, добавив реализацию, соответствующую описанию.
using namespace std;

//Описание методов на английском языке имеется в классе MergeSort, в файле MergeSort.h
void MergeSort::sort(int *arr, int length)
{
    divide_and_merge(arr, 0, length - 1);
}

void MergeSort::merge(int* arr, int first, int second, int end)
{
    int i, j, k;
    int n1 = second - first + 1;
    int n2 = end - second;

    int L[n1], R[n2];

    for (i = 0; i < n1; i++)
        L[i] = arr[first + i];
    for (j = 0; j < n2; j++)
        R[j] = arr[second + 1 + j];

    i = 0;
    j = 0;
    k = first;
    while (i < n1 && j < n2)
    {
        if (L[i] <= R[j])
        {
            arr[k] = L[i];
            i++;
        } else
        {
            arr[k] = R[j];
            j++;
        }
        k++;
    }

    while (i < n1)
    {
        arr[k] = L[i];
        i++;
        k++;
    }

    while (j < n2)
    {
        arr[k] = R[j];
        j++;
        k++;
    }
}

void MergeSort::divide_and_merge(int *arr, int left, int right)
{
    if (left < right)
    {
        int m = left + (right - left) / 2;

        divide_and_merge(arr, left, m);
        divide_and_merge(arr, m + 1, right);

        merge(arr, left, m, right);
    }
}

int main()
{   
    ReadWriter rw;

    int *brr = nullptr;
    int length;

    //Read data from file
    length = rw.readInt();

    brr = new int[length];
    rw.readArray(brr, length);

    //Start sorting
    MergeSort s;

    s.sort(brr, length);
    
    //Write answer to file
    rw.writeArray(brr, length);

    delete[] brr;

    return 0;
}