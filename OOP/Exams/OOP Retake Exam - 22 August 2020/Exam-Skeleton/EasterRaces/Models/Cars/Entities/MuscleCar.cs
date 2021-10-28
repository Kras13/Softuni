namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int CustomMinHorsePower = 400;
        private const int CustomMaxHorsePower = 600;
        private const int CustomCubic = 5000;

        public MuscleCar(string model, int horsePower)
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
