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

            var s = new List<string> (("H e l l o").Split());

            PrintArray(numbers);
            PrintArray(s.ToArray());

            Console.ReadKey();
        }

        static void PrintArray<T>(T[] array)
        {
            foreach(T elem in array)
                Console.WriteLine(elem.ToString() + " ");
        }
    }
}
