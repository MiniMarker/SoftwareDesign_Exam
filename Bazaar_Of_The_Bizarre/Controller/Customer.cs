using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;

namespace Bazaar_Of_The_Bizarre.controller {
	class Customer
	{
	    public int SocialSecurityNumber { get; set; }
	    public string Name { get; set; }
	    public List<IStatue> ItemsPurchased { get; set;}

		/// <summary>
		/// Constructor 
		/// </summary>
		/// <param name="socialSecurityNumber"></param>
		/// <param name="name"></param>
		/// <param name="bank"></param>
		public Customer(int socialSecurityNumber, string name, Bank.BankFlyweight.Bank bank)
		{
			Name = name;
			SocialSecurityNumber = socialSecurityNumber;
			ItemsPurchased = new List<IStatue>();
			bank.CreateAccount(SocialSecurityNumber);
		}

		// Buys item if sufficient funds on bankaccount. Adds in _itemsPurchased.
	    public void BuyItem(Bazaar bazaar)
	    {
		    var productBought = bazaar.GetProductFromStoreForCustomer(SocialSecurityNumber);

		    if(productBought != null) {
			    ItemsPurchased.Add(productBought);
		    }
		}

        //Prints out all the purchased items.

			//TODO Move this method when finished with other methods.
	    public void GetItemsPurchased()
	    {
	        foreach(var item in ItemsPurchased)
	        {
	            Console.WriteLine(item.ToString());
	        }

	    }

	}
}
