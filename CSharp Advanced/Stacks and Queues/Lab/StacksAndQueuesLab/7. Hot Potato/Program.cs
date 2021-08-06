using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                );
            int n = int.Parse(Console.ReadLine());

            while (kids.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    kids.Enqueue(kids.Dequeue());
                }

                Console.WriteLine("Removed {0}", kids.Dequeue());
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
