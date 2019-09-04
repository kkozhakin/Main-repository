#include <iostream>

using namespace std;

int* createarray(int n, int b){
     int *a = new int[n];
     for (int i = 0; i < n; i++)
         a[i] = b;
     return a;
}

void printarray(int n, int* a){
     for (int i = 0; i < n; i++)
         cout << a[i] << " ";
     return;
}

int main() {
    int n = 10;
    int q = 2;
    int *a; 
    a = createarray(n, q);
    printarray(n, a);
    system("pause");
    return 0;
}
