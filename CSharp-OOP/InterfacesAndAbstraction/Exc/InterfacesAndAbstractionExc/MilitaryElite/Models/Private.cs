using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(string firstName, string lastName, string id, decimal salary)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {Salary:F2}";
        }
    }
}
