using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre {
	class BankFactory {
	    private static Dictionary<String, Bank> BANKMAP = new Dictionary<string, Bank>();

        //GetBank creates new bank if it does not exist and returns it. Otherwise existing bank is returned.
	    public static Bank GetBank(String name)
	    {
	        if (!BANKMAP.ContainsKey(name))
	        {
                BANKMAP.Add(name, new Bank(name));
	        }
	        return BANKMAP[name];
	    }

        //prints out all banks.
	    public static void PrintBanks()
	    {
	        foreach (KeyValuePair<String, Bank> Pair in BANKMAP)
	        {
	            Console.WriteLine("Name = {0}, Bank = {1}", Pair.Key, Pair.Value);
	        }
	    }

    }
}
