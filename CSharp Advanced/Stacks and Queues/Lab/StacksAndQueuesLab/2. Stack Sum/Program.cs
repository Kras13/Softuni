using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> intStack = new Stack<int>(input);

            while (true)
            {
                string line = Console.ReadLine().ToUpper();

                if (line == "END")
                {
                    break;
                }

                string[] tokens = line.Split();
                string command = tokens[0].ToUpper();

                if (command == "ADD")
                {
                    int first = int.Parse(tokens[1]);
                    int second = int.Parse(tokens[2]);

                    intStack.Push(first);
                    intStack.Push(second);
                }
                else if (command == "REMOVE")
                {
                    int count = int.Parse(tokens[1]);

                    if (count <= intStack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            intStack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {intStack.Sum()}");
        }
    }
}
