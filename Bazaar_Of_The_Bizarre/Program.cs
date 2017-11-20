using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using Bazaar_Of_The_Bizarre.controller;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade;

namespace Bazaar_Of_The_Bizarre {
	class Program {
		public static void Main(string[] args) {


			/*
			var cust1 = new Customer(123,"Henrik", bank, );
			var cust2 = new Customer(124,"Emma", bank);
			var cust3 = new Customer(125,"Christian", bank);
			var cust4 = new Customer(126,"Bosse", bank);
*/

			var client = new Client(20);
        
		    var bazarOpen = true;
		    while (bazarOpen)
		    {
		        client.StartAllCustomerThreads();
		        client.StartAllStoresThreads();
		        bazarOpen = client.IsBazarClosed();
		    }
            Console.WriteLine("This is closed");


		    /*

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
            */

			Console.ReadKey();

		}
	}
}
