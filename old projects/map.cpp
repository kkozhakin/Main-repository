#include <iostream>
#include <map>
#include <string>

using namespace std;

int main(){
    string s;
    char c;
    int q;
    map <string, int> a;
    do{
        cin >> q >> c >> s;
        if (q == 1){
           cin >> q;
           a[s] += q;
        }
        if (q == 2)
           if (a.count(s) == 0) cout << "Error";
           else cout << a[s];
    }while (q != 0); 
    system("pause");
    return 0;
}
