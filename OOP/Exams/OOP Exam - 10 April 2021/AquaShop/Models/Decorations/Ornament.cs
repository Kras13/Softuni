namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int CustomComfort = 1;
        private const decimal CustomPrice = 5;

        public Ornament() 
            : base(CustomComfort, CustomPrice)
        {
        }
    }
}
