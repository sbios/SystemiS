using System;
using Notation;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            string input = Console.ReadLine();
            Console.WriteLine("Система из которой переводим");
            int from = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Система в которую переводим");
            int to = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Notation.Notation.Сonversion(input, from, to));
        }
    }
}
