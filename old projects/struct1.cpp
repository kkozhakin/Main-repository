#include <iostream>

using namespace std;

struct s{
       char clas[3];
       char sename[20];
       char name[20];
       char dat[8];
};

int main(){
    int n;
    char t[3], t1[20];
    cin >> n;
    s qwe[n];
    for (int i = 0; i < n; i++){
        cin >> qwe[i].sename;
        cin >> qwe[i].name;
        cin >> qwe[i].clas;
        cin >> qwe[i].dat;
    }
    for (int i = 0; i < n; i++)
        for (int j = n - 1; j > i; j--)
            if (qwe[j].clas < qwe[j - 1].clas){
                t = qwe[j].clas;
                qwe[j].clas = qwe[j - 1].clas;
                qwe[j - 1].clas = t;
            }
    for (int i = 0; i < n - 1; i++)
            if (qwe[i].clas == qwe[i + 1].clas)
               if (qwe[i].sename > qwe[i + 1].sename){
                  t1 = qwe[i].sename;
                  qwe[i].sename = qwe[i + 1].sename;
                  qwe[i + 1].sename = t1;
               }
    for (int i = 0; i < n; i++)
        cout << qwe[i].clas << " " << qwe[i].sename << " " << qwe[i].name << " " << qwe[i].dat << endl;
    return 0;
}
