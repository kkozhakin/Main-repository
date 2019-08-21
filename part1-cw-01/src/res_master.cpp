////////////////////////////////////////////////////////////////////////////////
// Module Name:  res_master.h/cpp
// Authors:      Student Name
// Version:      0.1.0
// Date:         05.10.2018
//
// This is a part of the course "Algorithms and Data Structures" 
// provided by  the School of Software Engineering of the Faculty 
// of Computer Science at the Higher School of Economics.
////////////////////////////////////////////////////////////////////////////////

#include "res_master.h"
#include <stdexcept>


// #incude...

//=============================================================================
// class ResMaster
//=============================================================================

ResMaster::ResMaster()
{
    _arrSize = 0;
    _arr = new int[0];
    for (int &i : _loc)
        i = 0;
}

ResMaster::~ResMaster()
{
    delete[] _arr;
    _arrSize = 0;
}

ResMaster::ResMaster(size_t arrSize)
{
    _arrSize = arrSize;
    _arr = new int[arrSize];
    for (int &i : _loc)
        i = arrSize;

    for (int i = 0; i < arrSize; ++i)
        _arr[i] = i + 1;
}

ResMaster::ResMaster(const ResMaster& other)
{
    _arrSize = other.getArrSize();
    _arr = new int[_arrSize];
    for (int i = 0; i < _arrSize; i++)
        _arr[i] = other._arr[i];

    for (int i = 0; i < NAME_ARR_SIZE; i++)
        _loc[i] = other._loc[i];
}

ResMaster& ResMaster::operator=(const ResMaster &rhv)
{
    if (this != &rhv)
    {
        delete[] _arr;
        _arrSize = rhv.getArrSize();
        _arr = new int[_arrSize];
        for (int i = 0; i < _arrSize; i++)
            _arr[i] = rhv._arr[i];
        for (int i = 0; i < NAME_ARR_SIZE; i++)
            _loc[i] = rhv._loc[i];
    }
    return *this;
}

int ResMaster::getArrEl(UInt k) const
{
    if (k >= _arrSize)
        throw std::out_of_range("Index out of range");
    return _arr[k];
}

int ResMaster::getLocEl(UInt k) const
{
    if (k >= NAME_ARR_SIZE)
        throw std::out_of_range("Index out of range");
    return _loc[k];
}