using System;
using System.Collections.Generic;
using System.Threading;
using Bazaar_Of_The_Bizarre.Controller;
using Bazaar_Of_The_Bizarre.statueDecorator;

namespace Bazaar_Of_The_Bizarre.controller {
	class Customer {
		public int SocialSecurityNumber { get; set; }
		public string Name { get; set; }
		public List<IStatue> ItemsPurchased { get; set; }
		private Bazaar _bazaar;
		private Bank.BankFlyweight.Bank _bank;

		/// <summary>
		/// Constructor 
		/// </summary>
		/// <param name="socialSecurityNumber"></param>
		/// <param name="name"></param>
		/// <param name="bank"></param>
		/// <param name="bazaar"></param>
		public Customer(int socialSecurityNumber, string name, Bank.BankFlyweight.Bank bank, Bazaar bazaar) {
			Name = name;
			SocialSecurityNumber = socialSecurityNumber;
			ItemsPurchased = new List<IStatue>();
			_bazaar = bazaar;
			_bank = bank;
			_bank.CreateAccount(SocialSecurityNumber);
		}

		/// <summary>
		/// Buys item if sufficient funds on bankaccount. Adds in _itemsPurchased.
		/// </summary>
		public void BuyItem() {
			while(CheckIfEnoughFunds()) {
				var productBought = _bazaar.GetProductFromStoreForCustomer(SocialSecurityNumber, Name);
				if(productBought != null) {
					ItemsPurchased.Add(productBought);
					Thread.Sleep(1000);
				}
				else {
					Thread.CurrentThread.Join();
				}
			}
		}

		/// <summary>
		/// Prints out all the purchased items.
		/// </summary>
		public void GetItemsPurchased() {
			foreach(var item in ItemsPurchased) {
				Console.WriteLine(item.GetDescription());
			}
		}

		/// <summary>
		/// Checks funds in bankaccount.
		/// </summary>
		/// <returns>Bool Returns true if customer has any funds available.</returns>
		public bool CheckIfEnoughFunds() {
			var funds = _bank.CheckFunds(SocialSecurityNumber);
			if(funds > 30) {
				return true;
			}
			return false;

		}
	}
}
