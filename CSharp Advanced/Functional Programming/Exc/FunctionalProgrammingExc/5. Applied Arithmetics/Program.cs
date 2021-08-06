using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                if (line == "add")
                {
                    arr = arr.Select(el => el + 1).ToList();
                }
                else if (line == "multiply")
                {
                    arr = arr.Select(el => el * 2).ToList();

                }
                else if (line == "subtract")
                {
                    arr = arr.Select(el => el - 1).ToList();

                }
                else if (line == "print")
                {
                    Console.WriteLine(string.Join(' ', arr));
                }
            }
        }
    }
}
