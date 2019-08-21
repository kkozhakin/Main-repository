using System;

namespace Delegates
{
    /// <summary>
    /// delegate
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    delegate int Example(params int[] a);
    /// <summary>
    /// delegate for convert array
    /// </summary>
    /// <param name="a"></param>
    /// <returns>converted array</returns>
    delegate int[] ConvertRule(int[] a);
    class Program
    {
        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="args">arguments</param>
        /// <returns>sum of arguments</returns>
        static int Sum(int[] args)
        {
            if (args.Length == 0) return 0;
            else
            {
                for (int i = 1; i < args.Length; i++)
                {
                    args[0] += args[i];
                }
                return args[0];
            }
        }
        /// <summary>
        /// Multiplication
        /// </summary>
        /// <param name="args">arguments</param>
        /// <returns>multiplication of arguments</returns>
        static int Mult(int[] args)
        {
            if (args.Length == 0) return 0;
            else
            {
                for (int i = 1; i < args.Length; i++)
                {
                    args[0] *= args[i];
                }
                return args[0];
            }
        }
        static void Main()
        {
            //new delegate
            Example s1 = new Example(Sum);
            Console.WriteLine("Sum = {0}", s1(2, 3));
            Example s2 = new Example(Mult);
            Console.WriteLine("Mult = {0}", s2(2, 3, 4));
            //Последовательное выполнение функций и запись результата в args[0] следующей(только у меня)
            Example s = s1 + s1 + s2;
            Console.WriteLine("Mult(Sum(Sum(1,2,3), 2, 3), 2, 3) = {0}", s(1, 2, 3));
            // Лямбда-выражение
            s = (a) => a[0] * a[0]; 
            Console.WriteLine("Sqr = {0}", s(2));
            // Анонимный метод
            s = delegate (int[] args)
            {
                if (args.Length == 0) return 0;
                else
                {
                    for (int i = 1; i < args.Length; i++)
                    {
                        args[0] += args[i];
                    }
                    return 2 * args[0];
                }
            };
            Console.WriteLine("Sum X 2 = {0}", s(2, 3));


            int[] mas = { 1, 2, 3, 4, 5 };
            //Анонимный медод для конвертации
            ConvertRule conv = delegate (int[] a)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = 2 * i;
                }
                return a;
            };
            //Крнвертация через обратный вызов
            Convert(ref mas, conv);
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Convert array
        /// </summary>
        /// <param name="mas">array</param>
        /// <param name="conv">ConvertRule</param>
        public static void Convert(ref int[] mas, ConvertRule conv) => conv(mas);
    }
}
