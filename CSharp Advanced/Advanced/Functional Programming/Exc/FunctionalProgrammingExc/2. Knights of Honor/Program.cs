using System;
using System.Linq;

namespace _2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> names = (name) =>
            {
                Console.WriteLine($"Sir {name}");
            };

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(name => names(name));

        }
    }
}
