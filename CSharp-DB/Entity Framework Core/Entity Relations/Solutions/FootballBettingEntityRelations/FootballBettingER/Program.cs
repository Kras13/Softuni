using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting 
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext context = new FootballBettingContext();
            context.Database.EnsureCreated();

            Console.WriteLine("Database created!");

            context.Database.EnsureDeleted();
        }
    }
}
