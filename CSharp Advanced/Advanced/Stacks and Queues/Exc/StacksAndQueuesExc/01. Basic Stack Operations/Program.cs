using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] line = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int pushNum = line[0];
            int popNum = line[1];
            int lookedNum = line[2];

            int[] arrayNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int smallestElement = int.MaxValue;

            bool flag = false;

            Stack<int> stackNums = new Stack<int>();

            for (int i = 0; i < pushNum; i++)
            {
                if (i >= arrayNums.Length)
                {
                    break;
                }

                stackNums.Push(arrayNums[i]);
            }

            for (int i = 0; i < popNum; i++)
            {
                if (i >= arrayNums.Length)
                {
                    break;
                }

                stackNums.Pop();
            }

            if (stackNums.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (stackNums.Count > 0)
                {
                    int currentNum = stackNums.Pop();

                    if (currentNum == lookedNum)
                    {
                        Console.WriteLine("true");
                        flag = true;
                        break;
                    }
                    else
                    {
                        if (smallestElement > currentNum)
                        {
                            smallestElement = currentNum;
                        }
                    }
                }

                if (!flag)
                {
                    Console.WriteLine(smallestElement);
                }
            }
        }
    }
}
