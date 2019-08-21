#include "ReadWriter.h"
//string, fstream, iostream, vector, algorithm, Edge.h - included in ReadWriter.h

//Можно создавать любые классы и методы для решения задачи

using namespace std;

//Основной метод решения задачи, параметры:
//N - количество вершин, M - количество ребер в графе
//edges - вектор ребер, каждое ребро представлено 3-мя числами (А,В,W), где A и B - номера вершин, которые оно соединяет, и W - вес ребра,
//передается по ссылке (&), чтобы не копировать, изменять вектор и его значения можно.
//Результат также в виде вектора ребер, передается по ссылке (&), чтобы не копировать его.
struct Set
{
    int parent;
    int rank;
};

int find (Set parent[], int i)
{
    if (parent[i].parent != i)
        parent[i].parent = find(parent, parent[i].parent);
    return parent[i].parent;
}

void unite (Set parent[], int a, int b)
{
    int A = find (parent, a);
    int B = find (parent, b);

    if (parent[A].rank < parent[B].rank)
        parent[A].parent = B;
    else if (parent[A].rank > parent[B].rank)
        parent[B].parent = A;
    else
    {
        parent[B].parent = A;
        parent[A].rank++;
    }
}
void solve(int N, int M, vector<Edge>& edges, vector<Edge>& result)
{
    Set *set = new Set[N];
    vector<int> keys(N, -1);

    for (int i = 0; i < N; i++)
    {
        set[i].parent = i;
        set[i].rank = 0;
    }

    int n = N;
    while (n > 1)
    {
        keys.assign(N, -1);

        for (int j = 0; j < M; j++)
        {
            int l = find(set, edges[j].A);
            int r = find(set, edges[j].B);
            if (l == r)
                continue;
            else
            {
                if (keys[l] == -1 || edges[keys[l]].W > edges[j].W)
                    keys[l] = j;
                if (keys[r] == -1 || edges[keys[r]].W > edges[j].W)
                    keys[r] = j;
            }
        }
        for (int i = 0; i < N; i++)
        {
            if (keys[i] != -1)
            {
                int l = find(set, edges[keys[i]].A);
                int r = find(set, edges[keys[i]].B);
                if (l == r)
                    continue;

                result.push_back(edges[keys[i]]);
                unite(set, l, r);
                n--;
            }
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