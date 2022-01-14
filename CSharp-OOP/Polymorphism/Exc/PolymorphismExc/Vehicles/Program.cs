using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateNewVehicle();
            Vehicle truck = CreateNewVehicle();
            Vehicle bus = CreateNewVehicle();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] line = Console.ReadLine().Split();

                string command = line[0];
                string type = line[1];
                double parameter = double.Parse(line[2]);

                try
                {
                    if (command == "Drive")
                    {
                        if (type == nameof(Car))
                        {
                            car.Drive(parameter);
                            Console.WriteLine($"Car travelled {parameter} km");
                        }
                        else if (type == nameof(Truck))
                        {
                            truck.Drive(parameter);
                            Console.WriteLine($"Truck travelled {parameter} km");
                        }
                        else
                        {
                            bus.Drive(parameter);
                            Console.WriteLine($"Bus travelled {parameter} km");
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        ((Bus)bus).TurnOffAirConditioner();
                        bus.Drive(parameter);
                        Console.WriteLine($"Bus travelled {parameter} km");
                        ((Bus)bus).TurnOnAirConditioner();
                    }
                    else if (command == "Refuel")
                    {
                        if (type == nameof(Car))
                        {
                            car.Refuel(parameter);
                        }
                        else if (type == nameof(Truck))
                        {
                            truck.Refuel(parameter);
                        }
                        else if (type == nameof(Bus))
                        {
                            bus.Refuel(parameter);
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {car.Fuel:F2}");
            Console.WriteLine($"Truck: {truck.Fuel:F2}");
            Console.WriteLine($"Bus: {bus.Fuel:F2}");
        }

        private static Vehicle CreateNewVehicle()
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = input[0];

            if (type == nameof(Car))
            {
                double fuelQunatity = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);
                double tankCapacity = double.Parse(input[3]);

                return new Car(fuelQunatity, fuelConsumption, tankCapacity);
            }
            else if (type == nameof(Truck))
            {
                double fuelQunatity = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);
                double tankCapacity = double.Parse(input[3]);

                return new Truck(fuelQunatity, fuelConsumption, tankCapacity);
            }
            else
            {
                double fuelQunatity = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);
                double tankCapacity = double.Parse(input[3]);

                return new Bus(fuelQunatity, fuelConsumption, tankCapacity);
            }
        }
    }
}
