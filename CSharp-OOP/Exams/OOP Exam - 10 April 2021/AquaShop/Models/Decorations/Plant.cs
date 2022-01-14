using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int CustomComfort = 5;
        private const decimal CustomPrice = 10;

        public Plant()
            : base(CustomComfort, CustomPrice)
        {
        }
    }
}
