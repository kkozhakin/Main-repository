////////////////////////////////////////////////////////////////////////////////
// Module Name:  linked_list.h/cpp
// Authors:      Sergey Shershakov, Leonid Dworzanski
// Version:      0.2.0
// Date:         06.02.2017
// Copyright (c) The Team of "Algorithms and Data Structures" 2014–2017.
//
// This is a part of the course "Algorithms and Data Structures"
// provided by  the School of Software Engineering of the Faculty
// of Computer Science at the Higher School of Economics.
//
// Отделенная часть заголовка шаблона класса "Связанный список"
//
////////////////////////////////////////////////////////////////////////////////

#include <stdexcept>

namespace xi {

    template <class T>
    LinkedList<T>::LinkedList()
    {
        //Creation of the dummy/sentinel element
        _preHead = new Node<T>;
        _preHead->next = nullptr;

        // TODO: Write your code here
        // ...
    }

    template <typename T>
    LinkedList<T>::LinkedList(const LinkedList<T>& linkedList)
    {
        _preHead = linkedList._preHead;
    }

    template <typename T>
    LinkedList<T>& LinkedList<T>::operator=(const LinkedList<T>& linkedList)
    {
        if (this != &linkedList)
        {
            delete[] _preHead;
            _preHead = linkedList._preHead;
        }
        return *this;
    }

    template <class T>
    LinkedList<T>::~LinkedList()
    {
        Node<T>* del = _preHead;
        Node<T>* del1 = _preHead;
        while(del1->next != nullptr)
        {
            del1 = del1->next;
            delete del;
            del = del1;
        }
        delete del1;
    }

    template <class T>
    Node<T>* LinkedList<T>::getPreHead()
    {
        return _preHead;
    }

    template <class T>
    void LinkedList<T>::moveNodeAfter(Node<T> *pNode, Node<T>* pNodeBefore)
    {
        if (!pNode || !pNodeBefore)
            return;
        Node<T>* del = pNodeBefore->next;
        pNodeBefore->next = del->next;
        del->next = pNode->next;
        pNode->next = del;
    }


    template <class T>
    void LinkedList<T>::deleteNextNode(Node<T>* pNodeBefore)
    {
        if (!pNodeBefore)
            return;
        Node<T>* del = pNodeBefore->next;
        pNodeBefore->next = pNodeBefore->next->next;
        delete del;
    }

    template <class T>
    void LinkedList<T>::moveNodeToEnd(Node<T>* pNodeBefore)
    {
        if (!pNodeBefore)
            return;
        Node<T>* del = _preHead;
        while(del->next != nullptr)
            del = del->next;
        Node<T>* del1 = pNodeBefore->next;
        del->next = del1;
        pNodeBefore->next = del1->next;
        del1->next = nullptr;
    }

    template <class T>
    void LinkedList<T>::moveNodesAfter(Node<T>* pNode, Node<T>* pNodeBefore, Node<T>* pNodeLast)
    {
        if (!pNode || !pNodeBefore || !pNodeLast)
            return;
        Node<T>* del = pNodeBefore->next;
        pNodeBefore->next = pNodeLast->next;
        pNodeLast->next = pNode->next;
        pNode->next = del;
    }

    template <class T>
    void LinkedList<T>::moveNodesToEnd(Node<T>* pNodeBefore, Node<T>* pNodeLast)
    {
        if (!pNodeBefore || !pNodeLast)
            return;
        Node<T>* del = _preHead;
        while(del->next != nullptr)
            del = del->next;
        del->next = pNodeBefore->next;
        pNodeBefore->next = pNodeLast->next;
        pNodeLast->next = nullptr;
    }

    template <class T>
    void LinkedList<T>::addElementToEnd(T& value)
    {
        if (!_preHead)
            return;
        Node<T>* del = _preHead;
        while(del->next != nullptr)
            del = del->next;
        Node<T>* del1 = new Node<T>;
        del1->next = nullptr;
        del1->value = value;
        del->next = del1;
    }

    template<class T>
    T &LinkedList<T>::operator[](int i)
    {
        if (i < 0)
            throw std::out_of_range("Index out of range");
        Node<T>* del = _preHead;
        for (int j = -1; j < i; ++j)
        {
            if (del->next == nullptr)
                throw std::out_of_range("Index out of range");
            del = del->next;
        }
        return del->value;
    }

    template<class T>
    int LinkedList<T>::size()
    {
       Node<T>* del = _preHead;
       int i = 0;
       while(del->next != nullptr)
       {
           del = del->next;
           ++i;
       }
       return i;
    }

    template<class T>
    void LinkedList<T>::deleteNodes(Node <T> *pNodeBefore, Node <T> *pNodeLast)
    {
        if (!pNodeBefore && !pNodeLast)
            return;
        Node<T>* del = pNodeBefore->next;
        Node<T>* del1 = pNodeBefore->next;
        while(del1 != pNodeLast)
        {
            del1 = del1->next;
            delete del;
            del = del1;

        }
        pNodeBefore->next = pNodeLast->next;
        delete del1;
    }

} // namespace xi