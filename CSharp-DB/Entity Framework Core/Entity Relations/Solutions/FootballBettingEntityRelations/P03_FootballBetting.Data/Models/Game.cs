using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            Bets = new HashSet<Bet>();
        }

        [Key]
        public int GameId { get; set; }

        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        [ForeignKey("Awayteam")]
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }

        public double DrawBetRate { get; set; }

        [Required]
        public string Result { get; set; }

        public ICollection<Bet> Bets { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
