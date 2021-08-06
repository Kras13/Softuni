using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        public double Age { get; set; }

        public double Pressure { get; set; }

        public Tire(double age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }
    }
}
