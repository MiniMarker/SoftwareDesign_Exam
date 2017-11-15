using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using Bazaar_Of_The_Bizarre.controller;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade;

namespace Bazaar_Of_The_Bizarre {
	class Program {
		public static void Main(string[] args) {
			Console.WriteLine("****");
			var backroom = new Backroom();
			backroom.CreateMultipleStatues(5);
			var bank = BankFactory.GetBank("DNB");
			Console.WriteLine("----");
			var bazaar = new Bazaar();
			var cust1 = new Customer(123,"Henrik", bank);
			var cust2 = new Customer(124,"Emma", bank);
			var cust3 = new Customer(125,"Christian", bank);
			var cust4 = new Customer(126,"Bosse", bank);
			Console.WriteLine("###");
			cust1.BuyItem(bazaar);
			cust1.BuyItem(bazaar);
			cust2.BuyItem(bazaar);
			cust2.BuyItem(bazaar);
			cust3.BuyItem(bazaar);
			cust3.BuyItem(bazaar);
			cust3.BuyItem(bazaar);
			cust4.BuyItem(bazaar);
			cust4.BuyItem(bazaar);
			cust4.BuyItem(bazaar);
			cust4.BuyItem(bazaar);

			cust1.GetItemsPurchased();
			cust2.GetItemsPurchased();
			cust3.GetItemsPurchased();
			cust4.GetItemsPurchased();

			Console.ReadKey();

		}
	}
}
