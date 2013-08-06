using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    enum CurrencyType { USD, GBP, JPY } //List of currency types that can be expanded if conversion factors are desired in the future
    /// <summary>
    /// Vendor Class
    /// This class functions as a vending machine for a list of products stored in the machine.
    /// This tracks the amount of money inserted into the vending machine and then dispenses 
    /// the change due at the end of the transaction. This acts as a rear-loaded vending machine.
    /// </summary>
    class Vendor
    {
        private Dictionary<String, Queue<ItemBase>> itemStock;    //Each position has a list of items that exist in that region.
                                                            //The first in the list is the one that will be displayed on the menu
        private float currentMoney;
        //private CurrencyType currency;
        public float CurrentMoney { get { return currentMoney; } }
        public Dictionary<String, Queue<ItemBase>> ItemStock { get { return itemStock; } }
        //public CurrencyType Currency { get { return currency; } }
        
        public Vendor(Dictionary<String, Queue<ItemBase>> stock)
        {
            itemStock = stock;
        }
        
        public void insertMoney(MonetaryUnit money)
        {
            currentMoney += money.Value;
        }
        
        public List<MonetaryUnit> changeReturn()
        {
            USD usd = new USD();
            return usd.getBestChange(currentMoney);
        }

        public bool itemInStock(string desiredPos)
        {
            return (itemStock[desiredPos].Count > 0);
        }

        public ItemBase vend(string desiredPos)
        {
            return itemStock[desiredPos].Dequeue();
        }

        public void stockItems(string position, Item item)
        {
            ItemStock[position].Enqueue(item); 
        }
    }
}
