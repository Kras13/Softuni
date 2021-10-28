using System;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Dog : Mammal
    {
        private const double weightModifier = 0.40;

        public Dog(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
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

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {FoodEaten}]";
        }
    }
}