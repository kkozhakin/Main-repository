#include <vector>
#include "ReadWriter.h"
//iostream, fstream, Student_and_Ski.h включены в ReadWriter.h
using namespace std;

//Можно создавать любое количество любых вспомогательных методов для решения задачи.
//Рекомендуется использовать имеющиеся классы Student и Ski для решения задачи.
unsigned long Sort_Students(Student* students, Ski ski, unsigned long n)
{
    if (n == 0)
        return 0;

    vector<Student> lt, gt;
    Student stud;
    for (int i = 0; i < n; i++)
    {
        int x = compare(students[i], ski);
        if (x == -1)
            gt.push_back(students[i]);
        else if (x == 1)
            lt.push_back(students[i]);
        else
            stud = students[i];
    }

    for (int i = 0; i < lt.size(); i++)
        students[i] = lt[i];

    for (int i = 1; i <= gt.size(); i++)
        students[lt.size() + i] = gt[i - 1];

    students[lt.size()] = stud;

    return lt.size();
}

unsigned long Sort_Skis(Ski* skis, Student student, unsigned long n)
{
    if (n == 0)
        return 0;

    vector<Ski> lt, gt;
    Ski sk;
    for (int i = 0; i < n; i++)
    {
        int x = compare(student, skis[i]);
        if (x == -1)
            lt.push_back(skis[i]);
        else if (x == 1)
            gt.push_back(skis[i]);
        else
            sk = skis[i];
    }

    for (int i = 0; i < lt.size(); i++)
        skis[i] = lt[i];

    for (int i = 1; i <= gt.size(); i++)
        skis[lt.size() + i] = gt[i - 1];

    skis[lt.size()] = sk;

    return lt.size();
}

//Задача - реализовать этот метод.
//Ответ должен быть упорядочен по возрастанию номеров студентов(!), то есть их id.
//Ответы должны быть в этих же массивах.
void findPairs(Student* students, Ski* skis, unsigned long n)
{
    if (n < 2)
        return;

    unsigned long ski = Sort_Skis(skis, students[n / 2], n);
    unsigned long student = Sort_Students(students, skis[ski], n);

    findPairs(students, skis, student);
    findPairs(students + student + 1, skis + student + 1, n - student - 1);
}

void sortPairs(Student* students, Ski* skis, int first, int last)
{
        int i = first, j = last;
        int x = students[(first + last) / 2].id;

        do
        {
            while (students[i].id < x)
                i++;
            while (students[j].id > x)
                j--;

            if (i <= j)
            {
                if (i < j)
                {
                    swap(students[i], students[j]);
                    swap(skis[i], skis[j]);
                }
                i++;
                j--;
            }
        } while (i <= j);

        if (i < last)
            sortPairs(students, skis, i, last);
        if (first < j)
            sortPairs(students, skis, first, j);
}

int main()
{
    ReadWriter rw;

    Student* students = nullptr;
    Ski* skis = nullptr;
    int n;

    //Read n from file
    n = rw.readInt();

    //Create arrays
    students = new Student[n];
    skis = new Ski[n];

    //read Students and Skis from file
    rw.readStudents(students, n);
    rw.readSkis(skis, n);

    //Find pairs
    findPairs(students, skis, n);
    sortPairs(students, skis, 0, n - 1);

    //Write answer to file
    rw.writeStudentsAndSkis(students, skis, n);

    delete[] students;
    delete[] skis;

    return 0;
}
