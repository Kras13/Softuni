using MilitaryElite.Contracts;
using MilitaryElite.Enums;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string firstName, string lastName, string id, decimal salary, Corps corps)
            : base(firstName, lastName, id, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; private set; }
    }
}
