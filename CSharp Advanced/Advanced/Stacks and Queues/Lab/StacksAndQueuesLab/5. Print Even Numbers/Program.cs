using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> evenNumbers = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int count = evenNumbers.Count;

            for (int i = 0; i < count; i++)
            {
                if (evenNumbers.Peek() % 2 == 0)
                {
                    evenNumbers.Enqueue(evenNumbers.Dequeue());
                }
                else
                {
                    evenNumbers.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
