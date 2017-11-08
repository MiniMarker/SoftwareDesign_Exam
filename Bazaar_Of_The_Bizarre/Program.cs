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
			/* var stuff = new Store();
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

			 Bank.BankFlyweight.Bank bank = Bank.BankFlyweight.BankFactory.GetBank("DnB");
			 Customer customer1 = new Customer(120893, "Ellen Elefsen");
			 bank.CreateAccount(customer1.GetSocialSecurityNumber());
			 Customer customer2 = new Customer(120194, "Kai Johnsen");
			 bank.CreateAccount(customer2.GetSocialSecurityNumber());
			 Customer customer3 = new Customer(230266, "Mats Toret");
			 bank.CreateAccount(customer3.GetSocialSecurityNumber());
			 */

			var backroom = new Backroom();
			Console.WriteLine(backroom.CreateProduct(10).GetDescription());
			Console.ReadKey();

        }
    }
}
