using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        //        •	Name
        //•	Number of badges
        //•	A collection of pokemon

        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public Trainer()
        {
            Pokemons = new List<Pokemon>();
            Badges = 0;
        }
    }
}
