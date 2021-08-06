using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsInput = File.ReadAllLines("words.txt");

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string[] separators = { "-", " ", ", ", ".", "?" };

            using (var stream = new StreamReader("text.txt"))
            {
                string line = stream.ReadLine();

                while (line != null)
                {
                    string[] wordsPerLine = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in wordsPerLine)
                    {
                        foreach (var unWord in wordsInput)
                        {
                            if (word.ToUpper() == unWord.ToUpper())
                            {
                                if (!wordsCount.ContainsKey(word.ToLower()))
                                {
                                    wordsCount.Add(word.ToLower(), 0);
                                }
                                wordsCount[word.ToLower()]++;
                            }
                        }
                    }
                    line = stream.ReadLine();
                }
            }

            var sordetWordsByCount = wordsCount
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, y => y.Value);

            using (var output = new StreamWriter("output.txt"))
            {
                foreach (var word in sordetWordsByCount)
                {
                    output.WriteLine($"{word.Key} - {word.Value}");
                }
            }

        }
    }
}
