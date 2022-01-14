using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyersByName = new Dictionary<string, IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split();

                if (parts.Length == 3)
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string group = parts[2];

                    buyersByName.Add(name, new Rebel(name, age, group));
                }
                else
                {
                    // Peter 25 8904041303 04/04/1989
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string id = parts[2];
                    string birthdate = parts[3];

                    buyersByName.Add(name, new Citizen(name, age, birthdate, id));
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                if (!buyersByName.ContainsKey(line))
                {
                    continue;
                }

                buyersByName[line].BuyFood();
            }

            var foodSum = buyersByName
                .Values
                .Sum(el => el.Food);

            Console.WriteLine(foodSum);
        }
    }
}
