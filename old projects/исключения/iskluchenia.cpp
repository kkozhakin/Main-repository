#include <iostream>
#include <exception>

using namespace std;

int n = 10;

class Emptyarrayexception: public exception{
      const char* what() const{return "Array is empty.";}
};

class Lessthanzeroex: public exception{
      const char* what() const{return "Very small number.";}
};

class array{
             int* arr;
      public:
             array(int* arr){this->arr = arr;}
             void add(int a);
             void del(int a);
             void show(){
                  for (int i = 0; i < n; i++)
                      cout << arr[i] << " ";
             }
             ~array(){delete[] arr;}
};

void array::add(int a){
     if (a < 0) throw Lessthanzeroex();
     int* temp = new int[n + 1];
		for (int i = 0; i < n; ++i)
			temp[i] = arr[i];
		delete[] arr;
		arr = temp;
		arr[n++] = a;
}

void array::del(int a){
     if (n == 0) throw Emptyarrayexception();
     for (int i = a - 1; i < n - 1; i++)
         arr[i] = arr[i + 1];
     --n;
}

int main(){
    int a[n];
    for (int i = 0; i < n; i++)
        cin >> a[i];
    array q(a);
    try{
        q.del(4);
        q.add(12);
        q.show();
    }
    catch(exception &e){
              cout << e.what() << endl;
    }
    system("pause");
    return 0;   
}
