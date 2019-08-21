using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception1
{
    class Program
    {
        static void Main()
        {
            try
            {
                int x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                    case 2:
                    case 3:
                        Console.WriteLine("2");
                        Main();
                        break;
                    case 4:
                    case 5:
                        Console.WriteLine("3");
                        Main();
                        break;
                    case 6:
                    case 7:
                        Console.WriteLine("4");
                        Main();
                        break;
                    case 8:
                    case 9:
                    case 10:
                        Console.WriteLine("5");
                        Main();
                        break;
                    default:
                        Console.WriteLine("Error");
                        Main();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Main();
            }
            Console.WriteLine("Для выхода нажмите любую кнопку.");
            Console.ReadKey();
        }
    }
}
