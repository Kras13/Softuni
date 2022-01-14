using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;
            this.HorsePower = horsePower;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (!ValidateModel(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (!ValidateHorsePower(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            // cubic centimeters / horsepower * laps
            return this.CubicCentimeters / this.HorsePower * laps;
        }

        protected abstract bool ValidateHorsePower(int value);

        private bool ValidateModel(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
            {
                return false;
            }
            return true;
        }
    }
}
