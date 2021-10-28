using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Entities;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            IChampionshipController controller = new ChampionshipController(); //new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();

            // test creating invalid musle car
            //Car car = new MuscleCar("Mustang", 300, 500);

            //Driver driver = new Driver("Ivanchooo");
            //System.Console.WriteLine(driver.Name);
        }
    }
}
