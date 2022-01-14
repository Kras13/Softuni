namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag
    {
        private const int CustomSatchelCapacity = 20;
        public Satchel() 
            : base(CustomSatchelCapacity)
        {
        }
    }
}
