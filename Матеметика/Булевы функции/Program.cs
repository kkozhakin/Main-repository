using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Булевы_функции
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] a = new bool[]{ false, false, true, true }, b = new bool[]{ false, true, false, true };
            bool[,] F = new bool[,] { { false, false, false, false, false, false, false, false, true, true, true, true, true, true, true, true }, { false, false, false, false, true, true, true, true, false, false, false, false, true, true, true, true }, { false, false, true, true, false, false, true, true, false, false, true, true, false, false, true, true }, { false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true } };
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine("  A    B    F    FA    FB    FAB  ");
                for (int j = 0; j < 4; j++)             //print function
                {
                    Console.Write(a[j] + " " + b[j] + " " + F[j, i] + " ");
                    if (j % 2 == 0)
                        Console.WriteLine((F[0, i]^F[2, i]) + " " + (F[j, i] ^ F[j + 1, i]) + " " + ((F[0, i] ^ F[1, i]) ^ (F[2, i] ^ F[3, i])) + " ");
                    else Console.WriteLine((F[1, i] ^ F[3, i]) + " " + (F[j, i] ^ F[j - 1, i]) + " " + ((F[0, i] ^ F[1, i]) ^ (F[2, i] ^ F[3, i])) + " ");
                }
                Console.WriteLine("Разложение Рида");
                for (int j = 0; j < 4; j++)         //Rid
                {
                    string s = "F = ";
                    if (F[j, i] == true) s += "True";
                    if (j % 2 == 0)
                        if (a[j] == false)
                        {
                            if ((F[0, i] ^ F[2, i]) == true) s += ((s.Length > 4)?"^A":"A");
                        }
                        else
                        {
                            if ((F[0, i] ^ F[2, i]) == true) s += ((s.Length > 4) ? "^not(A)" : "not(A)");
                        }
                    else if (a[j] == false)
                    {
                        if ((F[1, i] ^ F[3, i]) == true) s += ((s.Length > 4) ? "^A" : "A");
                    }
                    else
                    {
                        if ((F[1, i] ^ F[3, i]) == true) s += ((s.Length > 4) ? "^not(A)" : "not(A)");
                    }
                    if (j % 2 == 0)
                        if (b[j] == false)
                        {
                            if ((F[j, i] ^ F[j + 1, i]) == true) s += ((s.Length > 4) ? "^B" : "B");
                        }
                        else
                        {
                            if ((F[j, i] ^ F[j + 1, i]) == true) s += ((s.Length > 4) ? "^not(B)" : "not(B)");
                        }
                    else if (b[j] == false)
                    {
                        if ((F[j, i] ^ F[j - 1, i]) == true) s += ((s.Length > 4) ? "^B" : "B");
                    }
                    else
                    {
                        if ((F[j, i] ^ F[j - 1, i]) == true) s += ((s.Length > 4) ? "^not(B)" : "not(B)");
                    }
                    if (((F[0, i] ^ F[1, i]) ^ (F[2, i] ^ F[3, i])) == true)
                        if (a[j] == false & b[j] == false) s += ((s.Length > 4) ? "^A&B" : "A&B");
                        else if (a[j] == true & b[j] == false) s += ((s.Length > 4) ? "^not(A)&B" : "not(A)&B");
                        else if (a[j] == false & b[j] == true) s += ((s.Length > 4) ? "^A&not(B)" : "A&not(B)");
                        else s += ((s.Length > 4) ? "^not(A)&not(B)" : "not(A)&not(B)");
                    else s += ((s.Length == 4) ? "False": "");
                    Console.WriteLine(s);
                }
                string sdnf = "SDNF = ";
                string sknf = "SKNF = ";
                for (int j = 0; j < 4; j++)         //SKNF and SDNF
                {
                    if (F[j, i] == true)
                        if (a[j] == true & b[j] == true) sdnf += ((sdnf.Length > 7) ? "+A&B" : "A&B");
                        else if (a[j] == false & b[j] == true) sdnf += ((sdnf.Length > 7) ? "+not(A)&B" : "not(A)&B");
                        else if (a[j] == true & b[j] == false) sdnf += ((sdnf.Length > 7) ? "+A&not(B)" : "A&not(B)");
                        else sdnf += ((sdnf.Length > 7) ? "+not(A)&not(B)" : "not(A)&not(B)");
                    else
                    if (a[j] == false & b[j] == false) sknf += ((sknf.Length > 7) ? "&(A+B)" : "(A+B)");
                    else if (a[j] == true & b[j] == false) sknf += ((sknf.Length > 7) ? "&(not(A)+B)" : "(not(A)+B)");
                    else if (a[j] == false & b[j] == true) sknf += ((sknf.Length > 7) ? "&(A+not(B))" : "(A+not(B))");
                    else sknf += ((sknf.Length > 7) ? "&(not(A)+not(B))" : "(not(A)+not(B))");
                }
                if (i != 0) Console.WriteLine(sdnf);
                if (i != 15) Console.WriteLine(sknf);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
