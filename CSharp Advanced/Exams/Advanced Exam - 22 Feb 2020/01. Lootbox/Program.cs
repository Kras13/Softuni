using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> firstItems = new Queue<int>(firstArray);

            int[] secondArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> secondItems = new Stack<int>(secondArray);

            long totalSum = 0;

            while (firstItems.Count > 0 && secondItems.Count > 0)
            {
                int first = firstItems.Peek();
                int second = secondItems.Peek();
                int sum = first + second;

                if (sum % 2 == 0)
                {
                    totalSum += sum;
                    firstItems.Dequeue();
                    secondItems.Pop();
                }
                else
                {
                    firstItems.Enqueue(secondItems.Pop());
                }
            }

            if (firstItems.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (totalSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {totalSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {totalSum}");
            }
        }
    }
}
