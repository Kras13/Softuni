using System;

namespace PizzaCalories
{
    public class Dough
    {
        private double flourModifier;
        private double bakingTechModifier;
        private double grams;

        public Dough(string flourType, string bakingTech, int grams)
        {
            string flour = flourType.ToLower();
            string bakingTechnique = bakingTech.ToLower();

            if (flour != "white" && flour != "wholegrain")
            {
                throw new Exception("Invalid type of dough.");
            }

            if (bakingTechnique != "crispy" && bakingTechnique != "chewy" && bakingTechnique != "homemade")
            {
                throw new Exception("Invalid type of dough.");
            }

            if (flour == "white")
            {
                flourModifier = 1.5;
            }
            else if (flour == "wholegrain")
            {
                flourModifier = 1.0;
            }

            if (bakingTechnique == "crispy")
            {
                bakingTechModifier = 0.9;
            }
            else if (bakingTechnique == "chewy")
            {
                bakingTechModifier = 1.1;
            }
            else if (bakingTechnique == "homemade")
            {
                bakingTechModifier = 1.0;
            }

            if (grams >= 1 && grams <= 200)
            {
                this.grams = grams;
            }
            else
            {
                throw new Exception("Dough weight should be in the range [1..200]");
            }
        }

        public double Calories
        {
            get
            {
                return (2 * grams) * flourModifier * bakingTechModifier;
            }

        }
    }
}
