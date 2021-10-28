using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            List<long> sets = new List<long>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (hat == scarf)
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
                else if (hat > scarf)
                {
                    long sum = hats.Pop() + scarfs.Dequeue();
                    sets.Add(sum);
                }
                else
                {
                    hats.Pop();
                }
            }

            Console.WriteLine("The most expensive set is: {0}", sets.Max());
            Console.WriteLine(string.Join(' ', sets));

        }
    }
}