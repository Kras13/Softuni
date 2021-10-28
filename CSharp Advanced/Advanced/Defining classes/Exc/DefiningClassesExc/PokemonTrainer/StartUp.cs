using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string line = Console.ReadLine().Trim();

                if (line == "Tournament")
                {
                    break;
                }

                string[] tokens = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                double pokemonHealth = double.Parse(tokens[3]);

                if (!trainers.Any(tr => tr.Name == trainerName))
                {
                    trainers.Add(new Trainer() { Name = trainerName });
                }
                var currTrainer = trainers.Find(tr => tr.Name == trainerName);

                currTrainer.Pokemons
                    .Add(new Pokemon()
                    { Name = pokemonName, Health = pokemonHealth, Element = pokemonElement }
                    );
            }

            while (true)
            {
                string command = Console.ReadLine().Trim();

                if (command == "End")
                {
                    break;
                }

                foreach (Trainer train in trainers)
                {
                    if (train.Pokemons.Any(el => el.Element == command))
                    {
                        train.Badges++;
                    }
                    else
                    {
                        for (int i = train.Pokemons.Count - 1; i >= 0; i--)
                        {
                            train.Pokemons[i].Health -= 10;

                            if (train.Pokemons[i].Health <= 0)
                            {
                                train.Pokemons.RemoveAt(i);
                            }
                        }
                    }
                }
            }

            List<Trainer> sortedTrainers = trainers
                .OrderByDescending(tr => tr.Badges)
                .ToList();

            foreach (Trainer trainer in sortedTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
