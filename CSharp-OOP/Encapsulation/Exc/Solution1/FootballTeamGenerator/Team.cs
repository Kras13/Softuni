using System.Collections.Generic;
using System.Linq;
using System;

namespace FootballTeamGenerator
{
    public class Team
    {
        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        private List<Player> players;

        public string Name { get; private set; }

        public int Rating
        {
            get
            {
                if (this.players.Count != 0)
                {
                    return (int)this.players.Average(pl => pl.OverallSkill);
                }

                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePLayer(string playerName)
        {
            Player selectedPlayer = players.FirstOrDefault(pl => pl.Name == playerName);

            if (selectedPlayer == null)
            {
                throw new Exception($"Player {playerName} is not in {this.Name} team.");
            }
        }
    }
}
