using System;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public double Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            return $"{this.Model}:" + Environment.NewLine +
                   $"  {this.Engine.Model}:" + Environment.NewLine +
                   $"    Power: {this.Engine.Power}" + Environment.NewLine +
                   $"    Displacement: {GetEngineDisplacement()}" + Environment.NewLine +
                   $"    Efficiency: {GetEngineEfficiency()}" + Environment.NewLine +
                   $"  Weight: {GetCarWeight()}" + Environment.NewLine +
                   $"  Color: {getCarColor()}";
        }

        private string GetEngineDisplacement()
        {
            if (this.Engine.Displacement != null)
            {
                return this.Engine.Displacement;
            }
            else
            {
                return $"n/a";
            }
        }

        private string GetEngineEfficiency()
        {
            if (this.Engine.Efficiency != null)
            {
                return this.Engine.Efficiency;
            }
            else
            {
                return $"n/a";
            }
        }

        private string GetCarWeight()
        {
            if (this.Weight != 0)
            {
                return Weight.ToString();
            }
            else
            {
                return $"n/a";
            }
        }

        private string getCarColor()
        {
            if (this.Color != null)
            {
                return this.Color;
            }
            else
            {
                return $"n/a";
            }
        }
    }
}
