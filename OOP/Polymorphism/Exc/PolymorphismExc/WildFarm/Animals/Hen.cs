using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Hen : Bird
    {
        private const double weightModifier = 0.35;

        public Hen(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void Feed(Food food, int quantityFood)
        {
            this.FoodEaten += quantityFood;
            Weight += quantityFood * weightModifier;
        }
    }
}
