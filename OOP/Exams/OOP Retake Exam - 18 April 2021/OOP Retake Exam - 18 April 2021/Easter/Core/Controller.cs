using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnyRepositories;
        private EggRepository eggRepositories;
        private IWorkshop workshop;

        public Controller()
        {
            this.bunnyRepositories = new BunnyRepository();
            this.eggRepositories = new EggRepository();
            this.workshop = new Workshop();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType == "HappyBunny")
            {
                this.bunnyRepositories.Add(new HappyBunny(bunnyName));
            }
            else if (bunnyType == "SleepyBunny")
            {
                this.bunnyRepositories.Add(new SleepyBunny(bunnyName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny selectedBunny = bunnyRepositories.Models.FirstOrDefault(b => b.Name == bunnyName);

            if (selectedBunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            else
            {
                selectedBunny.Dyes.Add(new Dye(power));
            }

            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            eggRepositories.Add(new Egg(eggName, energyRequired));

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            IEgg selectedEgg = (Egg)eggRepositories.Models.FirstOrDefault(e => e.Name == eggName);
            IBunny selectedBunny = (Bunny)bunnyRepositories.Models.FirstOrDefault(b => b.Energy >= 50);

            if (selectedBunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            foreach (var bunny in bunnyRepositories.Models.OrderByDescending(b => b.Energy))
            {
                workshop.Color(selectedEgg, bunny);

                if (bunny.Energy <= 0)
                {
                    bunnyRepositories.Remove(bunny);
                }

                if (selectedEgg.IsDone())
                {
                    break;
                }
            }

            if (selectedEgg.IsDone())
            {
                return $"Egg {eggName} is done.";
            }
            else
            {
                return $"Egg {eggName} is not done.";
            }
        }

        public string Report()
        {
            List<IEgg> coloredEggs = eggRepositories
                .Models
                .Where(e => e.IsDone())
                .ToList();

            StringBuilder sb = new StringBuilder();

            //            "Name: {bunnyName1}"
            //            "Energy: {bunnyEnergy1}"
            //            "Dyes: {countDyes} not finished"


            sb.AppendLine($"{coloredEggs.Count.ToString()} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (IBunny bunny in bunnyRepositories.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count(x => !x.IsFinished())} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
