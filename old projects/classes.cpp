#include <iostream>

using namespace std;

class time1{
      private:
              int h;
              int m;
              int s;
      public:
             void show();
             void timeadd(time1 a, time1 b);
             void setparam(int h, int m, int s);
             void trans(int s);        
             ~time1();     
};

void time1::setparam(int h, int m, int s){
     this->h = h;
     this->m = m;
     this->s = s;
}

void time1::trans(int sec){
     int h, m;
     h = sec / 3600;
     sec = sec % 3600;
     m = sec / 60;
     sec = sec % 60;
     setparam(h, m, sec);
     return;
}

void time1::timeadd(time1 a, time1 b){
    b.s += a.s;
    if (b.s >=60) {
            b.s -= 60;
            b.m += 1;
    }
    b.m += a.m;
    if (b.m >= 60) { 
            b.m -= 60;
            b.h = 1;
    }
    b.h += a.h;
}

time1::~time1(){
                if (h < 10) cout << "0" << h << ":"; else
                cout <<  h << ":";
                if (m < 10) cout << "0" << m << ":"; else
                cout <<  m << ":";
                if (s < 10) cout << "0" << s; else
                cout << s;}

int main(){
    time1 a, b;
    int s;
    cout << "Введите начальное время (в секундах): " << endl;
    cin >> s;
    a.trans(s);
    cout << "Введите добавочное время (в секундах): " << endl;
    cin >> s;
    b.trans(s);
    a.timeadd(a, b);
    cout << "Начальное время: ";
    a.~time1();
    cout << endl << "Конечное время: ";
    b.~time1();
    system("pause");
    return 0;
}
