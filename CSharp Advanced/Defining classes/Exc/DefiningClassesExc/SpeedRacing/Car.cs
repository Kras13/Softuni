using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }

        public decimal FuelAmount { get; set; }

        public decimal FuelConsumptionPerKilometer { get; set; }

        public decimal TravelledDistance { get; set; }

        public Car(string model, decimal fuelAmount, decimal fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumption;
            this.TravelledDistance = 0;
        }

        public void Drive(decimal distance)
        {
            decimal consumedFuel = distance * FuelConsumptionPerKilometer;

            if (FuelAmount >= consumedFuel)
            {
                FuelAmount -= consumedFuel;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
