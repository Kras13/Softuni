using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorationRepository = new DecorationRepository();
        private List<IAquarium> aquariums = new List<IAquarium>();

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                decorationRepository.Add(new Ornament());
            }
            else if (decorationType == "Plant")
            {
                decorationRepository.Add(new Plant());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var selectedAquarium = this.aquariums
                    .FirstOrDefault(a => a.Name == aquariumName);

            if (fishType == "FreshwaterFish")
            {
                if (selectedAquarium.GetType().Name == "SaltwaterAquarium")
                {
                    return "Water not suitable.";
                }

                selectedAquarium.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
            }
            else if (fishType == "SaltwaterFish")
            {
                if (selectedAquarium.GetType().Name == "FreshwaterAquarium")
                {
                    return "Water not suitable.";
                }

                selectedAquarium.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            var selectedAquarium = this.aquariums
                .FirstOrDefault(a => a.Name == aquariumName);
            decimal result = selectedAquarium.Fish.Sum(f => f.Price) + selectedAquarium.Decorations.Sum(d => d.Price);
            return $"The value of Aquarium { aquariumName} is {result}.";
        }

        public string FeedFish(string aquariumName)
        {
            var selectedAquarium = this.aquariums
                .FirstOrDefault(a => a.Name == aquariumName);
            selectedAquarium.Feed();
            return $"Fish fed: {selectedAquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var selectedAquarium = aquariums.
                FirstOrDefault(a => a.Name == aquariumName);
            var selectedDecoration = decorationRepository.FindByType(decorationType);

            if (selectedDecoration == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            selectedAquarium.AddDecoration(selectedDecoration);
            this.decorationRepository.Remove(selectedDecoration);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine($"{aquarium.Name} ({aquarium.GetType().Name}):");
                sb.Append("Fish: ");
                if (aquarium.Fish.Count == 0)
                {
                    sb.AppendLine("none");
                }
                else
                {
                    sb.AppendLine(string.Join(", ", aquarium.Fish));
                }
                sb.AppendLine($"Decorations: {aquarium.Decorations.Count}");
                sb.AppendLine($"Comfort: {aquarium.Comfort}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
