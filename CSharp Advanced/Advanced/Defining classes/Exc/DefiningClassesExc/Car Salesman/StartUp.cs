using DefiningClasses;
using System;
using System.Collections.Generic;

namespace DefiningClases
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int enginesCount = int.Parse(Console.ReadLine());

            HashSet<Engine> engines = new HashSet<Engine>();
            HashSet<Car> cars = new HashSet<Car>();

            for (int i = 0; i < enginesCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    Engine engine = new Engine(tokens[0], double.Parse(tokens[1]), tokens[2], tokens[3]);
                    engines.Add(engine);
                }
                else if (tokens.Length == 3)
                {
                    if (double.TryParse(tokens[2], out double displacement))
                    {
                        Engine engine = new Engine(tokens[0], double.Parse(tokens[1]), displacement.ToString(), null);
                        engines.Add(engine);
                    }
                    else
                    {
                        Engine engine = new Engine(tokens[0], double.Parse(tokens[1]), null, tokens[2]);
                        engines.Add(engine);
                    }
                }
                else if (tokens.Length == 2)
                {
                    Engine engine = new Engine(tokens[0], double.Parse(tokens[1]), null, null);
                    engines.Add(engine);

                }
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    string model = tokens[0];
                    string engineName = tokens[1];
                    Engine selectedEngine = new Engine();

                    foreach (var engine in engines)
                    {
                        if (engine.Model == engineName)
                        {
                            selectedEngine = engine;
                            break;
                        }
                    }

                    Car car = new Car()
                    {
                        Model = model,
                        Engine = selectedEngine,
                        Weight = double.Parse(tokens[2]),
                        Color = tokens[3]
                    };
                    cars.Add(car);
                }
                else if (tokens.Length == 3)
                {
                    string model = tokens[0];
                    string engineName = tokens[1];
                    Engine selectedEngine = new Engine();

                    foreach (var engine in engines)
                    {
                        if (engine.Model == engineName)
                        {
                            selectedEngine = engine;
                            break;
                        }
                    }

                    if (double.TryParse(tokens[2], out double weight))
                    {
                        Car car = new Car()
                        {
                            Model = model,
                            Engine = selectedEngine,
                            Weight = weight
                        };
                        cars.Add(car);
                    }
                    else
                    {
                        Car car = new Car()
                        {
                            Model = model,
                            Engine = selectedEngine,
                            Color = tokens[2]
                        };
                        cars.Add(car);
                    }
                }
                else
                {
                    string model = tokens[0];
                    string engineName = tokens[1];
                    Engine selectedEngine = new Engine();

                    foreach (var engine in engines)
                    {
                        if (engine.Model == engineName)
                        {
                            selectedEngine = engine;
                            break;
                        }
                    }

                    Car car = new Car()
                    {
                        Model = model,
                        Engine = selectedEngine,
                    };
                    cars.Add(car);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
