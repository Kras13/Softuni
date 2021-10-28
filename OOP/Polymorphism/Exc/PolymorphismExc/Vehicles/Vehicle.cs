using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuel, double fuelConsumption, double tankCapacity, double airConditionerModifier)
        {
            this.TankCapacity = tankCapacity;
            this.Fuel = fuel;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionerModifier = airConditionerModifier;
        }

        protected virtual double AirConditionerModifier { get; set; }

        private double fuel;
        public double Fuel
        {
            get => this.fuel;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.Fuel = 0;
                }
                else
                {
                    this.fuel = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity
        {
            get; private set;
        }

        public void Drive(double distance)
        {
            double requiredFuel = distance * (FuelConsumption + AirConditionerModifier);

            if (requiredFuel > this.Fuel)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.Fuel -= requiredFuel;
        }

        public virtual void Refuel(double amount)
        {
            if (amount > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }

            if (amount <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }

            this.Fuel += amount;
        }
    }
}
