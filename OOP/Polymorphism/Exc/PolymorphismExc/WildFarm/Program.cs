using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Foods;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string foodInput = Console.ReadLine();
                string[] foods = foodInput.Split();

                Animal animal = CreateAnimal(line);
                Food food = CreateFood(foodInput);

                Console.WriteLine(animal.AskForFood());
                animals.Add(animal);

                try
                {
                    animal.Feed(food, int.Parse(foods[1]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Animal animal1 in animals)
            {
                Console.WriteLine(animal1);
            }
        }

        private static Food CreateFood(string foodInput)
        {
            Food food = null;
            string[] tokens = foodInput.Split();

            if (tokens[0] == nameof(Fruit))
            {
                food = new Fruit(int.Parse(tokens[1]));
            }
            else if (tokens[0] == nameof(Meat))
            {
                food = new Meat(int.Parse(tokens[1]));
            }
            else if (tokens[0] == nameof(Seeds))
            {
                food = new Seeds(int.Parse(tokens[1]));
            }
            else if (tokens[0] == nameof(Vegetable))
            {
                food = new Vegetable(int.Parse(tokens[1]));
            }

            return food;
        }

        private static Animal CreateAnimal(string line)
        {
            string[] tokens = line.Split();
            Animal animal = null;

            if (tokens[0] == nameof(Cat))
            {
                //•	Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}";
                string name = tokens[1];
                double weight = double.Parse(tokens[2]);
                string livingRegion = tokens[3];
                string breed = tokens[4];
                animal = new Cat(name, weight, 0, livingRegion, breed);
            }
            else if (tokens[0] == nameof(Tiger))
            {
                string name = tokens[1];
                double weight = double.Parse(tokens[2]);
                string livingRegion = tokens[3];
                string breed = tokens[4];
                animal = new Tiger(name, weight, 0, livingRegion, breed);
            }
            else if (tokens[0] == nameof(Owl))
            {
                // "{Type} {Name} {Weight} {WingSize}";
                string name = tokens[1];
                double weight = double.Parse(tokens[2]);
                double wingSize = double.Parse(tokens[3]);
                animal = new Owl(name, weight, 0, wingSize);
            }
            else if (tokens[0] == nameof(Hen))
            {
                string name = tokens[1];
                double weight = double.Parse(tokens[2]);
                double wingSize = double.Parse(tokens[3]);
                animal = new Hen(name, weight, 0, wingSize);
            }
            else if (tokens[0] == nameof(Dog))
            {
                // "{Type} {Name} {Weight} {LivingRegion}";
                string name = tokens[1];
                double weight = double.Parse(tokens[2]);
                string livingRegion = tokens[3];
                animal = new Dog(name, weight, 0, livingRegion);
            }
            else if (tokens[0] == nameof(Mouse))
            {
                string name = tokens[1];
                double weight = double.Parse(tokens[2]);
                string livingRegion = tokens[3];
                animal = new Mouse(name, weight, 0, livingRegion);
            }

            return animal;
        }
    }
}
