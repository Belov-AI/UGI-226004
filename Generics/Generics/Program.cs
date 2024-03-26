using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6 };

            char[] s;

            var word = "Hello";

            s = new char[word.Length];
            for (int i = 0; i < s.Length; i++)
                s[i] = word[i];

            var bread = new Product<int> { Name = "хлеб", Price = 37 };
            var milk = new Product<double> { Name = "молоко", Price = 30.5 };
            var cheese = new Product<string> { Name = "сыр", Price = "0 (нет в наличии)" };
            var candies = new Product<double> { Name = "конфеты", Price = 261.7 };
            var cake = new Product<double> { Name = "пироженное", Price = 20.3 };

            var goods = new object[] { bread, milk, cheese };
            
            PrintArray(numbers);
            PrintArray(s);
            PrintArray(goods);

            bread.Sell();
            milk.Sell();
            cheese.Sell();

            var set = new Product<double>[] { milk, candies, cake };

            PrintArray(set);
            Array.Sort(set);
            PrintArray(set);

            Console.ReadKey();
        }

        static void PrintArray<T>(T[] array)
        {
            foreach(var elem in array)
                Console.Write(elem.ToString() + " ");

            Console.WriteLine();
        }
    }
}
