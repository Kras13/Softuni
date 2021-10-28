namespace DefiningClasses
{
    public class Engine
    {
        public string Model { get; set; }

        public double Power { get; set; }

        public string Displacement { get; set; }

        public string Efficiency { get; set; }

        public Engine(string model, double power, string displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;

            if (displacement != null)
            {
                this.Displacement = displacement;
            }

            if (efficiency != null)
            {
                this.Efficiency = efficiency;
            }
        }
        public Engine()
        {

        }

        
    }
}
