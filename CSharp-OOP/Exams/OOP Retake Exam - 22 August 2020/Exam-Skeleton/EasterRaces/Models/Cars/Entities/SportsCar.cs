namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int CustomMinHorsePower = 250;
        private const int CustomMaxHorsePower = 450;
        private const int CustomCubic = 3000;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, CustomCubic, CustomMinHorsePower, CustomMaxHorsePower)
        {
        }

        protected override bool ValidateHorsePower(int value)
        {
            if (value < CustomMinHorsePower || value > CustomMaxHorsePower)
            {
                return false;
            }

            return true;
        }
    }
}
