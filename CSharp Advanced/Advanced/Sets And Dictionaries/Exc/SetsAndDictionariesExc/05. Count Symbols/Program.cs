using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> symbolsCount = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];

                if (!symbolsCount.ContainsKey(ch))
                {
                    symbolsCount.Add(ch, 1);
                }
                else
                {
                    symbolsCount[ch]++;
                }
            }

            var sortedSymbolsCount = symbolsCount
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var symbol in sortedSymbolsCount)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
