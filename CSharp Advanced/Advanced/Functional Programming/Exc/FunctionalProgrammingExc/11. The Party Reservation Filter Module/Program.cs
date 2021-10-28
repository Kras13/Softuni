using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> filters = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Print")
                {
                    break;
                }

                string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Add filter")
                {
                    filters.Add(tokens[1] + " " + tokens[2]);
                }
                else if (tokens[0] == "Remove filter")
                {
                    filters.Remove(tokens[1] + " " + tokens[2]);
                }
            }

            foreach (var filter in filters)
            {
                string[] command = filter.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Starts")
                {
                    guests = guests.Where(g => !g.StartsWith(command[2])).ToList();
                }
                else if (command[0] == "Ends")
                {
                    guests = guests.Where(g => !g.EndsWith(command[2])).ToList();
                }
                else if (command[0] == "Length")
                {
                    guests = guests.Where(g => g.Length != int.Parse(command[1])).ToList();
                }
                else if (command[0] == "Contains")
                {
                    guests = guests.Where(g => !g.Contains(command[1])).ToList();
                }
            }

            Console.WriteLine(string.Join(' ', guests));
        }
    }
}
