using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> models = new List<IBunny>();

        public IReadOnlyCollection<IBunny> Models => this.models;

        public void Add(IBunny model)
        {
            models.Add(model);
        }

        public IBunny FindByName(string name)
        {
            IBunny selectedBunny = models.FirstOrDefault(b => b.Name == name);
            return selectedBunny;
        }

        public bool Remove(IBunny model)
        {
            IBunny selectedBunny = models.FirstOrDefault(b => b.Name == model.Name);

            if (selectedBunny == null)
            {
                return false;
            }
            else
            {
                this.models.Remove(selectedBunny);
                return true;
            }
        }
    }
}
