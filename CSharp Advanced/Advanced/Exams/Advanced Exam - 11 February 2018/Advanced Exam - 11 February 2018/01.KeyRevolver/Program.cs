using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int intelligence = int.Parse(Console.ReadLine());

            int firedBullets = 0;
            int count = 0;

            while (true)
            {
                if (bullets.Count == 0 || locks.Count == 0)
                {
                    break;
                }

                int bullet = bullets.Pop();
                int locker = locks.Peek();
                firedBullets++;

                if (bullet <= locker)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                count++;
                if (count == barrelSize)
                {
                    if (bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                        count = 0;
                    }
                }
            }

            if (bullets.Count == 0 && locks.Count == 0)
            {
                Console.WriteLine("{0} bullets left. Earned ${1}", bullets.Count, intelligence - (firedBullets * bulletPrice));
            }
            else
            {
                if (bullets.Count == 0)
                {
                    Console.WriteLine("Couldn't get through. Locks left: {0}", locks.Count);
                }
                else
                {
                    Console.WriteLine("{0} bullets left. Earned ${1}", bullets.Count, intelligence - (firedBullets * bulletPrice));
                }
            }
        }
    }
}
