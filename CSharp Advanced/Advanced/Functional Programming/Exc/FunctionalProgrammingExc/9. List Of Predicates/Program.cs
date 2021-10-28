using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Func<int[], int, bool> filter = (allDividers, number) =>
             {
                 bool divisable = true;

                 for (int i = 0; i < allDividers.Length; i++)
                 {
                     if (number % allDividers[i] != 0)
                     {
                         return false;
                     }
                 }

                 return divisable;
             };

            var divisibleNumbers = Enumerable.Range(1, range)
                .Where(el => filter(dividers, el))
                .ToArray();

            Console.WriteLine(string.Join(' ', divisibleNumbers));
        }
    }
}