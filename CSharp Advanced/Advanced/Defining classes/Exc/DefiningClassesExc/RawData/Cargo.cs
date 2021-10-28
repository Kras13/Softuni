using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
        public double Weight { get; set; }

        public string Type { get; set; }

        public Cargo(double weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }
    }
}
