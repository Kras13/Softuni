using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository drivers;
        private CarRepository cars;
        private RaceRepository races;

        public ChampionshipController()
        {
            drivers = new DriverRepository();
            cars = new CarRepository();
            races = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            var selectedDriver = this.drivers.GetByName(driverName);

            if (selectedDriver == null)
            {
                this.drivers.Add(new Driver(driverName));
                return $"Driver {driverName} is created.";
            }
            else
            {
                //Potential message bug !
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            var selectedCar = this.cars.GetByName(model);

            if (selectedCar == null)
            {
                // Create New Car
                if (type == "Muscle")
                {
                    this.cars.Add(new MuscleCar(model, horsePower));
                    return $"MuscleCar {model} is created.";
                }
                else
                {
                    this.cars.Add(new SportsCar(model, horsePower));
                    return $"SportsCar {model} is created.";
                }
            }
            else
            {
                throw new ArgumentException(string.Format($"Car {model} is already create."));
            }
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var selectedCar = this.cars.GetByName(carModel);
            var selectedDriver = this.drivers.GetByName(driverName);

            if (selectedDriver == null)
            {
                throw new InvalidOperationException(string.Format($"Driver {driverName} could not be found."));
            }

            if (selectedCar == null)
            {
                throw new InvalidOperationException(string.Format($"Car {carModel} could not be found."));
            }

            selectedDriver.AddCar(selectedCar);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var selectedRace = this.races.GetByName(raceName);
            if (selectedRace == null)
            {
                throw new InvalidOperationException(string.Format($"Race {raceName} could not be found."));
            }

            var selectedDriver = this.drivers.GetByName(driverName);
            if (selectedDriver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            selectedRace.AddDriver(selectedDriver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateRace(string name, int laps)
        {
            var selectedRace = this.races.GetByName(name);

            if (selectedRace == null)
            {
                this.races.Add(new Race(name, laps));
                return $"Race {name} is created.";
            }
            else
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }
        }

        public string StartRace(string raceName)
        {
            var selectedRace = this.races.GetByName(raceName);

            if (selectedRace == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (selectedRace.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            int lap = selectedRace.Laps;
            Dictionary<double, IDriver> driversByLaps = new Dictionary<double, IDriver>();

            List<IDriver> orderedDrivers = selectedRace.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(selectedRace.Laps)).Take(3).ToList();

            races.Remove(selectedRace);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, orderedDrivers[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, orderedDrivers[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, orderedDrivers[2].Name, raceName));

            orderedDrivers[0].WinRace();
            races.Remove(selectedRace);
            return sb.ToString().TrimEnd();
        }
    }
}
