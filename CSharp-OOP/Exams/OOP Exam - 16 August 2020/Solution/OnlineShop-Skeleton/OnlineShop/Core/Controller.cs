using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            var selectedComputer = this.computers.FirstOrDefault(c => c.Id == id);

            if (selectedComputer != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            if (computerType == nameof(Laptop))
            {
                this.computers.Add(new Laptop(id, manufacturer, model, price));
            }
            else if (computerType == nameof(DesktopComputer))
            {
                this.computers.Add(new DesktopComputer(id, manufacturer, model, price));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            return $"Computer with id {id} added successfully.";
        }

        public string AddComponent(int computerId, int id, string componentType,
            string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            var selectedComputer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (selectedComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            if (componentType == nameof(CentralProcessingUnit))
            {
                var component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                selectedComputer.AddComponent(component);
                this.components.Add(component);
            }
            else if (componentType == nameof(Motherboard))
            {
                var component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                selectedComputer.AddComponent(component);
                this.components.Add(component);
            }
            else if (componentType == nameof(PowerSupply))
            {
                var component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                selectedComputer.AddComponent(component);
                this.components.Add(component);
            }
            else if (componentType == nameof(RandomAccessMemory))
            {
                var component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                selectedComputer.AddComponent(component);
                this.components.Add(component);
            }
            else if (componentType == nameof(SolidStateDrive))
            {
                var component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                selectedComputer.AddComponent(component);
                this.components.Add(component);
            }
            else if (componentType == nameof(VideoCard))
            {
                var component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                selectedComputer.AddComponent(component);
                this.components.Add(component);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }
        public string RemoveComponent(string componentType, int computerId)
        {
            var selectedComputer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (selectedComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var selectedComponent = this.components.FirstOrDefault(c => c.GetType().Name == componentType);

            selectedComputer.RemoveComponent(componentType);
            this.components.Remove(selectedComponent);

            return $"Successfully removed {componentType} with id {selectedComponent.Id}.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType,
            string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            var selectedComputer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (selectedComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (this.peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            if (peripheralType == nameof(Headset))
            {
                var per = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                this.peripherals.Add(per);
                selectedComputer.AddPeripheral(per);
            }
            else if (peripheralType == nameof(Keyboard))
            {
                var per = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                this.peripherals.Add(per);
                selectedComputer.AddPeripheral(per);
            }
            else if (peripheralType == nameof(Monitor))
            {
                var per = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                this.peripherals.Add(per);
                selectedComputer.AddPeripheral(per);
            }
            else if (peripheralType == nameof(Mouse))
            {
                var per = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                this.peripherals.Add(per);
                selectedComputer.AddPeripheral(per);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var selectedComputer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (selectedComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var selectedPer = this.peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            selectedComputer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(selectedPer);
            return $"Successfully removed {peripheralType} with id {selectedPer.Id}.";
        }

        public string BuyComputer(int id)
        {
            var selectedComputer = this.computers.FirstOrDefault(c => c.Id == id);

            if (selectedComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            this.computers.Remove(selectedComputer);
            return selectedComputer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            int compId = -5;

            foreach (var comp in this.computers.OrderByDescending(c => c.OverallPerformance))
            {
                if (budget >= comp.Price)
                {
                    compId = comp.Id;
                    break;
                }
            }

            var selectedComputer = this.computers.FirstOrDefault(c => c.Id == compId);

            if (selectedComputer == null || this.computers.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(selectedComputer);
            return selectedComputer.ToString();
        }


        public string GetComputerData(int id)
        {
            var selectedComputer = this.computers.FirstOrDefault(c => c.Id == id);

            if (selectedComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return selectedComputer.ToString();
        }
    }
}
