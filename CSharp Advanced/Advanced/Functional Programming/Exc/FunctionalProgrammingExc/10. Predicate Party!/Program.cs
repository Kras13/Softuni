using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            Predicate<string> GetPredicate(string commandType, string arg)
            {
                switch (commandType)
                {
                    case "StartsWith":
                        return (name) => name.StartsWith(arg);
                    case "EndsWith":
                        return (name) => name.EndsWith(arg);
                    case "Length":
                        return (name) => name.Length == int.Parse(arg);
                    default:
                        throw new ArgumentException("Invalid command type: " + commandType);
                }
            }



            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Party!")
                {
                    break;
                }

                var tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                Predicate<string> predicate = GetPredicate(tokens[1], tokens[2]);

                switch (tokens[0])
                {
                    case "Remove":
                        names.RemoveAll(predicate);
                        break;
                    case "Double":
                        {
                            var matches = names.FindAll(predicate);
                            if (matches.Count > 0)
                            {
                                var index = names.FindIndex(predicate);
                                names.InsertRange(index, matches);
                            }

                            break;
                        }
                }

            }

            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.Write(string.Join(", ", names));
                Console.WriteLine(" are going to the party!");
            }
        }
    }
}
