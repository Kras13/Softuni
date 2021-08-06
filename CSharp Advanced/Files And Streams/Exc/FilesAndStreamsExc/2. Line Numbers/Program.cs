using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArr = File.ReadAllLines("text.txt");

            for (int i = 0; i < inputArr.Length; i++)
            {
                string line = inputArr[i]; ;
                int wordsCount = StringWordsCount(line);
                int punctuationsCount = StringPuncCount(line);

                inputArr[i] = $"Line {i + 1}: {line} ({wordsCount})({punctuationsCount})";
            }
            File.WriteAllLines("output.txt", inputArr);
        }

        private static int StringPuncCount(string v)
        {
            int count = 0;

            foreach (var ch in v)
            {
                if (char.IsPunctuation(ch))
                {
                    count++;
                }
            }

            return count;
        }

        private static int StringWordsCount(string v)
        {
            int count = 0;

            foreach (var ch in v)
            {
                if (char.IsLetter(ch))
                {
                    count++;
                }
            }

            return count;
        }


    }
}
