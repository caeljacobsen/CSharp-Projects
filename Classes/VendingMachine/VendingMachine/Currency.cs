using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    /*
     class USD(object):
	"""
	Object that contains the definition for the most used United States Dollar currency
	Can return the best change when given a specific money value (in dollars)
	"""
	def __init__(self):
		self.coins = ['Hundred Dollar', 'Fifty Dollar', 'Twenty Dollar', 'Ten Dollar', 'Five Dollar', 'Dollar','Quarter','Dime','Nickel','Penny']
		self.coinVals = [10000, 5000, 2000, 1000, 500, 100, 25, 10, 5, 1]
	#takes two float values
	#returns list containing tuples that contain (amount of money, name of coin)
	def getBestChange(self, cost, moneyGiven):
		"""
		This function calculates the best change for a given transaction.
		cost is the amount that was to be charged
		moneyGiven is the amount that was paid.
		Returns the best change available given the currency
		"""
		change = []
		#print(str(cost) + "," + str(moneyGiven))
		moneyGiven = moneyGiven - cost
		moneyGiven = int(round(moneyGiven * 100, 0)) #get cents, base unit of currency, use round to negate round off error. Funny Coincidence
		print(moneyGiven)
		if(moneyGiven > 0):
			for i in range(len(self.coinVals)):
				#If it's zero we don't need to include it.
				if(int(moneyGiven/self.coinVals[i]) != 0):
					change.append((int(moneyGiven/self.coinVals[i]), self.coins[i]))
				moneyGiven = ( moneyGiven % self.coinVals[i] )
		#Run through this loop if the amount isn't needed to complete the transaction
		else:
			for i in range(len(self.coinVals)):
#			If it's zero we don't need to include it.
				if(int(moneyGiven/self.coinVals[i]) != 0):
					change.append((int(moneyGiven/self.coinVals[i]), self.coins[i]))
				moneyGiven = (moneyGiven % -self.coinVals[i])
		return change
     */

    public class MonetaryUnit
    {
        private string name;
        private int value;
        public string Name { get { return name; } }
        public int Value { get { return Value; } }
        
        public MonetaryUnit(string newName, int newValue)
        {
            name = newName;
            value = newValue;
        }

        public MonetaryUnit(MonetaryUnit unit)
        {
            name = unit.name;
            value = unit.value;
        }
    }

    public abstract class CurrencyBase
    {
        /// <summary>
        /// List of all currency units. Must be ordered from highest value unit to lowest value unit.
        /// </summary>
        private List<MonetaryUnit> monetaryUnits;
        public List<MonetaryUnit> MonetaryUnits { get { return monetaryUnits; } set { monetaryUnits = value; } }
        public CurrencyBase() 
        {
        }

        public List<MonetaryUnit> getBestChange(float money)
        {
            List<MonetaryUnit> bestChange = new List<MonetaryUnit>();
            money = Math.Abs(money*100);
            for ( int i = 0; i < monetaryUnits.Count; i++ )
            {
                if( (money / monetaryUnits[i].Value) != 0)
                {
                    bestChange.Add(new MonetaryUnit(monetaryUnits[i]));
                }
                money /= monetaryUnits[i].Value;
            }
            return bestChange;
        }
    }

    public class USD : CurrencyBase
    {
        public USD()
        {
            List<MonetaryUnit> moneyUnits = new List<MonetaryUnit>();
            //Must order the units from highest to lowest value for purposes of the function.
            moneyUnits.Add(new MonetaryUnit("Hundred-Dollar Bill", 10000));
            moneyUnits.Add(new MonetaryUnit("Fifty-Dollar Bill", 5000));
            moneyUnits.Add(new MonetaryUnit("Twenty-Dollar Bill", 2000));
            moneyUnits.Add(new MonetaryUnit("Tehn-Dollar Bill", 1000));
            moneyUnits.Add(new MonetaryUnit("Five-Dollar Bill", 500));
            moneyUnits.Add(new MonetaryUnit("Two-Dollar Bill", 200));
            moneyUnits.Add(new MonetaryUnit("Dollar Bill", 100));
            moneyUnits.Add(new MonetaryUnit("Half-Dollar", 50));
            moneyUnits.Add(new MonetaryUnit("Quarter", 25));
            moneyUnits.Add(new MonetaryUnit("Dime", 10));
            moneyUnits.Add(new MonetaryUnit("Nickel", 5));
            moneyUnits.Add(new MonetaryUnit("Penny", 1));
            MonetaryUnits = moneyUnits;
        }
    }
}
