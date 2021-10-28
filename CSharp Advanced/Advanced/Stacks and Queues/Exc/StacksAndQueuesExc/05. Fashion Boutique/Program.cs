using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stacknums = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                );
            int capacity = int.Parse(Console.ReadLine());

            int sum = 0;
            int counter = 1;

            while (stacknums.Count > 0)
            {
                int currentNum = stacknums.Peek();
                sum += currentNum;

                if (sum <= capacity)
                {
                    stacknums.Pop();
                }
                else
                {
                    counter++;
                    sum = 0;
                }

            }

            Console.WriteLine(counter);
        }
    }
}
