#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <stack>
#include <set>
#include <stdlib.h>
#include <algorithm>

using namespace std;

vector<int> res;
vector<bool> visited;

void dfs(int v, vector<vector<int>> relations, const vector<string> &names)
{
    visited[v] = true;
    vector<int> vec;

    for (int i : relations[v])
        if (!visited[i])
            vec.push_back(i);

    sort(vec.begin(), vec.end(), [names](const int lhs, const int rhs)
    {
        return names[lhs] < names[rhs];
    });

    for (int i : vec)
        if (!visited[i])
            dfs(i, relations, names);

    res.push_back(v);
}

vector<string> getList(vector<string> names, const vector<vector<int>> &relations, vector<vector<int>> relations_1)
{
    vector<int> vec;
    vector<string> dfsn;
    visited.assign(relations.size(), false);

    for (int i = 0; i < relations_1.size(); ++i)
        if (relations_1[i].empty())
            vec.push_back(i);

    sort(vec.begin(), vec.end(), [names](const int lhs, const int rhs)
    {
        return names[lhs] < names[rhs];
    });

    for (int v : vec)
        dfs(v, relations, names);

    for (int i : res)
        dfsn.push_back(names[i]);

    reverse (dfsn.begin(), dfsn.end());

    return dfsn;
}

int main()
{
    vector<string> names = vector<string>();
    vector<vector<int>> relations, relations_1;

    ifstream fin;
    fin.open("input.txt");
    if (fin.is_open())
    {
        string str = "";
        getline(fin, str);

        while (str != "#")
        {
            names.emplace_back(str.substr(str.find(' ') + 1));
            getline(fin, str);
        }

        relations = vector<vector<int>>(names.size());
        relations_1 = vector<vector<int>>(names.size());

        getline(fin, str);

        while (fin)
        {
            int a = stoi(str.substr(0, str.find(' '))) - 1;
            int b = stoi(str.substr(str.find(' '))) - 1;
            relations[a].push_back(b);
            relations_1[b].push_back(a);
            getline(fin, str);
        }

        fin.close();
    }

    vector<string> res = getList(names, relations, relations_1);

    fstream fout;
    fout.open("output.txt", ios::out);
    for (int i = 0; i < res.size(); i++)
        fout << res[i] << "\n";
    fout.close();

    return 0;
}