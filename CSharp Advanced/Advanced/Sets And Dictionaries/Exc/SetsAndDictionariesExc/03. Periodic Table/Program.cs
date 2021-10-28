using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            HashSet<string> periodicTableElements = new HashSet<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < elements.Length; j++)
                {
                    string element = elements[j];

                    periodicTableElements.Add(element);
                }
            }

            var sortedPeriodicTableElements = periodicTableElements
                .OrderBy(x => x);

            Console.WriteLine(string.Join(' ', sortedPeriodicTableElements));
        }
    }
}
