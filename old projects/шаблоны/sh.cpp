#include <iostream>
#include <exception>


using namespace std;

int k = 10, n = 0;

class Emptyarrayexception: public exception{
      const char* what() const{return "Queue is empty.";}
};

class Fullarrayexception: public exception{
      const char* what() const{return "Queue is full.";}
};

#include "sh.h"

int main(){
    int a[k];
    int m;
    for (int i = 0; i < k; i++)
        a[i] = 0;
    array <int> q(a);
    try{
        q.add();
        q.add();
        q.add();
        m = q.del();
        q.add();
        q.show();
    }
    catch(exception &e){
              cout << e.what() << endl;
    }
    system("pause");
    return 0;   
}
