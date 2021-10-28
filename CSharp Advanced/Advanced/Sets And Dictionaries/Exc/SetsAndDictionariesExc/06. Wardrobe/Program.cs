using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothesByColor = new Dictionary<string, Dictionary<string, int>>();


            for (int i = 0; i < lines; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = line[0];
                string[] cloths = line[1].Split(",");

                if (!clothesByColor.ContainsKey(color))
                {
                    clothesByColor.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < cloths.Length; j++)
                {
                    if (!clothesByColor[color].ContainsKey(cloths[j]))
                    {
                        clothesByColor[color].Add(cloths[j], 0);
                    }
                    clothesByColor[color][cloths[j]]++;
                }
            }

            string[] wantedDress = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string wantedColor = wantedDress[0];
            string wantedCloth = wantedDress[1];

            foreach (var colorItem in clothesByColor)
            {
                Console.WriteLine($"{colorItem.Key} clothes:");

                foreach (var item in colorItem.Value)
                {
                    if (colorItem.Key == wantedColor && wantedCloth == item.Key)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
