namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double defaultMilliliters = 50;
        private const decimal defaultPrice = 3.5m;

        public Coffee(string name, double caffeine)
            : base(name, defaultPrice, defaultMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
