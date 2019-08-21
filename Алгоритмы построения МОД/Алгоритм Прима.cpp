#include <set>
#include <list>
#include <queue>
#include "ReadWriter.h"
//string, fstream, iostream, vector, algorithm, Edge.h - included in ReadWriter.h

//Можно создавать любые классы и методы для решения задачи

using namespace std;

//Основной метод решения задачи, параметры:
//N - количество вершин, M - количество ребер в графе
//edges - вектор ребер, каждое ребро представлено 3-мя числами (А,В,W), где A и B - номера вершин, которые оно соединяет, и W - вес ребра,
//передается по ссылке (&), чтобы не копировать, изменять вектор и его значения можно.
//Результат также в виде вектора ребер, передается по ссылке (&), чтобы не копировать его.

vector<bool> used;
vector<int> key;

int minKey(int n)
{
    int min = 30002, min_id = -1;
    for (int i = 0; i < n; ++i)
        if (!used[i] && key[i] < min)
        {
            min = key[i];
            min_id = i;
        }
    return min_id;
}

void solve(int N, int M, vector<Edge>& edges, vector<Edge>& result)
{
    used.assign(N, false);
    key.assign(N, 30001);
    vector<int> parent(N);
    vector<vector<int>> ed = vector<vector<int>>(N);
    for (int i = 0; i < N; ++i)
    {
        ed[i] = vector<int>(N);
        for (int j = 0; j < N; ++j)
            ed[i][j] = -1;
    }
    for (Edge &e : edges)
    {
        ed[e.A][e.B] = e.W;
        ed[e.B][e.A] = e.W;
    }

    key[0] = 0;
    parent[0] = -1;

    for (int i = 0; i < N - 1; i++)
    {
        int tmp = minKey(N);
        used[tmp] = true;
        for (int j = 0; j < N; j++)
            if (!used[j] && ed[tmp][j] != -1 && ed[tmp][j] < key[j])
            {
                parent[j] = tmp;
                key[j] = ed[tmp][j];
            }
    }

    for (int k = 1; k < N; ++k)
        if (ed[parent[k]][k] != -1)
        {
            Edge *edge = new Edge();
            edge->W = ed[parent[k]][k];
            for (Edge &e : edges)
            {
                if (e.A == parent[k] && e.B == k)
                {
                    edge->A = parent[k];
                    edge->B = k;
                    break;
                }
                if (e.B == parent[k] && e.A == k)
                {
                    edge->B = parent[k];
                    edge->A = k;
                }
            }
            result.push_back(*edge);
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