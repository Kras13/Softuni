using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.drivers = new List<IDriver>();
            this.Name = name;
            this.Laps = laps;
        }

        private string name;
        public string Name
        {
            get => this.name;
            private set
            {
                if (!ValidateName(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                this.name = value;
            }
        }

        private int laps;
        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }
            if (driver.Car == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            IDriver selectedDriver = this.drivers.FirstOrDefault(d => d.Name == driver.Name);

            if (selectedDriver != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.drivers.Add(driver);
        }

        private bool ValidateName(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 5)
            {
                return false;
            }

            return true;
        }
    }
}
