#include "NiceStack.h"

    template<typename T>
    NiceStack<T>::NiceStack(size_t capacity)
    {
        _storage = std::vector<TypeElementStack>(capacity);
        _capacity = capacity;
        _iHead = 0;
    }

    template<typename T>
    NiceStack<T>::~NiceStack() {};

    template<typename T>
    size_t NiceStack<T>::size() const { return _iHead; }

    template<typename T>
    void NiceStack<T>::push(const T& newelement)
    {
        if (_iHead >= _capacity)
            throw std::out_of_range("Stack overflow");
        _storage[_iHead].first = newelement;
        if (_iHead == 0)
            _storage[0].second = _storage[0].first;
        else
            _storage[_iHead].second = std::min(_storage[_iHead].first, _storage[_iHead - 1].second);
        ++_iHead;
    }

    template<typename T>
    T NiceStack<T>::NiceStack::pop()
    {
        if (_iHead == 0)
            throw std::out_of_range("Stack is empty");
        --_iHead;
        return _storage[_iHead].first;
    }

    template<typename T>
    const T& NiceStack<T>::NiceStack::top() const
    {
        if (_iHead == 0)
            throw std::out_of_range("Stack is empty");
        return _storage[_iHead - 1].first;
    }

    template<typename T>
    const T& NiceStack<T>::NiceStack::getMinimum() const
    {
        if (_iHead == 0)
            throw std::out_of_range("Stack is empty");
        return _storage[_iHead - 1].second;
    }
