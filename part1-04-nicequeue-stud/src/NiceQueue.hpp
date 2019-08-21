#include <algorithm>
#include "NiceQueue.h"

    template<typename T>
    NiceQueue<T>::NiceQueue(size_t capacity) : _inStack(42), _outStack(42)
    {
        _capacity = capacity;
        _inStack = NiceStack<T>(capacity);
        _outStack = NiceStack<T>(capacity);
    }

    template<typename T>
    NiceQueue<T>::~NiceQueue() {}

    template<typename T>
    size_t NiceQueue<T>::size() const
    {
        return _inStack.size() + _outStack.size();
    }

    template<typename T>
    void NiceQueue<T>::enq(const T& newElement)
    {
        if (_inStack.size() >= _capacity)
            throw std::out_of_range("Queue overflow");
         _inStack.push(newElement);
    }

    template<typename T>
    T NiceQueue<T>::deq()
    {
        if (_inStack.size() + _outStack.size() == 0)
            throw std::out_of_range("Queue is empty");
        if  (_outStack.size() == 0)
            for (int i = 0; i < _inStack.size() + _outStack.size(); ++i)
                _outStack.push(_inStack.pop());
        return _outStack.pop();
    }

    template<typename T>
    T NiceQueue<T>::getMinimum()
    {
        return _inStack.getMinimum();
    }

