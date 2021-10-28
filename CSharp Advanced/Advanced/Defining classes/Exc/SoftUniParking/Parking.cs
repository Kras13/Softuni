using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }

        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string RegistrationNumber)
        {
            Car car = this.cars
                .FirstOrDefault(c => c.RegistrationNumber == RegistrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(car);
            return $"Successfully removed {RegistrationNumber}";
        }

        public Car GetCar(string RegistrationNumber)
        {
            return cars.FirstOrDefault(c => c.RegistrationNumber == RegistrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            this.cars = cars
                .Where(c => !RegistrationNumbers.Contains(c.RegistrationNumber))
                .ToList();
        }
    }
}
