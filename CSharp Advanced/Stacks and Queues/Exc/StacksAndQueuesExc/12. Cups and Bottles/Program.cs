using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> cupsCapacity = new Stack<int>(Console.ReadLine()
                .Split()
                .Reverse()
                .Select(int.Parse)
                .ToArray());

            Stack<int> bottles = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            int wastedWater = 0;

            while (true)
            {
                if (cupsCapacity.Count == 0 || bottles.Count == 0)
                {
                    break;
                }

                if (bottles.Peek() - cupsCapacity.Peek() >= 0)
                {
                    wastedWater += bottles.Pop() - cupsCapacity.Pop();
                }
                else
                {
                    int num = bottles.Pop();
                    int toPush = cupsCapacity.Pop() - num;
                    cupsCapacity.Push(toPush);
                }
            }

            if (cupsCapacity.Count > 0)
            {
                Console.WriteLine("Cups: {0}", string.Join(' ', cupsCapacity));
            }
            else
            {
                Console.WriteLine("Bottles: {0}", string.Join(' ', bottles));

            }
            Console.WriteLine("Wasted litters of water: {0}", wastedWater);
        }
    }
}
