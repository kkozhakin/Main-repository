#include <iostream>
#include <exception>
#include <cmath>

using namespace std;

class pointsinlineex: public exception{
      const char* what() const{return "Points in one line.";}
};

class Verybigperex: public exception{
      const char* what() const{return "Very big perimetr.";}
};

class treug{
             int arr[3][2];
      public:
             treug(){
                     for (int i = 0; i < 3; i++)
                         for (int j = 0; j < 2; j++)
                             arr[i][j] = 1;
             }
             void set(int a, int b, int c){arr[a][b] = c;}
             float per();
             void show(){
                  if ((arr[0][0] == arr[1][0] == arr[2][0]) || (arr[0][1] == arr[1][1] == arr[2][1])){
                     throw pointsinlineex();
                  }
                  for (int i = 0; i < 3; i++){
                      for (int j = 0; j < 2; j++)
                          cout << arr[i][j] << " ";
                      cout << endl;
                  }
             }
};

float treug::per(){
     float p;
     p = sqrt((arr[0][0] - arr[1][0]) * (arr[0][0] - arr[1][0]) + (arr[0][1] - arr[1][1]) * (arr[0][1] - arr[1][1]));
     p += sqrt((arr[1][0] - arr[2][0]) * (arr[1][0] - arr[2][0]) + (arr[1][1] - arr[2][1]) * (arr[1][1] - arr[2][1]));
     p += sqrt((arr[2][0] - arr[0][0]) * (arr[2][0] - arr[0][0]) + (arr[2][1] - arr[0][1]) * (arr[2][1] - arr[0][1]));
     if (p > 1000) throw Verybigperex();
     return p;
}

int main(){
    treug q;
    int w;
    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 2; j++){
            cin >> w;
            q.set(i, j, w);
        }
    try{
        q.show();
        cout << q.per() << endl;
    }
    catch(exception &e){
              cout << e.what() << endl;
    }
    system("pause");
    return 0;   
}
