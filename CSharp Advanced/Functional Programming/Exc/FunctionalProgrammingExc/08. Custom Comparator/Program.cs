using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var result = input
                .OrderBy(el => el % 2 != 0)
                .ThenBy(el => el % 2 == 0)
                .ToArray();

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
