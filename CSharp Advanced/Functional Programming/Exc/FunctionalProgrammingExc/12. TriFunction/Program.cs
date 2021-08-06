using System;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> validator = (name, value) =>
            name
            .ToCharArray()
            .Select(el => (int)el)
            .Sum() >= number;

            Func<string[], string> foundName = nameValidate =>
           names.FirstOrDefault(el => validator(el, number));

            Console.WriteLine(foundName(names));
        }
    }
}
