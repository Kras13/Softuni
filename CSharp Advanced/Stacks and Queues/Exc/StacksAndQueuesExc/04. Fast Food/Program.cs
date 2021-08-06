using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxQuantity = int.Parse(Console.ReadLine());
            int[] clients = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(clients);

            int biggestOrder = queue.Max();
            Console.WriteLine(biggestOrder);

            int sum = 0;

            bool flag = false;

            while (queue.Count > 0)
            {
                int currentOrderQuantity = queue.Peek();
                sum += currentOrderQuantity;

                if (sum <= maxQuantity)
                {
                    queue.Dequeue();
                }
                else
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine("Orders left: {0}", GetLeftOrders(queue));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }

        }

        private static string GetLeftOrders(Queue<int> queue)
        {
            string result = null;

            while (queue.Count > 0)
            {
                result += queue.Dequeue().ToString() + " ";
            }

            return result;
        }
    }
}
