using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int divisor = int.Parse(Console.ReadLine());

            Func<int, bool> func = el => el % divisor != 0;


            List<int> result = new List<int>();

            result = nums
                .Where(el => func(el))
                .Reverse()
                .ToList();

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
