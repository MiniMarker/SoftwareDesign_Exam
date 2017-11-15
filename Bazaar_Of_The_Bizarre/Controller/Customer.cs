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
	    private void BuyItem(Bazaar bazaar)
	    {
		    IStatue productPurchased = null;
			//Rule -> Hvis ingen varer igjen; slutt å lete etter varer. 
			productPurchased = bazaar.GetProductFromStoreForCustomer(SocialSecurityNumber);

		    if (productPurchased != null)
		    {
			    ItemsPurchased.Add(productPurchased);
		    }
	    }

        //Prints out all the purchased items.
	    private void GetItemsPurchased()
	    {
	        foreach(IStatue Item in ItemsPurchased)
	        {
	            Console.WriteLine(Item.ToString());
	        }

	    }

	}
}
