using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.playerStats = new List<Stat>();
            InputStats();
        }

        private readonly List<Stat> playerStats;

        private string name;
        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfNameIsInvalid(value, "A name should not be empty.");
                this.name = value;
            }
        }

        public int OverallSkill => (int)playerStats.Average(s => s.Value);

        public void RegisterStats(List<double> statRates)
        {
            for (int i = 0; i < playerStats.Count; i++)
            {
                Validator.ThrowIfStatNotValid(statRates[i], $"{playerStats[i].Type} should be between 0 and 100.");
                this.playerStats[i].Value = statRates[i];
            }
        }

        private void InputStats()
        {
            Stat enduranceStat = new Stat(0, "Endurance");
            Stat sprintStat = new Stat(0, "Sprint");
            Stat dribbleStat = new Stat(0, "Dribble");
            Stat passingStat = new Stat(0, "Passing");
            Stat shootingStat = new Stat(0, "Shooting");

            playerStats.Add(enduranceStat);
            playerStats.Add(sprintStat);
            playerStats.Add(dribbleStat);
            playerStats.Add(passingStat);
            playerStats.Add(shootingStat);

        }
    }
}
