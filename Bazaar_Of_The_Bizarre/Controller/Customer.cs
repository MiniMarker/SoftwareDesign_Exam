using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;

namespace Bazaar_Of_The_Bizarre.controller {
	class Customer
	{
	    private int _SocialSecurityNumber { get; set; }
	    private String _name { get; set; }
	    private List<IStatue> _itemsPurchased { get; set;}

	    public Customer(int SocialSecurityNumber, String name)
	    {
            this._name = name;
	        this._SocialSecurityNumber = SocialSecurityNumber;
            this._itemsPurchased = new List<IStatue>();
            //bank.CreateAccount(SocialSecurityNumber); Banken upprättat konto efter personen har upprättas i client.
        }

		// Buys item if sufficient funds on bankaccount. Adds in _itemsPurchased.
	    private void BuyItem(Bazaar bazaar)
	    {
		    IStatue productBought = null;

			productBought = bazaar.GetProductFromStoreForCustomer(_SocialSecurityNumber);

		    if (productBought != null)
		    {
			    _itemsPurchased.Add(productBought);
		    }
	    }

        //Prints out all the purchased items.
	    private void GetItemsPurchased()
	    {
	        foreach(IStatue Item in _itemsPurchased)
	        {
	            Console.WriteLine(Item.ToString());
	        }

	    }

	}
}
