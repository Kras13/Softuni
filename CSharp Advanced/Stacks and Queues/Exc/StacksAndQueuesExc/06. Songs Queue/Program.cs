using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                );

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }

                if (songs.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                if (line == "Play")
                {
                    songs.Dequeue();
                }
                else if (line.Contains("Add"))
                {
                    string substring = line.Substring(4);

                    if (!songs.Contains(substring))
                    {
                        songs.Enqueue(substring);
                    }
                    else
                    {
                        Console.WriteLine("{0} is already contained!", substring);
                    }
                }
            }
        }
    }
}
