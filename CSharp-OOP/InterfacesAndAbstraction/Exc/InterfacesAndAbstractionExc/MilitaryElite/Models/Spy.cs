using MilitaryElite.Contracts;
using System;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string lastName, string id, int codeNumber)
            : base(firstName, lastName, id)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                Environment.NewLine +
                $"Code Number: {CodeNumber}";
        }
    }
}
