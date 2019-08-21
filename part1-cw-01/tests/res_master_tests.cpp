////////////////////////////////////////////////////////////////////////////////
/// \file
/// \brief     Unit tests for ResMaster class.
/// \author    Sergey Shershakov
/// \version   0.1.0
/// \date      30.09.2018
///            This is a part of the course "Algorithms and Data Structures" 
///            provided by  the School of Software Engineering of the Faculty 
///            of Computer Science at the Higher School of Economics.
///
/// Gtest-based unit test.
/// The naming conventions imply the name of a unit-test module is the same as 
/// the name of the corresponding tested module with _test suffix.
///
/// Note the issue about including point modules here (ask the trainer about).
/// 
////////////////////////////////////////////////////////////////////////////////

#include <gtest/gtest.h>


#include "res_master.h"




TEST(ResMaster, simplest)
{
    EXPECT_TRUE(true);
}


// тестируем дефолтный конструктор
TEST(ResMaster, defConstr)
{
    ResMaster rm;

    // локальный массив из нулей
    EXPECT_EQ(int(0), rm.getLocEl(0));


    // динамический массив не представлен
    EXPECT_EQ(int(0), rm.getArrSize());
    EXPECT_THROW(rm.getArrEl(0), std::out_of_range);
}


// тестируем конструктор инициализации
TEST(ResMaster, initConstr)
{
    ResMaster rm(5);        // 5 дин. элементов, в локальном — пятерки

    // локальный массив из 5-ок
    EXPECT_EQ(5, rm.getLocEl(0));

    // динамический массив
    EXPECT_EQ(5, rm.getArrSize());
    EXPECT_EQ(1, rm.getArrEl(0));
}

// тестируем конструктор копирования
TEST(ResMaster, copyConstr)
{
    ResMaster rm;

    // локальный массив из нулей
    EXPECT_EQ(int(0), rm.getLocEl(0));
    EXPECT_THROW(rm.getLocEl(10), std::out_of_range);
    EXPECT_EQ(int(0), rm.getArrSize());
    EXPECT_THROW(rm.getArrEl(0), std::out_of_range);

    // копия
    ResMaster cpy(rm);
    EXPECT_EQ(int(0), cpy.getLocEl(0));
    EXPECT_THROW(cpy.getLocEl(10), std::out_of_range);
    EXPECT_EQ(int(0), cpy.getArrSize());
    EXPECT_THROW(cpy.getArrEl(0), std::out_of_range);

}

// тестируем операцию копирования
TEST(ResMaster, copyOper)
{
    ResMaster rm;

    EXPECT_EQ(int(0), rm.getArrSize());
    EXPECT_THROW(rm.getArrEl(0), std::out_of_range);

    // с элементами
    ResMaster rm1(5);        // 5 дин. элементов, в локальном — пятерки

    EXPECT_EQ(5, rm1.getLocEl(0));

    rm = rm1;
    EXPECT_EQ(5, rm.getLocEl(0));
    EXPECT_THROW(rm.getLocEl(10), std::out_of_range);
}

