using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public double Power { get; set; }

        public double Speed { get; set; }

        public Engine(double power, double speed)
        {
            this.Power = power;
            this.Speed = speed;
        }
    }
}
