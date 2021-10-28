using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lenghts = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondtSet = new HashSet<int>();

            FillSet(firstSet, lenghts[0]);
            FillSet(secondtSet, lenghts[1]);
            HashSet<int> result = new HashSet<int>();

            foreach (var item in firstSet)
            {
                if (secondtSet.Contains(item))
                {
                    result.Add(item);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }

        private static void FillSet(HashSet<int> set, int lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                set.Add(int.Parse(Console.ReadLine()));
            }
        }
    }
}
