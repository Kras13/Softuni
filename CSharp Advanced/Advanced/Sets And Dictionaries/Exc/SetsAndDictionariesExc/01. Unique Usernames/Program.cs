using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < lines; i++)
            {
                string name = Console.ReadLine();

                names.Add(name);
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
