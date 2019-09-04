#include <iostream>

using namespace std;

void matrix(int n = 10){
     for (int i = 0; i < n; i++){
         for (int j = 0; j < n; j++)
             cout << rand() % 11 << " ";
         cout << endl;
     }
     return;
}

int f1(int n){
    if (n == 0) return 0;
    else return f1(n / 10) + 1;
}

int f2(int n){
    if (n == 0) return 1;
    else return f2(n / 10) * (n % 10);
}

int main(){
    int n, v;
    cin >> n >> v;
    matrix(n);
    cout << f1(v) << " " << f2(v);
    system("pause");
    return 0;
}
