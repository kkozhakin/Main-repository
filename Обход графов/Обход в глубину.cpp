#include <algorithm>
#include "ReadWriter.cpp"

//Можно добавлять любые методы для решения задачи.

//Задача - реализовать данный метод, решение должно быть в переменной result
void solve(std::vector<Node>& graph, int start, std::vector<std::string>& result)
{
    std::vector<Node*> stack;
    stack.push_back(&graph[start]);
   
    while(!stack.empty())
    {
        Node *startNode = stack.back();
        stack.pop_back();
        if (!startNode->visited)
        {
            startNode->visited = true;
            result.push_back(startNode->name);
        }

        start = 0;
        for (int i = 0; i != startNode->neighbours.size(); ++i)
            if (!startNode->neighbours[i]->visited)
            {
                stack.push_back(startNode->neighbours[i]);
                start++;
            }

        std::sort(stack.end() - start, stack.end(), [](const Node *lhs, const Node *rhs)
        {
            return lhs->name > rhs->name;
        });
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
