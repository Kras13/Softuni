using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> funcName = el => el.Length <= lenght;

            List<string> sortedNames = new List<string>();

            foreach (var item in names.Where(el => funcName(el)))
            {
                sortedNames.Add(item);
            }

            sortedNames.ForEach(el => Console.WriteLine(el));
        }
    }
}
