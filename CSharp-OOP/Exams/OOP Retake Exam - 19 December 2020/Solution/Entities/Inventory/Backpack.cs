namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int CustomBackpackCapacity = 100;
        public Backpack()
            : base(CustomBackpackCapacity)
        {
        }
    }
}
