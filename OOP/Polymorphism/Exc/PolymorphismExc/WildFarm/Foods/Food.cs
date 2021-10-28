namespace WildFarm.Foods
{
    public abstract class Food
    {
        public Food(int qunatity)
        {
            this.Quantity = qunatity;
        }

        public int Quantity { get; private set; }

    }
}
