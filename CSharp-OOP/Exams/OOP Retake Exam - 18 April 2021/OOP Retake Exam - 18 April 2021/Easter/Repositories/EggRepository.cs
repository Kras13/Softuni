using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> models = new List<IEgg>();
        public IReadOnlyCollection<IEgg> Models => this.models;

        public void Add(IEgg model)
        {
            this.models.Add(model);
        }

        public IEgg FindByName(string name)
        {
            IEgg selectedEgg = models.FirstOrDefault(e => e.Name == name);
            return selectedEgg;
        }

        public bool Remove(IEgg model)
        {
            IEgg selectedEgg = models.FirstOrDefault(e => e.Name == model.Name);

            if (selectedEgg == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
