using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using Bazaar_Of_The_Bizarre.statueDecorator;

namespace Bazaar_Of_The_Bizarre.controller {
	class Customer
	{
	    public int SocialSecurityNumber { get; set; }
	    public string Name { get; set; }
	    public List<IStatue> ItemsPurchased { get; set;}
		private Bazaar _bazaar;

		//TODO remove this later
		private PrintHandler print = new PrintHandler();

		/// <summary>
		/// Constructor 
		/// </summary>
		/// <param name="socialSecurityNumber"></param>
		/// <param name="name"></param>
		/// <param name="bank"></param>
		public Customer(int socialSecurityNumber, string name, Bank.BankFlyweight.Bank bank, Bazaar bazaar)
		{
			Name = name;
			SocialSecurityNumber = socialSecurityNumber;
			ItemsPurchased = new List<IStatue>();
			bank.CreateAccount(SocialSecurityNumber);
			_bazaar = bazaar;

		}

		// Buys item if sufficient funds on bankaccount. Adds in _itemsPurchased.
	    public void BuyItem()
	    {
		    var productBought = _bazaar.GetProductFromStoreForCustomer(SocialSecurityNumber);

		    if(productBought != null) {
			    ItemsPurchased.Add(productBought);
			    Console.WriteLine(print.PrintStatueDesc(productBought.GetDescription()));
			    Console.WriteLine("");
		    }
                 
	    }


		//Prints out all the purchased items.

		//TODO Move this method when finished with other methods.
		public void GetItemsPurchased()
	    {
	        foreach(var item in ItemsPurchased)
	        {
		        Console.WriteLine(item.GetDescription());
	        }
		}
	}
}
