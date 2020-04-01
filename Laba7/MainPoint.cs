using System;
using LibMath;
using LibPrint;

namespace Laba7
{
    class MainPoint
    {
        static void Main(string[] args)
        {
         A: Pt.P("Выберите номер задания\n" +
             "1 - Первое задание\n" +
             "2 - Второе задание\n" +
             "3 - Завершить");
            int Number = int.Parse(Console.ReadLine());
            switch (Number)
            {
                case 1:
                    Console.Clear();Task1.First();Console.Clear(); goto A;
                case 2:
                    Console.Clear(); Task2.Second(); Console.Clear(); goto A;
                case 3:
                    Console.Clear(); Pt.P("Удачи !");break;
            }
        }
    }
}
