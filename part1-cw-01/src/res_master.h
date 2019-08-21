////////////////////////////////////////////////////////////////////////////////
/// \file
/// \brief     Resource Master class declaration.
/// \author    Student Name
/// \version   0.1.0
/// \date      05.10.2018
///            This is a part of the course "Algorithms and Data Structures" 
///            provided by  the School of Software Engineering of the Faculty 
///            of Computer Science at the Higher School of Economics.
///
/// Implementations for the methods declared in the classes below must be put
/// in corresponding module named res_master.cpp.
///
////////////////////////////////////////////////////////////////////////////////


#ifndef CW1_RES_MASTER_H_
#define CW1_RES_MASTER_H_

#include <stddef.h>     // need for size_t


/// Магистер ресурсов. Умеет создавать, владеть, воспроизводить и уничтожать.
class ResMaster
{
public:
    /// Константа определяет размер стекового (статического) массива.
    static const int NAME_ARR_SIZE = 10;

    /// Псевдоним для беззнакового целого типа.
    typedef unsigned int UInt;

public:
    /// Конструктор по умолчанию. Динамический массив _arr нулевой длины.
    /// Заполняет локальный массив _loc нулями.
    ResMaster();

    /// Конструктор создает массив _arr длиной arrSize элементов (размер доступен
    /// затем через getArrSize()), и заполняет его значениями [1, 2, ... arrSize]
    /// Значение массива _loc заполняется числом arrSize: [arrSize, arrSize, arrSize....]
    explicit ResMaster(size_t arrSize);

    /// Конструктор копирования создает правильную копию ресурсов, которыми управляет
    /// копируемый объект этого класса.
    ResMaster(const ResMaster& other);

    /// Деструктор правильно освобождает ресурсы, которыми управляет
    /// загибающийся объект этого класса.
    ~ResMaster();

public:
    /// Перегруженная операция копирования.
    /// Рекомендуется (хотя и не обязательно) реализовывать с помощью copy-n-swap.
    ResMaster& operator=(const ResMaster& rhv);

public:
    /// Возвращает k-й (индексирует с нуля) элемент динамического массива _arr.
    /// Если в массиве элементов меньше, чем k + 1, кидает std::out_of_range exception.
    int getArrEl(UInt k) const;

    /// Возвращает размер динамического массива _arr. Возвращает 0, если массив пустой.
    size_t getArrSize() const { return _arrSize; }

    /// Возвращает значение k-того (индексирует с нуля) элемента массива _loc.
    /// Если в массиве элементов меньше, чем k + 1, кидает std::out_of_range exception.
    int getLocEl(UInt k) const;

protected:

    // TODO: Здесь можно дописать необходимые для декомпозиции задачи методы.

protected:
    int*    _arr;                   ///< Держатель динамического массива из целых.
    size_t  _arrSize;               ///< Рамер динамического массива.

    int    _loc[NAME_ARR_SIZE];     ///< Локальный ("статический") массив целых.
}; // class ResMaster


#endif //CW1_RES_MASTER_H_
