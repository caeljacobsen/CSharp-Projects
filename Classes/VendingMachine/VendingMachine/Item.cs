using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public abstract class ItemBase
    {
        protected string name;
        protected float cost;
        protected string description;
        public string Name { get { return name; } }
        public float Cost { get { return cost; } }
        public string Description { get { return description; } }
    }

    public class Item : ItemBase
    {
        public Item(string itemName = "Generic Item", float itemCost = 0f, string itemDescription = "Generic Description")
        {
            this.name = itemName;
            this.cost = itemCost;
            this.description = itemDescription;
        }
    }
}
