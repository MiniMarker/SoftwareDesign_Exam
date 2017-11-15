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

	    public Customer(int socialSecurityNumber, string name)
	    {
            Name = name;
	        SocialSecurityNumber = socialSecurityNumber;
            ItemsPurchased = new List<IStatue>();
            //bank.CreateAccount(SocialSecurityNumber); Banken upprättat konto efter personen har upprättas i client.
        }

		// Buys item if sufficient funds on bankaccount. Adds in _itemsPurchased.
	    private void BuyItem(Bazaar bazaar)
	    {
		    IStatue productBought = null;

			productBought = bazaar.GetProductFromStoreForCustomer(SocialSecurityNumber);

		    if (productBought != null)
		    {
			    ItemsPurchased.Add(productBought);
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
