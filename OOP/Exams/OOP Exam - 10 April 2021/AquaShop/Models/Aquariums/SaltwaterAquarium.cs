namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int CustomCapacity = 25;
        public SaltwaterAquarium(string name)
            : base(name, CustomCapacity)
        {
        }
    }
}
