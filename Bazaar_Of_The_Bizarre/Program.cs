using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade;

namespace Bazaar_Of_The_Bizarre {
	class Program {
        public static void Main(string[] args)
        {
	        var stuff = new Store();
	        var stuff1 = new Store();
	        var stuff2 = new Store();
	        var stuff3 = new Store();
	        stuff.GetShop("cheap");
	        stuff1.GetShop("expensive");
	        stuff2.GetShop("cheap");
	        stuff3.GetShop("expensive");

			Console.WriteLine(stuff.Shop.GetName());
			Console.WriteLine(stuff.Shop.GetPrice());
			Console.WriteLine(stuff1.Shop.GetName(), stuff.Shop.GetPrice());
	        Console.WriteLine(stuff1.Shop.GetPrice());
			Console.WriteLine(stuff2.Shop.GetName(), stuff.Shop.GetPrice());
	        Console.WriteLine(stuff2.Shop.GetPrice());
			Console.WriteLine(stuff3.Shop.GetName(), stuff.Shop.GetPrice());
	        Console.WriteLine(stuff3.Shop.GetPrice());

	        Bank.BankFlyweight.Bank _bank = Bank.BankFlyweight.BankFactory.GetBank("DnB");
	        Customer _Customer1 = new Customer(120893, "Ellen Elefsen");
	        _bank.CreateAccount(_Customer1.GetSocialSecurityNumber());
	        Customer _Customer2 = new Customer(120194, "Kai Johnsen");
	        _bank.CreateAccount(_Customer2.GetSocialSecurityNumber());
	        Customer _Customer3 = new Customer(230266, "Mats Toret");
	        _bank.CreateAccount(_Customer3.GetSocialSecurityNumber());

			Console.ReadKey();

        }
    }
}
