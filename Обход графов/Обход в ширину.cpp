#include "ReadWriter.cpp"
#include <list>
#include <algorithm>

//Можно добавлять любые методы для решения задачи.

//Задача - реализовать данный метод, решение должно быть в переменной result
void solve(std::vector<Node>& graph, int start, std::vector<std::string>& result){
    std::list<Node> queue;

    graph[start].visited = true;
    queue.push_back(graph[start]);
    start = 1;

    while(!queue.empty())
    {
        Node startNode = queue.front();
        result.push_back(startNode.name);
        queue.pop_front();
        start--;

        for (int i = 0; i != startNode.neighbours.size(); ++i)
        {
            if (!startNode.neighbours[i]->visited)
            {
                startNode.neighbours[i]->visited = true;
                queue.push_back(*startNode.neighbours[i]);
            }
        }

        if (start == 0)
        {
            queue.sort([ ]( const Node& lhs, const Node& rhs )
            {
                return lhs.name < rhs.name;
            });
            start = queue.size();
        }
    }
}

int main() {
    std::vector<Node> graph;
    std::vector<std::string> result;
    int start;

    ReadWriter rw;
    rw.readGraph(graph, start);
    solve(graph, start, result);
    rw.writeAnswer(result);
    return 0;
}
