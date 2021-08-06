using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>
                (Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> threads = new Queue<int>
                (Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int aimedValue = int.Parse(Console.ReadLine());
            int threadKiller = 0;

            while (threads.Count > 0 && tasks.Count > 0)
            {
                int task = tasks.Peek();
                int thread = threads.Peek();

                if (task == aimedValue)
                {
                    threadKiller = thread;
                    break;
                }

                if (thread >= task)
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else if (task > thread)
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine("Thread with value {0} killed task {1}", threadKiller, aimedValue);
            Console.WriteLine(string.Join(' ', threads));
        }
    }
}
