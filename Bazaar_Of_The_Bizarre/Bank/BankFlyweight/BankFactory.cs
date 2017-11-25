using System;
using System.Collections.Generic;

namespace Bazaar_Of_The_Bizarre.Bank.BankFlyweight {
	class BankFactory {
	    private static Dictionary<String, Bank> _bankMap = new Dictionary<string, Bank>();

        /// <summary>
        ///  Creates new bank if it does not exist and returns it. Otherwise existing bank is returned.
        /// </summary>
        /// <param name="name">Name of the bank</param>
        /// <returns>Bank Returns bank</returns>
	    public static Bank GetBank(String name)
	    {
	        if (!_bankMap.ContainsKey(name))
	        {
                _bankMap.Add(name, new Bazaar_Of_The_Bizarre.Bank.BankFlyweight.Bank(name));
	        }
	        return _bankMap[name];
	    }

        /// <summary>
        /// Prints out all banks.
        /// </summary>
	    public static void PrintBanks()
	    {
	        foreach (KeyValuePair<String, Bazaar_Of_The_Bizarre.Bank.BankFlyweight.Bank> Pair in _bankMap)
	        {
	            Console.WriteLine("Name = {0}, Bank = {1}", Pair.Key, Pair.Value);
	        }
	    }
    }
}
