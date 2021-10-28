using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> clients = new Queue<string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                if (line == "Paid")
                {
                    while (clients.Count > 0)
                    {
                        Console.WriteLine(clients.Dequeue());
                    }
                }
                else
                {
                    clients.Enqueue(line);
                }
            }

            Console.WriteLine($"{clients.Count} people remaining.");
        }
    }
}
