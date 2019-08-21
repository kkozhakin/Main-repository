﻿////////////////////////////////////////////////////////////////////////////////
/// \file
/// \brief     Definition of some methods for class Subject
/// \author    Sergey Shershakov
/// \version   0.2.0
/// \date      30.01.2017
///            This is a part of the course "Algorithms and Data Structures" 
///            provided by  the School of Software Engineering of the Faculty 
///            of Computer Science at the Higher School of Economics.
///
///
////////////////////////////////////////////////////////////////////////////////


#include "subject.h"



namespace xi {


std::ostream& operator<<(std::ostream& outs, const Subject& subj)
{   
    outs << subj.name << ": " << subj.title << "\n";
   
    int index = 0;
    int maxSubj = subj.description.getCapacity();

    while (index < maxSubj && subj.description[index] != "")
        outs << subj.description[index++] << "\n";

    return outs;
}


std::istream& operator>>(std::istream& ins, Subject& subj)
{

    std::string str, name, title;
    auto* str1 = new std::string[10];
    SafeArray<std::string> description = SafeArray<std::string>(10);
    getline(ins, name);
    getline(ins, title);
    getline(ins, str);
    int index = 0;

    while (!str.empty())
    {
       str1[index] = str;
       index++;
       getline(ins, str);
    }

    for (int i = 0; i < index; i++)
    {
        description[i] = str1[i];
    }

    subj.name = name;
    subj.title = title;
    subj.description = description;

    return ins;
}


} // namespace xi

