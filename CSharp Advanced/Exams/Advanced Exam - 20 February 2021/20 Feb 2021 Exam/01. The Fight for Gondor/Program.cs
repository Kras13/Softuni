using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            LinkedList<int> plates = new LinkedList<int>(Console.ReadLine().Split().Select(int.Parse));
            int count = 0;
            Stack<int> orcs = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                orcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
                count++;
                if (count == 3)
                {
                    count = 0;
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.AddLast(newPlate);
                }

                while (orcs.Count > 0 && plates.Count > 0)
                {
                    int defender = plates.First();
                    int orc = orcs.Peek();

                    if (defender > orc)
                    {
                        int damage = orcs.Pop();
                        int toAdd = defender - damage;
                        plates.RemoveFirst();
                        plates.AddFirst(toAdd);
                    }
                    else if (defender < orc)
                    {
                        int damage = plates.First();
                        plates.RemoveFirst();
                        orcs.Push(orcs.Pop() - damage);
                    }
                    else if (defender == orc)
                    {
                        orcs.Pop();
                        plates.RemoveFirst();
                    }
                }
                if (plates.Count == 0)
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                    Console.WriteLine("Orcs left: {0}", string.Join(", ", orcs));
                    break;
                }
            }

            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine("Plates left: {0}", string.Join(", ", plates));
            }
        }
    }
}
