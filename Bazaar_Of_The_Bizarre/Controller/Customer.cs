using System;
using System.Collections.Generic;
using Bazaar_Of_The_Bizarre.statueDecorator;

namespace Bazaar_Of_The_Bizarre.controller {
	class Customer
	{
	    public int SocialSecurityNumber { get; set; }
	    public string Name { get; set; }
	    public List<IStatue> ItemsPurchased { get; set;}
		private Bazaar _bazaar;
	    private Bank.BankFlyweight.Bank _bank;

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
			_bank.CreateAccount(SocialSecurityNumber);
		    _bank = bank;
			_bazaar = bazaar;
		}

        // Buys item if sufficient funds on bankaccount. Adds in _itemsPurchased.
        public void BuyItem()
        {
            var productBought = _bazaar.GetProductFromStoreForCustomer(SocialSecurityNumber, Name);
            if (productBought != null)
            {
                ItemsPurchased.Add(productBought);
            }
        }

	    //Prints out all the purchased items.
        public void GetItemsPurchased()
	    {
	        foreach(var item in ItemsPurchased)
	        {
		        Console.WriteLine(item.GetDescription());
	        }
		}

        //Checks funds in bankaccount.
	    public bool FundInBank()
	    {
	       var funds = _bank.CheckFunds(SocialSecurityNumber)

	        if(funds > 19)
	        {
	            return true;
	        }
	        else
	        {
	            return false;
	        }
	    }
	}
}
