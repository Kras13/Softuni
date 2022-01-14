using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        public Driver(string name)
        {
            this.Name = name;
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


        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
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
