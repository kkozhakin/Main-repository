#include <iostream>

using namespace std;

int NOD(int a, int b){
    while(a > 0 && b > 0)
        if(a > b)
            a %= b;
        else
            b %= a;
    return a + b;
}

class fraction{
      private:
             int *a, *b;
      public:
             void show() {cout << *a / NOD(*a, *b) << "/" << *b / NOD(*a, *b) << endl;}
             fraction();
             fraction(int, int);
             fraction(const fraction&);
             fraction operator=(const fraction&); 
             fraction operator+(const fraction&);
             fraction operator/(const fraction&);
             fraction operator-(const fraction&);
             fraction operator*(const fraction&);
             fraction div(fraction, fraction);    
             ~fraction();     
};

fraction::fraction(int a, int b){
     this->a = new int(a);
     this->b = new int(b);
}

fraction::fraction(const fraction &f){
     this->a = new int(*f.a);
     this->b = new int(*f.b);
}

fraction fraction::operator+(const fraction& w){
         int new_a = (*this->a) * (*w.b) + (*this->b) * (*w.a);
         int new_b = (*this->b) * (*w.b);
         fraction q = fraction(new_a, new_b);
         return q;
}

fraction fraction::operator-(const fraction& w){
         int new_a = (*this->a) * (*w.b) - (*this->b) * (*w.a);
         int new_b = (*this->b) * (*w.b);
         fraction q = fraction(new_a, new_b);
         return q;
}

fraction fraction::operator/(const fraction& w){
         int new_a = (*this->a) * (*w.b);
         int new_b = (*this->b) * (*w.a);
         fraction q = fraction(new_a, new_b);
         return q;
}

fraction fraction::operator*(const fraction& w){
         int new_a = (*this->a) * (*w.a);
         int new_b = (*this->b) * (*w.b);
         fraction q = fraction(new_a, new_b);
         return q;
}

fraction fraction::operator=(const fraction &w) {
         *(this->a) = (*w.a);
         *(this->b) = (*w.b);
}

fraction::~fraction(){
                delete a;
                delete b;
}

int main(){
    int q1, q2, q3, q4;
    cin >> q1 >> q2 >> q3 >> q4;
    fraction a(q1, q2), b(q3, q4);
    cout << "SUM: ";
    fraction w = a + b;
    w.show();
    cout << "SUB: ";
    fraction r = a - b;
    r.show();
    cout << "MUL: ";
    fraction e = a * b;
    e.show();
    cout << "DIV: ";
    fraction q = a / b;
    q.show();
    return 0;
}
