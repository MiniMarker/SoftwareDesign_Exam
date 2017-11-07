using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre {
	class Customer
	{
	    private int _SocialSecurityNumber { get; set; }
	    private String _name { get; set; }
	    private List<String> _itemsPurchased { get; set;}

	    public Customer(int SocialSecurityNumber, String name)
	    {
            this._name = name;
	        this._SocialSecurityNumber = SocialSecurityNumber;
            this._itemsPurchased = new List<string>();
            //bank.CreateAccount(SocialSecurityNumber); Banken upprättat konto efter personen har upprättas i client.
        }

	    private void ChooseStore(String Store)
	    {

	    }

	    private void BuyItem()
	    {


	    }

        //Prints out all the purchased items.
	    private void GetItemsPurchased()
	    {
	        foreach(String Item in _itemsPurchased)
	        {
	            Console.WriteLine(Item);
	        }

	    }

	}
}
