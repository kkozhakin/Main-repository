#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <stack>
#include <set>
#include <stdlib.h>
#include <algorithm>

using namespace std;

vector<vector<int>> g, gr;
vector<bool> used;
vector<int> order, component;

void dfs1 (int v)
{
    used[v] = true;
    for (int i : g[v])
        if (!used[i])
            dfs1(i);
    order.push_back(v);
}

void dfs2 (int v)
{
    used[v] = true;
    component.push_back(v);
    for (int i : gr[v])
        if (!used[i])
            dfs2 (i);
}


vector<vector<string>> getList(vector<string>& names, vector<vector<bool>>& relations)
{
    vector<vector<int>> vec;
    g = vector<vector<int>>(names.size());
    gr = vector<vector<int>>(names.size());

    for (int a = 0; a < names.size(); ++a)
        for (int b = 0; b < names.size(); ++b)
            if (relations[a][b])
            {
                g[a].push_back(b);
                gr[b].push_back(a);
            }

    used.assign(names.size(), false);
    for (int i = 0; i < names.size(); ++i)
        if (!used[i])
            dfs1(i);

    used.assign(names.size(), false);

    for (int i = 0; i < names.size(); ++i)
    {
        int v = order[names.size() - 1 - i];
        if (!used[v])
        {
            dfs2(v);
            sort(component.begin(), component.end(), [names](const int lhs, const int rhs)
            {
                return names[lhs] < names[rhs];
            });
            vec.push_back(component);
            component.clear();
        }
    }
    vector<string> comp;
    vector<vector<string>> str;
    for (int j = 0; j < vec.size(); ++j)
    {
        for (int i = 0; i < vec[j].size(); ++i)
            comp.push_back(names[vec[j][i]]);
        str.push_back(comp);
        comp.clear();
    }
    sort(str.begin(), str.end(), [](const vector<string> lhs, const vector<string> rhs)
    {
        return lhs[0] < rhs[0];
    });
    return str;
}

int main()
{
    vector<string> names = vector<string>();
    vector<vector<bool>> relations;
    int startIndex;

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

        relations = vector<vector<bool>>(names.size());

        for (int i = 0; i < names.size(); i++)
        {
            relations[i] = vector<bool>(names.size());
            for (int j = 0; j < names.size(); j++)
                relations[i][j] = false;
        }

        getline(fin, str);

        while (fin)
        {
            int a = stoi(str.substr(0, str.find(' '))) - 1;
            int b = stoi(str.substr(str.find(' '))) - 1;
            relations[a][b] = true;
            getline(fin, str);
        }

        fin.close();
    }

    vector<vector<string>> res = getList(names, relations);

    fstream fout;
    fout.open("output.txt", ios::out);
    for (int i = 0; i < res.size(); i++)
    {
        for (int j = 0; j < res[i].size(); j++)
            fout << res[i][j] << "\n";
        fout << "\n";
    }
    fout.close();

    return 0;
}