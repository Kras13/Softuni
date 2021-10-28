using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Easter.Models.Dyes;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            foreach (Dye dye in bunny.Dyes.Where(d => d.Power > 0))
            {
                while (!egg.IsDone())
                {
                    if (bunny.Energy <= 0)
                    {
                        return;
                    }

                    if (dye.IsFinished())
                    {
                        break;
                    }

                    egg.GetColored();
                    bunny.Work();
                    dye.Use();
                }

                if (egg.IsDone())
                {
                    break;
                }
            }
        }
    }
}
