#include <iostream>

using namespace std;

class computer{
             char name[20];
             int vom;
             char namev[20];
      public:
             virtual void show(){
                     cout << "Название компьютера: " << name << endl;
                     cout << "Объём оперативной памяти: " << vom << endl;
                     cout << "Название видеокарты: " << namev << endl;
             };
             computer(char name[20], int vom, char namev[20]){
                          this->name[20] = name[20];
                          this->vom = vom;
                          this->namev[20] = namev[20];
             }
};

class server{
             int cores;
             int channels;
             char spec[100];
      public:
             virtual void show(){
                     cout << "Количество ядер процессора: " << cores << endl;
                     cout << "Кол-во каналов связи с интернетом: " << channels << endl;
                     cout << "Особенности: " << spec << endl;
             };
             server(int cores, int channels, char spec[100]){
                        this->spec[100] = spec[100];
                        this->cores = cores;
                        this->channels = channels;
             };
};

class pc: public computer{
             bool sound;
             char scard[20];
             char tmouse[20];
      public:
             virtual void show(){
                     computer::show();
                     cout << "Наличие звука: " << sound << endl;
                     cout << "Тип мыши: " << tmouse << endl;
                     cout << "Название звуковой карты: " << scard << endl;
             };   
             pc(char scard[20], bool sound, char tmouse[20], char name[20], int vom, char namev[20]) : computer(name, vom, namev){
                          this->scard[20] = scard[20];
                          this->sound = sound;
                          this->tmouse[20] = tmouse[20];
             };
};

class notebook: public computer{
             int diag;
             int weight;
             int tbattery;
      public:
             virtual void show(){
                     computer::show();
                     cout << "Дигональ дисплея: " << diag << endl;
                     cout << "Время жизни батареи: " << tbattery << endl;
                     cout << "Вес: " << weight << endl;
             };
             notebook(int diag, int weight, int tbattery, char name[20], int vom, char namev[20]) : computer(name, vom, namev){
                          this->diag = diag;
                          this->weight = weight;
                          this->tbattery = tbattery;
             };
};

class ps: public notebook, public server{
             bool internet;
             char serv[20];
             char os[20];
      public:
             ps(bool internet, char serv[20]) :
};

int main(){
}
