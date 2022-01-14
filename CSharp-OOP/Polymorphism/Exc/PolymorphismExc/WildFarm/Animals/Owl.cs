using System;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        private const double weightModifier = 0.25;

        public Owl(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override void Feed(Food food, int quantityFood)
        {
            if (food.GetType().Name != "Meat")
            {
                throw new InvalidOperationException(
                    $"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += quantityFood;
            Weight += quantityFood * weightModifier;
        }
    }
}
