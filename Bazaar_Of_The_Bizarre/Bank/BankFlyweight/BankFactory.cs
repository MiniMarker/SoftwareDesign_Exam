using System;
using System.Collections.Generic;

namespace Bazaar_Of_The_Bizarre.Bank.BankFlyweight {
	class BankFactory {
	    private static Dictionary<String, Bazaar_Of_The_Bizarre.Bank.BankFlyweight.Bank> BANKMAP = new Dictionary<string, Bazaar_Of_The_Bizarre.Bank.BankFlyweight.Bank>();

        //GetBank creates new bank if it does not exist and returns it. Otherwise existing bank is returned.
	    public static Bazaar_Of_The_Bizarre.Bank.BankFlyweight.Bank GetBank(String name)
	    {
	        if (!BANKMAP.ContainsKey(name))
	        {
                BANKMAP.Add(name, new Bazaar_Of_The_Bizarre.Bank.BankFlyweight.Bank(name));
	        }
	        return BANKMAP[name];
	    }

        //prints out all banks.
	    public static void PrintBanks()
	    {
	        foreach (KeyValuePair<String, Bazaar_Of_The_Bizarre.Bank.BankFlyweight.Bank> Pair in BANKMAP)
	        {
	            Console.WriteLine("Name = {0}, Bank = {1}", Pair.Key, Pair.Value);
	        }
	    }

    }
}
