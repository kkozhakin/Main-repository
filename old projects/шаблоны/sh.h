#include <iostream>

using namespace std;

template <class T> 
class array{
             T* arr;
      public:
             array(T* arr){this->arr = arr;}
             void add();
             T del();
             void show(){
                  for (int i = 0; i < n; i++)
                      cout << arr[i] << " ";
             }
             ~array(){delete[] arr;}
};

template <class T>
void array<T>::add(){
     if (n == k) throw Fullarrayexception();
     T a;
     cin >> a;
     n++;
     for (int i = n - 1; i > 0; i--)
         arr[i] = arr[i - 1];
     arr[0] = a;
}

template <class T>
T array<T>::del(){
     if (n == 0) throw Emptyarrayexception();
     T a;
     a = arr[n];
     arr[n] = 0;
     --n;
     return a;
}
