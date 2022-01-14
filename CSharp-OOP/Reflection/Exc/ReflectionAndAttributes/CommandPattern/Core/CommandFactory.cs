using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandType)
        {
            Type type = Assembly.GetEntryAssembly()
                  .GetTypes()
                  .FirstOrDefault(t => t.Name == $"{commandType}Command");

            if (type == null)
            {
                throw new ArgumentException($"{commandType} is invalid command type.");
            }

            return (ICommand)Activator.CreateInstance(type);
        }
    }
}
