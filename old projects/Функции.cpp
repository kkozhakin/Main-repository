#include <iostream>

using namespace std;

int* crarr(int n,int  k){
     int *a = new int[n];
     for (int i = 0; i < n; i++)
         a[i] = k;
     return a;
}

int max(int *a,int n){
    int c = a[0], ci = 0;
    for (int i = 0; i < n - 1; i++){
         if (a[i] < a[i + 1]) c = a[i + 1];
         ci = i + 1;
    } 
    return ci;
}

int main(){
    int k, n;
    cin >> n >> k;
    cout << max(crarr(n,k), n);
    system("pause");
    return 0;
}
