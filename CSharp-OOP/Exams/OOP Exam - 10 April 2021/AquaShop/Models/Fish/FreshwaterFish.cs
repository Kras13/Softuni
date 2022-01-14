namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int CustomSize = 3;
        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price, CustomSize)
        {
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
