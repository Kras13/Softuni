using System;
using System.Collections.Generic;
using System.Linq;

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
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                double engineSpeed = double.Parse(tokens[1]);
                double enginePower = double.Parse(tokens[2]);
                double cargoWeight = double.Parse(tokens[3]);
                string cargoType = tokens[4];
                double tire1Pressure = double.Parse(tokens[5]);
                double tire1Age = double.Parse(tokens[6]);
                double tire2Pressure = double.Parse(tokens[7]);
                double tire2Age = double.Parse(tokens[8]);
                double tire3Pressure = double.Parse(tokens[9]);
                double tire3Age = double.Parse(tokens[10]);
                double tire4Pressure = double.Parse(tokens[11]);
                double tire4Age = double.Parse(tokens[12]);

                Engine engine = new Engine(enginePower, engineSpeed) { };
                Cargo cargo = new Cargo(cargoWeight, cargoType) { };
                Tire[] tires =
                {
                    new Tire(tire1Age,tire1Pressure),
                    new Tire(tire2Age,tire2Pressure),
                    new Tire(tire3Age,tire3Pressure),
                    new Tire(tire4Age,tire4Pressure),
                };

                Car car = new Car(model, engine, cargo, tires) { };
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (Car car in cars.Where(c => c.Cargo.Type == "fragile"))
                {
                    foreach (Tire tire in car.Tires)
                    {
                        if (tire.Pressure < 1)
                        {
                            Console.WriteLine(car.Model);
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (Car car in cars.Where(c => c.Cargo.Type == "flamable"))
                {
                    if (car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
