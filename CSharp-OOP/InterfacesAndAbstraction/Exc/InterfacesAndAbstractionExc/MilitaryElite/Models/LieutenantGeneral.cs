using MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;

        public LieutenantGeneral(string firstName, string lastName, string id, decimal salary)
            : base(firstName, lastName, id, salary)
        {
            this.privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates => this.privates.AsReadOnly();

        public void AddPrivate(IPrivate @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var @private in this.privates)
            {
                sb.AppendLine($"  {@private}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
