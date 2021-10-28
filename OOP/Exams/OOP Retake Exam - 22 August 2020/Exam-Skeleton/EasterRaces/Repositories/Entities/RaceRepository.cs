using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => this.models;

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.Models;
        }

        public IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(r => r.Name == name);
        }

        public bool Remove(IRace model)
        {
            IRace selectedRace = this.models.FirstOrDefault(r => r.Name == model.Name);

            if (selectedRace == null)
            {
                return false;
            }
            else
            {
                this.models.Remove(selectedRace);
                return true;
            }
        }
    }
}
