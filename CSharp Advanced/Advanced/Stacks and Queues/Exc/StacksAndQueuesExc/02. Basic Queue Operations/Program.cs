using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();
            int elementsEnque = commands[0];
            int elementsDenque = commands[1];
            int lookedElement = commands[2];

            QueueEnqueElements(queue, elementsEnque, numbers);
            QueueDequeElements(queue, elementsDenque, numbers);

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(lookedElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }

        private static void QueueDequeElements(Queue<int> queue, int elementsDenque, int[] numbers)
        {
            for (int i = 0; i < elementsDenque; i++)
            {
                if (i >= numbers.Length)
                {
                    break;
                }

                queue.Dequeue();
            }
        }

        private static void QueueEnqueElements(Queue<int> queue, int elementsEnque, int[] numbers)
        {
            for (int i = 0; i < elementsEnque; i++)
            {
                if (i >= numbers.Length)
                {
                    break;
                }

                queue.Enqueue(numbers[i]);
            }
        }
    }
}
