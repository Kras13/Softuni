using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>
                (Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> ingredients = new Stack<int>
                (Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<int, int> bakedFoodCount = new Dictionary<int, int>
            {
                { 25, 0 },
                { 50, 0 },
                { 75, 0 },
                { 100, 0 }
            };

            while (liquids.Count != 0 && ingredients.Count != 0)
            {
                int sum = liquids.Dequeue() + ingredients.Peek();

                if (IsPairExact(sum))
                {
                    ingredients.Pop();
                    bakedFoodCount[sum]++;
                }
                else
                {
                    int temp = ingredients.Pop() + 3;
                    ingredients.Push(temp);
                }
                if (liquids.Count == 0 || ingredients.Count == 0)
                {
                    break;
                }
            }

            if (CheckIfEverythingIsCooked(bakedFoodCount))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
                GetStatus(liquids, ingredients);
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
                GetStatus(liquids, ingredients);
            }

            foreach (var food in bakedFoodCount)
            {
                if (food.Key == 25)
                {
                    Console.WriteLine("Bread: {0}", food.Value);
                }
                else if (food.Key == 50)
                {
                    Console.WriteLine("Cake: {0}", food.Value);
                }
                else if (food.Key == 75)
                {
                    Console.WriteLine("Fruit Pie: {0}", food.Value);
                }
                else if (food.Key == 100)
                {
                    Console.WriteLine("Pastry: {0}", food.Value);
                }
            }
        }

        private static void GetStatus(Queue<int> liquids, Stack<int> ingredients)
        {
            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine("Liquids left: {0}", string.Join(", ", liquids));
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine("Ingredients left: {0}", string.Join(", ", ingredients));
            }
        }

        private static bool CheckIfEverythingIsCooked(Dictionary<int, int> bakedFoodCount)
        {
            return bakedFoodCount[25] != 0 && bakedFoodCount[50] != 0 &&
                   bakedFoodCount[75] != 0 && bakedFoodCount[100] != 0;
        }

        private static bool IsPairExact(int sum)
        {
            return sum == 25 || sum == 50 || sum == 75 || sum == 100;
        }
    }
}
