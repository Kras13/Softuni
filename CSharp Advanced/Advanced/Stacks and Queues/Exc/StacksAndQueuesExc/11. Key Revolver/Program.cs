using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            int intelligence = int.Parse(Console.ReadLine());

            int bulletsCount = 0;
            int count = 0;

            while (true)
            {
                if (bullets.Count == 0 || locks.Count == 0)
                {
                    break;
                }

                count++;
                int bull = bullets.Pop();
                bulletsCount++;
                int locker = locks.Peek();

                if (bull <= locker)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (bullets.Count > 0 && count == barrelSize)
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }

            }

            if (locks.Count == 0 && bullets.Count >= 0)
            {
                int moneyEarned = intelligence - (bulletsCount * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }

        }
    }
}
