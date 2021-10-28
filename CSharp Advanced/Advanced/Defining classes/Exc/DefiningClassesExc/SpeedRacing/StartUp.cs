using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                decimal fuelAmount = decimal.Parse(tokens[1]);
                decimal fuelConsumption = decimal.Parse(tokens[2]);

                Car car = new Car(name, fuelAmount, fuelConsumption) { };

                cars.Add(car);
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] tokens = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Drive")
                {
                    string model = tokens[1];
                    decimal distance = decimal.Parse(tokens[2]);

                    foreach (var car in cars)
                    {
                        if (car.Model == model)
                        {
                            car.Drive(distance);
                        }
                    }
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}

