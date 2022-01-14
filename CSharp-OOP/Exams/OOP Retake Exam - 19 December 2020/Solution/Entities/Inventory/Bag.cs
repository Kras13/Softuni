using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity
        {
            get => capacity;
            set
            {
                capacity = value;
            }
        }

        public int Load => this.items.Sum(s => s.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            var selectedItem = items.FirstOrDefault(i => i.GetType().Name == name);

            if (selectedItem == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            else
            {
                return selectedItem;
            }
        }
    }
}
