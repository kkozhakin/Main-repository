////////////////////////////////////////////////////////////////////////////////
// Module Name:  dna_repairer.h/cpp
// Authors:      Sergey Shershakov, Leonid Dworzanski
// Version:      0.2.0
// Date:         06.02.2017
// Copyright (c) The Team of "Algorithms and Data Structures" 2014–2017.
//
// This is a part of the course "Algorithms and Data Structures" 
// provided by  the School of Software Engineering of the Faculty 
// of Computer Science at the Higher School of Economics.
////////////////////////////////////////////////////////////////////////////////


#include "dna_element.h"
#include <math.h>

DNAElement::DNAElement()
= default;

DNAElement::DNAElement(const std::string &description)
{
    readFromString(description);
}

void DNAElement::readFromString(const std::string &description)
{
    if ( description.length() < 4 || description[0] > 'z' || description[0] < 'a'
    || (description[description.length() - 1] != 'A' & description[description.length() - 1] != 'C'
    & description[description.length() - 1] != 'T' & description[description.length() - 1] != 'G')
    || description[description.length() - 2] != ':')
        throw std::invalid_argument("");
    id = description[0];
    base = description[description.length() - 1];
    try {
        for (int i = 1; i < description.length() - 2; ++i)
        {
            if (description[i] > '9' || description[i] < '0')
                throw std::invalid_argument("");
            number += ((int) description[i] - '0') * pow(10, description.length() - 3 - i);
            if (number < 0)
                throw std::invalid_argument("");
        }
    }catch (std::exception e)
    {
        throw std::invalid_argument("");
    }
}
