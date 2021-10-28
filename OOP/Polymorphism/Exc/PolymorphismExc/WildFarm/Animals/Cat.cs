using System;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Cat : Feline
    {
        private const double weightModifier = 0.30;
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override void Feed(Food food, int quantityFood)
        {
            if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat")
            {
                throw new InvalidOperationException(
                    $"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += quantityFood;
            Weight += quantityFood * weightModifier;
        }
    }
}
