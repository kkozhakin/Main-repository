////////////////////////////////////////////////////////////////////////////////
// Module Name:  stack_machine.h/cpp
// Authors:      Sergey Shershakov
// Version:      0.2.0
// Date:         23.01.2017
//
// This is a part of the course "Algorithms and Data Structures" 
// provided by  the School of Software Engineering of the Faculty 
// of Computer Science at the Higher School of Economics.
////////////////////////////////////////////////////////////////////////////////

#include "stack_machine.h"

#include <vector>
#include <cmath>
#include <sstream>
#include <iostream>
#include <cstdlib>
#include <climits>

namespace xi {

//==============================================================================
// Free functions -- helpers
//==============================================================================

    int Int(std::string ch)
    {
        int num = 0;
        for (int i = 0; i <  ch.length(); i++)
        {
            switch (ch[ch.length() - 1 - i])
            {
                case '+':
                    break;
                case '-':
                    num *= -1;
                    break;
                case '1':
                    num += pow(10, i);
                    break;
                case '2':
                    num += 2 * pow(10, i);
                    break;
                case '3':
                    num += 3 * pow(10, i);
                    break;
                case '4':
                    num += 4 * pow(10, i);
                    break;
                case '5':
                    num += 5 * pow(10, i);
                    break;
                case '6':
                    num += 6 * pow(10, i);
                    break;
                case '7':
                    num += 7 * pow(10, i);
                    break;
                case '8':
                    num += 8 * pow(10, i);
                    break;
                case '9':
                    num += 9 * pow(10, i);
                    break;
                default:
                    num += 0;
                    break;
            }
        }
        return num;
    }

    int Sign(int x)
    {
        if (x >= 0)
            return 1;
        return -1;
    }
//==============================================================================
// class PlusOp
//==============================================================================


    int PlusOp::operation(char op, int a, int b, int /*c*/) // < just commented unused argument. This does not affect the code anyhow.
    {
        if(op != '+')
            throw std::logic_error("Operation other than Plus (+) are not supported");

        // here we just ignore unused operands
        return a + b;
    }

    IOperation::Arity PlusOp::getArity() const
    {
        return arDue;
    }

//==============================================================================
// class MinusOp
//==============================================================================


    int MinusOp::operation(char op, int a, int b, int /*c*/) // < just commented unused argument. This does not affect the code anyhow.
    {
        if(op != '-')
            throw std::logic_error("Operation other than Minus (-) are not supported");

        // here we just ignore unused operands
        return a - b;
    }

    IOperation::Arity MinusOp::getArity() const
    {
        return arDue;
    }

//==============================================================================
// class MultOp
//==============================================================================


    int MultOp::operation(char op, int a, int b, int /*c*/) // < just commented unused argument. This does not affect the code anyhow.
    {
        if(op != '*')
            throw std::logic_error("Operation other than Mult (*) are not supported");

        // here we just ignore unused operands
        return a * b;
    }

    IOperation::Arity MultOp::getArity() const
    {
        return arDue;
    }

//==============================================================================
// class DivOp
//==============================================================================


    int DivOp::operation(char op, int a, int b, int /*c*/) // < just commented unused argument. This does not affect the code anyhow.
    {
        if(op != '/')
            throw std::logic_error("Operation other than Div (/) are not supported");

        // here we just ignore unused operands
        if (b != 0)
            return a / b;
        return  Sign(a) * INT_MAX;
    }

    IOperation::Arity DivOp::getArity() const
    {
        return arDue;
    }

//==============================================================================
// class ChoiceOp
//==============================================================================


    int ChoiceOp::operation(char op, int a, int b, int c)
    {
        if(op != '?')
            throw std::logic_error("Operation other than Choice (?) are not supported");

        return a?b:c;
    }

    IOperation::Arity ChoiceOp::getArity() const
    {
        return arTre;
    }

//==============================================================================
// class AssignOp
//==============================================================================


    int AssignOp::operation(char op, int a, int /*b*/, int /*c*/) // < just commented unused argument. This does not affect the code anyhow.
    {
        if(op != '=')
            throw std::logic_error("Operation other than Assign (=) are not supported");

        // here we just ignore unused operands
        return a;
    }

    IOperation::Arity AssignOp::getArity() const
    {
        return arUno;
    }

//==============================================================================
// class SigChangeOp
//==============================================================================


