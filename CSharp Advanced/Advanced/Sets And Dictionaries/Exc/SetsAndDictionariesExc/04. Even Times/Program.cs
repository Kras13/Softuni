using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < lines; i++)
            {
                int line = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(line))
                {
                    numbers.Add(line, 1);
                }
                else
                {
                    numbers[line]++;
                }
            }

            var number = numbers
                .Where(el => el.Value % 2 == 0)
                .SingleOrDefault()
                .Key;

            Console.WriteLine(number);
        }
    }
}
