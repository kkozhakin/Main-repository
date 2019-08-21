using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Системы_линейных_уравнений
{
    class Matrix
    {
        public bool[,] lin;

        static int[] Convert(int n, int num10)  //Convert 10 in 2 system
        {
            int a = 0;
            int i = 0;
            int[] b = new int[n]; 
            while (num10 >= 1)
            {
                a = num10 % 2;
                b[i] = a;
                i++;
                num10 = num10 / 2;
            };
            return b;
        }
        
        public bool[] XOR(int n)                //Matrix with XOR
        {
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                Search:                         // Search first true in stolbets
                    if (lin[i, j] == true)
                    {
                        for (int k = 0; k < j; k++)
                        {
                            if (lin[i, k] == true)  //If not first true in line 
                            {
                                if (i == n - 1)
                                {
                                    i = 0;
                                    j++;
                                }
                                else i++;
                                goto Search;
                            }
                        }
                        for (int k = 0; k < n; k++)     //XOR this line with lines consists true in this stolbets 
                            if (lin[k, j] == true && k != i)
                                for (int l = j; l <= n; l++)
                                    lin[k, l] ^= lin[i, l];
                    }
                }
               for (int q = 0; q < n; q++)     //Write matrix
                {
                    for (int s = 0; s <= n; s++)
                    {
                        Console.Write(lin[q, s] + " ");
                    }
                    Console.WriteLine();
               }
                Console.WriteLine();
            }
            bool[] b = new bool[n];        // Write answer in b
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (lin[i, j] == true) b[j] = lin[i, n];
            return b;
        }

        public Matrix(int n, params int[] values)
        {
            lin = new bool[n, n + 1];
            int[] l = new int[n]; 
            for (int i = 0; i < n; i++)        //Convert values
            {
                l = Convert(n, values[i]);
                for (int j = 0; j < n; j++)
                {
                    if (l[j] == 0) lin[n - j - 1, i] = false;
                    else lin[n - j - 1, i] = true;
                }
            }
            l = Convert(n, values[n]);
            for (int j = 0; j < n; j++)
            {
                if (l[j] == 0) lin[n - j - 1, n] = false;
                else lin[n - j - 1, n] = true;
            }
            for (int i = 0; i < n; i++)     //Write this matrix
            {
                for (int j = 0; j <= n; j++)
                {
                    Console.Write(lin[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

namespace Системы_линейных_уравнений
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Write count of elements: ");          //Enter elements
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Exception");
                goto Ex;
            }
            int[] l = new int[n + 1];
            Console.WriteLine("Write elements less than " + Math.Pow(2, n));
            for (int i = 0; i < n; i++)
            {
                Console.Write("x" + i + " = ");
                if (!int.TryParse(Console.ReadLine(), out l[i]))
                {
                    Console.WriteLine("Exception");
                    goto Ex;
                }
            }
            Console.Write("ans = ");
            if (!int.TryParse(Console.ReadLine(), out l[n]))
            {
                Console.WriteLine("Exception");
                goto Ex;
            }
            Matrix m = new Matrix(n, l);
            bool[] b = m.XOR(n);
            for (int i = 0; i < n; i++)     //Write answer
            {
                Console.WriteLine("X" + i + " = " + b[i]);
            }
        Ex:
            Console.ReadKey();
        }
    }
}
