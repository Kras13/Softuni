using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greeLightSeconds = int.Parse(Console.ReadLine());
            int openedWindows = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new Queue<string>();

            int totalCarsPassed = 0;

            while (true)
            {
                string command = Console.ReadLine();

                int greenLight = greeLightSeconds;
                int windowSeconds = openedWindows;

                if (command == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
                    return;
                }

                if (command == "green")
                {
                    while (greenLight > 0 && carsQueue.Count > 0)
                    {
                        string car = carsQueue.Dequeue();
                        greenLight -= car.Length;

                        if (greenLight >= 0)
                        {
                            totalCarsPassed++;
                        }
                        else
                        {
                            windowSeconds += greenLight;
                            if (windowSeconds < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[car.Length + windowSeconds]}.");
                                return;
                            }

                            totalCarsPassed++;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(command);
                }
            }
        }
    }
}
