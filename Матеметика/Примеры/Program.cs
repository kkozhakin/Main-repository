using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Примеры
{
    class Program
    {
        static bool NumberException(string s)   // Exception, if element cannot be cast to type double
        {
            return !double.TryParse(s, out double b);
        }

        static string Decision(string q)     // Performance of math operations
        {
            string[] arr = q.Split(' ');
            var l = new List<string>(arr);  // Convert array to list
            int e = arr.Length;
            for (int i = 0; i < e; i++)       // Remove space and empty symbols
            {
                if (l[i] == " " || l[i] == "")
                {
                    l.RemoveAt(i);
                    e -= 1;
                }
            }
        Rev1:                                   //First priority operations
            for (int i = 0; i < e; i++)
            {
                if (l[i] == "*") 
                {
                    if (NumberException(l[i - 1]) || NumberException(l[i + 1])) return "NumberException";
                    l[i] = (double.Parse(l[i - 1]) * double.Parse(l[i + 1])).ToString();
                    l.RemoveAt(i + 1);
                    l.RemoveAt(i - 1);
                    e -= 2;
                    goto Rev1;
                }
                if (l[i] == "/")
                {
                    if (NumberException(l[i - 1]) || NumberException(l[i + 1])) return "NumberException";
                    l[i] = (double.Parse(l[i - 1]) / double.Parse(l[i + 1])).ToString();
                    l.RemoveAt(i + 1);
                    l.RemoveAt(i - 1);
                    e -= 2;
                    goto Rev1;
                }
                if (l[i] == "%")
                {
                    if (NumberException(l[i - 1]) || NumberException(l[i + 1])) return "NumberException";
                    l[i] = (double.Parse(l[i - 1]) % double.Parse(l[i + 1])).ToString();
                    l.RemoveAt(i + 1);
                    l.RemoveAt(i - 1);
                    e -= 2;
                    goto Rev1;
                }
            }
        Rev2:                                   //Second priority operations
            for (int i = 0; i < e; i++)
            {
                if (l[i] == "-")
                {
                    if (NumberException(l[i - 1]) || NumberException(l[i + 1])) return "NumberException";
                    l[i] = (double.Parse(l[i - 1]) - double.Parse(l[i + 1])).ToString();
                    l.RemoveAt(i + 1);
                    l.RemoveAt(i - 1);
                    e -= 2;
                    goto Rev2;
                }
                if (l[i] == "+")
                {
                    if (NumberException(l[i - 1]) || NumberException(l[i + 1])) return "NumberException";
                    l[i] = (double.Parse(l[i - 1]) + double.Parse(l[i + 1])).ToString();
                    l.RemoveAt(i + 1);
                    l.RemoveAt(i - 1);
                    e -= 2;
                    goto Rev2;
                }
            }
            if (NumberException(l[0])) return "NumberException";
            return l[0];
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Write an example using spaces between EACH element.");
            string s = Console.ReadLine();
            Prov:                               //Processing of operations in brackets
            int b = s.IndexOf("(");
            if (b == -1)
            {
                s = Decision(s);
                if (!double.TryParse(s, out double answer))
                {
                    Console.WriteLine(s);
                    goto Ex;
                }
                else Console.WriteLine(answer);
            }
            else
            {
                int c = s.IndexOf(")");
                double a = 0;
                string s1 = s.Substring(b + 1, c - b - 1);
                s = s.Remove(b, c - b + 1);
                s1 = Decision(s1);
                if (!double.TryParse(s1, out a))
                {
                    Console.WriteLine(s1);
                    goto Ex;
                }    
                s = s.Insert(b, a.ToString());
                goto Prov;
            }
            Ex:                                 //Program exit
            Console.WriteLine("For exit press ESCAPE.");
            Console.ReadKey();
        }
    }
}
