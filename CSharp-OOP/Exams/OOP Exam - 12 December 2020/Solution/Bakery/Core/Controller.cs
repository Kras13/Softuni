using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<Table> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<Table>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Water")
            {
                this.drinks.Add(new Water(name, portion, brand));
            }
            if (type == "Tea")
            {
                this.drinks.Add(new Tea(name, portion, brand));
            }
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                this.bakedFoods.Add(new Bread(name, price));
            }
            if (type == "Cake")
            {
                this.bakedFoods.Add(new Cake(name, price));
            }
            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                this.tables.Add(new InsideTable(tableNumber, capacity));
            }
            if (type == "OutsideTable")
            {
                this.tables.Add(new OutsideTable(tableNumber, capacity));
            }
            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder result = new StringBuilder();

            foreach (var table in this.tables.Where(t => !t.IsReserved))
            {
                result.AppendLine(table.GetFreeTableInfo());
            }

            return result.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {this.totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var selectedTable = this.tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = selectedTable.GetBill();
            this.totalIncome += bill;
            selectedTable.Clear();

            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {bill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var selectedTable = tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);
            if (selectedTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var selectedDrink = this.drinks
                .FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (selectedDrink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            selectedTable.OrderDrink(selectedDrink);
            return string.Format("Table {0} ordered {1} {2}", tableNumber, drinkName, drinkBrand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var selectedTable = this.tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);
            if (selectedTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var selectedFood = this.bakedFoods
                .FirstOrDefault(f => f.Name == foodName);
            if (selectedFood == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            selectedTable.OrderFood(selectedFood);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            var selectedTable = this.tables
                .FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (selectedTable == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            selectedTable.Reserve(numberOfPeople);
            return $"Table {selectedTable.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
