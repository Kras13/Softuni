using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] teamData = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            string teamName = teamData[1];
            Team team = new Team(teamName);

            //bool teamExistance = true;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] tokens = line.Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Add")
                {
                    if (tokens[1] != team.Name)
                    {
                        //teamExistance = false;
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                        continue;
                    }

                    string playerName = tokens[2];

                    try
                    {
                        Player player = new Player(playerName);
                        List<double> stats = new List<double>();

                        for (int i = 3; i < tokens.Length; i++)
                        {
                            stats.Add(double.Parse(tokens[i]));
                        }

                        player.RegisterStats(stats);
                        team.AddPlayer(player);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (tokens[0] == "Remove")
                {
                    if (tokens[1] != team.Name)
                    {
                        //teamExistance = false;
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                        continue;
                    }
                    try
                    {
                        string playerName = tokens[2];
                        team.RemovePLayer(playerName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                else if (tokens[0] == "Rating")
                {
                    if (tokens[1] != team.Name)
                    {
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                        continue;
                    }
                    Console.WriteLine($"{team.Name} - {team.Rating}");
                }
            }
        }
    }
}
