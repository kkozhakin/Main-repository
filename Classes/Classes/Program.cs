using System;

namespace Classes
{
    public class IntegerList
    {

        private int[,] _list;
        public int size = 0;

        /// <summary>
        /// Создаёт список указанного размера
        /// </summary>
        /// <param name="size">Размер списка</param>
        public IntegerList(int size)
        {
            _list = new int[size, size];
            this.size = size;
        }

        /// <summary>
        /// Заполнение списка по столбцам
        /// </summary>
        public void Zap1()
        {
            int c = 0;
            for (int i = 0; i < size; i++)
                if (i % 2 == 0)
                    for (int j = 0; j < size; j++)
                    {
                        _list[j, i] = c++;
                    }
                else
                    for (int j = size - 1; j >= 0; j--)
                    {
                        _list[j, i] = c++;
                    }
        }
        /// <summary>
        /// Заполнение списка по диагоналям
        /// </summary>
        public void Zap2()
        {
            int c = 0;
            int x, y;
            for (int k = 0; k < size; k++)
            {
                if (k % 2 == 0)
                {
                    x = k;
                    y = 0;
                    while (x >= 0 && y < size)
                    {
                        _list[y, x] = c++;
                        x--;
                        y++;
                    }
                }
                else
                {
                    x = 0;
                    y = k;
                    while (y >= 0 && x < size)
                    {
                        _list[y, x] = c++;
                        x++;
                        y--;
                    }
                }
            }
            for (int k = 1; k < size; k++)
            {
                if (k % 2 == 0)
                {
                    x = size - 1;
                    y = k;
                    while (x >= 0 && size > y)
                    {
                        _list[y, x] = c++;
                        x--;
                        y++;
                    }
                }
                else
                {
                    y = size - 1;
                    x = k;
                    while (y >= 0 && x < size)
                    {
                        _list[y, x] = c++;
                        y--;
                        x++;
                    }
                }
            }
        }
        /// <summary>
        /// Заполнение списка по спирали
        /// </summary>
        public void Zap3()
        {
            int k = 0;

            for (int t = 0; t < (size + 1) / 2; t++)
            {
                for (int j = t; j < size - t; j++)
                {
                    _list[t, j] = k;
                    k++;
                }
                for (int i = t + 1; i < size - t; i++)
                {
                    _list[i, size - 1 - t] = k;
                    k++;
                }
                for (int j = size - 2 - t; j >= t; j--)
                {
                    _list[size - 1 - t, j] = k;
                    k++;
                }
                for (int i = size - 2 - t; i > t; i--)
                {
                    _list[i, t] = k;
                    k++;
                }
            }
        }
        /// <summary>
        /// Печатает элементы списка
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write("{0,4} ", _list[i,j]);
                Console.WriteLine();
            }
        }
    }


    // ReSharper disable AssignNullToNotNullAttribute

    /*
     * IntegerListTest.cs
     * 
     * Тестирует класс IntegerList
     */


    public class IntegerListTest
    {
        private static IntegerList _list = new IntegerList(10);

        /// <summary>
        /// Создаёт список и выполняет пользовательские операции,
        /// пока пользователь не захочет выйти
        /// </summary>
        public static void Main()
        {
            PrintMenu();

            int choice = int.Parse(Console.ReadLine());

            while (choice != 0)
            {
                Dispatch(choice);
                PrintMenu();

                choice = int.Parse(Console.ReadLine());
            }
        }

        /// <summary>
        /// Выполняет действия меню
        /// </summary>
        /// <param name="choice">Выбранный пункт меню</param>
        public static void Dispatch(int choice)
        {
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Пока!");
                    break;
                case 1:
                    Console.WriteLine("Какой размер будет у списка?");
                    int size = int.Parse(Console.ReadLine());
                    _list = new IntegerList(size);
                    _list.Zap1();
                    break;
                case 2:
                    _list.Print();
                    break;
                case 3:
                    Console.WriteLine("Какой размер будет у списка?");
                    size = int.Parse(Console.ReadLine());
                    _list = new IntegerList(size);
                    _list.Zap2();
                    break;
                case 4:
                    Console.WriteLine("Какой размер будет у списка?");
                    size = int.Parse(Console.ReadLine());
                    _list = new IntegerList(size);
                    _list.Zap3();
                    break;
                default:
                    Console.WriteLine("Извините, вы выбрали что-то не то");
                    break;
            }
        }

        /// <summary>
        /// Выводит варианты пользователю
        /// </summary>
        public static void PrintMenu()
        {
            Console.WriteLine("\n Меню ");
            Console.WriteLine(" ====");
            Console.WriteLine("0: Выйти");
            Console.WriteLine("1: Создать новый список(Столбики) (** сделайте это с самого начала!! **)");
            Console.WriteLine("2: Напечатать список");
            Console.WriteLine("3: Создать новый список(Диагонали) (** сделайте это с самого начала!! **)");
            Console.WriteLine("4: Создать новый список(Спираль) (** сделайте это с самого начала!! **)");
            Console.Write("\nВведите ваш выбор: ");
        }
    }
}