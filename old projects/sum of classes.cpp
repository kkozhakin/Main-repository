#include <iostream>

using namespace std;

struct time1{
       int h;
       int m;
       int s;
};

void f(time1 &a, time1 &b){
    cin >> a.s >> a.m >> a.h;
    cin >> b.s >> b.m >> b.h;
    a.s += b.s;
    if (a.s >=60) {
            a.s -= 60;
            a.m += 1;
    }
    a.m+= b.m;
    if (a.m >=60) { 
            a.m-= 60;
            a.h= 1;
    }
    a.h+= b.h;
    if (a.h >=24) 
       a.h = 0;
    cout << a.h << " " << a.m << " " << a.s;
}

int main(){
    time1 a, b;
    f(a,b);
    system("pause");
    return 0;
}
