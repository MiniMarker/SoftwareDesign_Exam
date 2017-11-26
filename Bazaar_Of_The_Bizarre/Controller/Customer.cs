using System;
using System.Collections.Generic;
using System.Threading;
using Bazaar_Of_The_Bizarre.statueDecorator;

namespace Bazaar_Of_The_Bizarre.controller {
	class Customer {
		public int SocialSecurityNumber { get; set; }
		public string Name { get; set; }
		public List<string> ItemsPurchased { get; set; }
		private readonly Bazaar _bazaar;
		private readonly Bank.BankFlyweight.Bank _bank;

		/// <summary>
		///		Constructor 
		/// </summary>
		/// <param name="socialSecurityNumber">
		///     Unique Identifier for customer
		/// </param>
		/// <param name="name">
		///     Name of customer to be created
		/// </param>
		/// <param name="bank">
		///     Object of bank to be used
		/// </param>
		/// <param name="bazaar">
		///     Object of Bazaar to b used
		/// </param>
		public Customer(int socialSecurityNumber, string name, Bank.BankFlyweight.Bank bank, Bazaar bazaar) {
			Name = name;
			SocialSecurityNumber = socialSecurityNumber;
			ItemsPurchased = new List<string>();
			_bazaar = bazaar;
			_bank = bank;
			_bank.CreateAccount(SocialSecurityNumber);
		}

		/// <summary>
		///     Buys item if sufficient funds on bankaccount. Adds in ItemsPurchased.
		/// </summary>
		public void BuyItem() {
			while(CheckIfEnoughFunds()) {
				var productBought = _bazaar.GetProductFromStoreForCustomer(SocialSecurityNumber, Name);
				if(productBought != null) {
					ItemsPurchased.Add(productBought.GetDescription());
					Thread.Sleep(1000);
				}
				else {
					Thread.CurrentThread.Join();
				}
			}
		}

		/// <summary>
		///     Prints out all the purchased items.
		/// </summary>
		public void GetItemsPurchased() {
			foreach(var item in ItemsPurchased) {
				Console.WriteLine(item);
			}
		}

		/// <summary>
		///     Checks funds in bankaccount.
		/// </summary>
		/// <returns>
		///     Bool Returns true if customer has any funds available.
		/// </returns>
		public bool CheckIfEnoughFunds() {
			var funds = _bank.CheckFunds(SocialSecurityNumber);
			return funds > 30;
		}
	}
}
