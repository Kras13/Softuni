using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models = new List<IDecoration>();

        public IReadOnlyCollection<IDecoration> Models => this.models;

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.models.FirstOrDefault(d => d.GetType().Name == type);
        }

        public bool Remove(IDecoration model)
        {
            IDecoration selectedDecoration = this.models.FirstOrDefault(d => d.GetType().Name == model.GetType().Name);

            if (selectedDecoration == null)
            {
                return false;
            }

            this.models.Remove(selectedDecoration);
            return true;
        }
    }
}
