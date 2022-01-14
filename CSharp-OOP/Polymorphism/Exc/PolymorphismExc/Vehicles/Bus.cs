namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double airConditionerModifier = 1.4;

        public Bus(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity, airConditionerModifier)
        {
        }

        public void TurnOnAirConditioner()
        {
            this.AirConditionerModifier = airConditionerModifier;
        }

        public void TurnOffAirConditioner()
        {
            this.AirConditionerModifier = 0;
        }
    }
}
