using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        private List<IComponent> components;
        public IReadOnlyCollection<IComponent> Components => this.components;


        private List<IPeripheral> peripherals;
        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public void AddComponent(IComponent component)
        {
            var selectedComponent = this.components
                .FirstOrDefault(c => c.GetType().Name == component.GetType().Name);

            if (selectedComponent != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name, this.GetType().Name, this.Id));
            }
            else
            {
                this.components.Add(component);
            }
        }

        public IComponent RemoveComponent(string componentType)
        {
            var selectedComponent = this.components
                .FirstOrDefault(c => c.GetType().Name == componentType);
            if (this.Components.Count == 0 || selectedComponent == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,
                    componentType, this.GetType().Name, this.Id));
            }
            this.components.Remove(selectedComponent);

            return selectedComponent;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            var selectedComponent = this.peripherals
                .FirstOrDefault(p => p.GetType().Name == peripheral.GetType().Name);

            if (selectedComponent != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            else
            {
                this.peripherals.Add(peripheral);
            }
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var selectedPeriferial = this.peripherals
                .FirstOrDefault(p => p.GetType().Name == peripheralType);
            if (this.Peripherals.Count == 0 || selectedPeriferial == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType, this.GetType().Name, this.Id));
            }
            this.peripherals.Remove(selectedPeriferial);

            return selectedPeriferial;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine(" " + String.Format(SuccessMessages.ComputerComponentsToString, this.Components.Count));
            foreach (IComponent component in this.Components)
            {
                stringBuilder.AppendLine("  " + component.ToString());
            }

            stringBuilder.AppendLine(" " + String.Format(SuccessMessages.ComputerPeripheralsToString, this.Peripherals.Count,
                this.Peripherals.Any() ? this.Peripherals.Average(p => p.OverallPerformance) : 0));
            foreach (var peripheral in this.Peripherals)
            {
                stringBuilder.AppendLine("  " + peripheral.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + this.Components.Average(c => c.OverallPerformance);
                }
            }
        }

        public override decimal Price
        {
            get
            {
                return base.Price + this.components.Sum(c => c.Price) + this.peripherals.Sum(p => p.Price);
            }
        }
    }
}
