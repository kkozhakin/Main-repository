using System;

namespace ConsoleApp1
{
    class Program
    {
        static uint GetValue()
        {
            uint x;
            try
            {
                x = uint.Parse(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            return x;
        }

        static float[,] GetMatrix(uint n, uint m)
        {
            float[,] matr = new float[n, m];
            string[] s;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    s = Console.ReadLine().Split();
                    for (int j = 0; j < m; j++)
                    {
                        matr[i, j] = float.Parse(s[j]);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                float[,] matrEr = new float[0, 0];
                return matrEr;
            }
            return matr;
        }
        static void PrintMatrix(ref float[,] matr, uint n, uint m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static float Mul(int a, int b, ref float[,] matr1, ref float[,] matr2, uint m)
        {
            float f = 0;
            for (int i = 0; i < m; i++)
            {
                f += matr1[a, i] * matr2[i, b];
            }
            return f;
        }
        static void Multi(ref float[,] matr1, ref float[,] matr2, uint n, uint m, uint k)
        {
            float[,] matrmult = new float[n, k];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    matrmult[i, j] = Mul(i, j, ref matr1, ref matr2, m);
                } 
            }
            PrintMatrix(ref matrmult, n, k);
        }
        static void Main(string[] args)
        {
            uint n, m, k, a;
            float[,] MatrEr = new float[0, 0];
            float[,] Matr1, Matr2;
            do
            {
                do
                {
                    Console.WriteLine("Enter N.");
                    n = GetValue();
                } while (n == 0);
                do
                {
                    Console.WriteLine("Enter M.");
                    m = GetValue();
                } while (m == 0);
                do
                {
                    Console.WriteLine("Enter first matrix NxM.");
                    Matr1 = GetMatrix(n, m);
                } while (Matr1.Length == 0);
                do
                {
                    Console.WriteLine("Enter K.");
                    k = GetValue();
                } while (k == 0);
                do
                {
                    Console.WriteLine("Enter first matrix MxK.");
                    Matr2 = GetMatrix(m, k);
                } while (Matr2.Length == 0);
                SW:
                do
                {
                    Console.WriteLine("For multiplication matrix press 1, for summary press 2.");
                    a = GetValue();
                } while (a == 0 || a > 2);
                switch (a)
                {
                    case 1:
                        Multi(ref Matr1, ref Matr2, n, m, k);
                        break;
                    case 2:
                        //Summ(ref Matr1, ref Matr2);
                        Console.WriteLine("Пока нету.");
                        goto SW;
                        break;
                }
                Console.WriteLine("For exit press Enter.");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
        }
    }
}
