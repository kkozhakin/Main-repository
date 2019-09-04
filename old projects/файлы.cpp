#include <iostream>
#include <fstream>

using namespace std;

int main(){
    ifstream f1("input.txt");
    ofstream f2("output.txt");
    char s, s1[200];
    int i = 0;
    while (!f1.eof()){
          f1 >> s;
          if (s != '\n') i++;
    }
    f2 << "Kolichestvo simvolov = " << i - 1 << endl;
    f1.close();
    ifstream f("input.txt");
    for (int i = 1; i < 3; i++){
        f.getline(s1, 200);
        f2 << s1 << endl;
    }
    f.getline(s1, 200);
    while (!f.eof()){
          f.getline(s1, 200);
          f2 << s1 << endl;
    }  
    f.close();
    f2.close();
    return 0;  
}
