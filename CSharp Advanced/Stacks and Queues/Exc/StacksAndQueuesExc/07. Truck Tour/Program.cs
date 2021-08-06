using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int[]> petrolPumps = new Queue<int[]>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] pumpsPerLine = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                petrolPumps.Enqueue(pumpsPerLine);
            }

            int index = 0;

            while (true)
            {
                int totalPetrol = 0;

                foreach (int[] petrolStation in petrolPumps)
                {
                    int fuel = petrolStation[0];
                    int distance = petrolStation[1];

                    totalPetrol += fuel - distance;

                    if (totalPetrol < 0)
                    {
                        //Not enough

                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        index++;
                        break;
                    }
                }

                if (totalPetrol >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
