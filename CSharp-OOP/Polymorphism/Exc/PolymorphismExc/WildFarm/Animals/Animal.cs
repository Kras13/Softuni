using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        // string Name, double Weight, int FoodEaten;

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract string AskForFood();

        public abstract void Feed(Food food, int quantityFood);
    }
}