    int SigChangeOp::operation(char op, int a, int /*b*/, int /*c*/) // < just commented unused argument. This does not affect the code anyhow.
    {
        if(op != '!')
            throw std::logic_error("Operation other than SigChange (!) are not supported");

        // here we just ignore unused operands
        return -a;
    }

    IOperation::Arity SigChangeOp::getArity() const
    {
        return arUno;
    }

//==============================================================================
// class InverOp
//==============================================================================


    int InverOp::operation(char op, int a, int /*b*/, int /*c*/) // < just commented unused argument. This does not affect the code anyhow.
    {
        if(op != '~')
            throw std::logic_error("Operation other than Inver (~) are not supported");

        // here we just ignore unused operands
        return ~a;
    }

    IOperation::Arity InverOp::getArity() const
    {
        return arUno;
    }

//==============================================================================
// class AndOp
//==============================================================================


    int AndOp::operation(char op, int a, int b, int /*c*/) // < just commented unused argument. This does not affect the code anyhow.
    {
        if(op != '&')
            throw std::logic_error("Operation other than And (&) are not supported");

        // here we just ignore unused operands
        return a & b;
    }

    IOperation::Arity AndOp::getArity() const
    {
        return arDue;
    }

//==============================================================================
// class OrOp
//==============================================================================


    int OrOp::operation(char op, int a, int b, int /*c*/) // < just commented unused argument. This does not affect the code anyhow.
    {
        if(op != '|')
            throw std::logic_error("Operation other than Or (|) are not supported");

        // here we just ignore unused operands
        return a | b;
    }

    IOperation::Arity OrOp::getArity() const
    {
        return arDue;
    }

//==============================================================================
// class PowOp
//==============================================================================


    int PowOp::operation(char op, int a, int b, int /*c*/) // < just commented unused argument. This does not affect the code anyhow.
    {
        if(op != '^')
            throw std::logic_error("Operation other than Pow (^) are not supported");

        // here we just ignore unused operands
        return static_cast<int>(pow(a, b));
    }

    IOperation::Arity PowOp::getArity() const
    {
        return arDue;
    }


//==============================================================================
// class StackMachine
//==============================================================================

    void StackMachine::registerOperation(char symb, IOperation* oper)
    {
        SymbolToOperMapConstIter it = _opers.find(symb);
        if (it != _opers.end())
            throw std::logic_error("An operation ... is alr. reg...");
        _opers[symb] = oper;
    }

    IOperation* StackMachine::getOperation(char symb)
    {
        switch (symb)
        {
            case '+':
                return new PlusOp;
            case '-':
                return new MinusOp;
            case '*':
                return new MultOp;
            case '/':
                return new DivOp;
            case '?':
                return new ChoiceOp;
            case '=':
                return new AssignOp;
            case '!':
                return new SigChangeOp;
            case '~':
                return new InverOp;
            case '&':
                return new AndOp;
            case '|':
                return new OrOp;
            case '^':
                return new PowOp;
            default:
                throw std::logic_error("Incorrect symbol");
        }
    }

    int StackMachine::calculate(const std::string& expr, bool clearStack)
    {
        if (!clearStack) _s.clear();
        std::string ch, exp = expr + ' ';

        for (char i : exp) {
            if (i != ' ')
                ch += i;
            else
            {
                if (((ch[0] == '+' || ch[0] == '-') && ch[1] >= '0' && ch[1] <= '9') || (ch[0] >= '0' && ch[0] <= '9'))
                    _s.push(Int(ch));
                else
                    {
                        IOperation* oper = getOperation(ch[0]);
                        int a, b;
                        switch (oper->getArity())
                        {
                            case IOperation::arUno:
                                _s.push(oper->operation(ch[0], _s.pop(), 0, 0));
                                break;
                            case IOperation::arDue:
                                a = _s.pop();
                                _s.push(oper->operation(ch[0], _s.pop(), a, 0));
                                break;
                            case IOperation::arTre:
                                a = _s.pop();
                                b = _s.pop();
                                _s.push(oper->operation(ch[0], _s.pop(), b, a));
                                break;
                        }
                    }
                    ch = "";
            }
        }
        return _s.top();
    }

} // namespace xi
