#include <iostream>
#include <array>

using namespace std;

array <int, 5> a;
array <int, 5> b;

int main(){
    srand(time(NULL));
    a.fill(rand()%21);
    for (int i = 0; i < 5; i++)
        cin >> b.at(i);
    cout << "������ ������:";
    for (int i = 0; i < 5; i++)
        cout << a.at(i) << " ";
    cout << endl << "������ ������:";
    for (int i = 0; i < 5; i++)
        cout << b.at(i) << " ";
    a.swap(b);
    cout << endl << "������ ������:";
    for (int i = 0; i < 5; i++)
        cout << a.at(i) << " ";
    cout << endl << "������ ������:";
    for (int i = 0; i < 5; i++)
        cout << b.at(i) << " ";
    system("pause");
    return 0;
}
