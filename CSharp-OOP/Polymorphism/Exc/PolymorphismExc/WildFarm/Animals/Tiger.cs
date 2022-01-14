using System;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Tiger : Feline
    {
        private const double weightModifier = 1.00;

        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
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
