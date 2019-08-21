#include <set>
#include <list>
#include "ReadWriter.h"
//string, fstream, iostream, vector, algorithm, Edge.h - included in ReadWriter.h

//Можно создавать любые классы и методы для решения задачи

using namespace std;

//Основной метод решения задачи, параметры:
//N - количество вершин, M - количество ребер в графе
//edges - вектор ребер, каждое ребро представлено 3-мя числами (А,В,W), где A и B - номера вершин, которые оно соединяет, и W - вес ребра,
//передается по ссылке (&), чтобы не копировать, изменять вектор и его значения можно.
//Результат также в виде вектора ребер, передается по ссылке (&), чтобы не копировать его.
vector<int> p(0);

int dsu_get (int v)
{
    return (v == p[v]) ? v : (p[v] = dsu_get (p[v]));
}

void dsu_unite (int a, int b) {
    a = dsu_get (a);
    b = dsu_get (b);
    if (rand() & 1)
        swap (a, b);
    if (a != b)
        p[a] = b;
}


void solve(int N, int M, vector<Edge>& edges, vector<Edge>& result)
{
    int cost = 0;

    sort (edges.begin(), edges.end(), [](const Edge lhs, const Edge rhs)
    {
        return lhs.W < rhs.W;
    });

    p.resize (N);
    for (int i=0; i<N; ++i)
        p[i] = i;

    for (int i=0; i<M; ++i)
    {
        int a = edges[i].A,  b = edges[i].B,  l = edges[i].W;
        if (dsu_get(a) != dsu_get(b))
        {
            cost += l;
            Edge e = Edge();
            e.A = a;
            e.B = b;
            e.W = cost;
            result.push_back(e);
            dsu_unite (a, b);
            cost = 0;
        }
    }

}

int main()
{
    ReadWriter rw;
    //Входные параметры
    //N - количество вершин, M - количество ребер в графе
    int N, M;
    rw.read2Ints(N, M);

    //Вектор ребер, каждое ребро представлено 3-мя числами (А, В, W), где A и B - номера вершин, которые оно соединяет, и W - вес ребра
    //Основной структурой выбран вектор, так как из него проще добавлять и удалять элементы (а такие операции могут понадобиться).
    vector<Edge> edges;
    rw.readEgdes(M, edges);

    //Основной структурой для ответа выбран вектор, так как в него проще добавлять новые элементы.
    //(а предложенные алгоритмы работают итеративно, увеличивая количество ребер входящих в решение на каждом шаге)
    vector<Edge> result;

    //Алгоритм решения задачи
    //В решение должны входить ребра из первоначального набора!
    solve(N, M, edges, result);

    //Выводим результаты
    rw.writeInt(result.size());
    rw.writeEdges(result);

    return 0;
}