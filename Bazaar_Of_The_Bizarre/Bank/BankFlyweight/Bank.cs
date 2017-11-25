using System;
using System.Collections.Generic;
using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre.Bank.BankFlyweight {
	class Bank : IBank {
		public string Name { get; set; }
		public int Customers { get; set; }
		public int Capital { get; set; }
		private readonly Dictionary<int, BankAccount> _accounts = new Dictionary<int, BankAccount>();

		public Bank(string name) {
			Name = name;
		}

		/// <summary>
		/// Prints out information about the bank.
		/// </summary>
		//Shows information about bank.
		public void PrintBankInformation() {
			Console.WriteLine("The bank {0} as {1} customers and a capital of {2} kr.", Name, Customers, Capital);
		}

		//Creates a new account, if customer does not have one, and adds it to _accounts.
		public bool CreateAccount(int customerId) {
			//Creates new account with random sum.    
			var sum = Client.Rnd.Next(1, 250);
			var newAccount = new BankAccount(sum);

			//Adds account to _account dictionary if customer hasn't an existing account.
			if(!_accounts.ContainsKey(customerId)) {
				_accounts.Add(customerId, newAccount);
				//Console.WriteLine("Account has been added.");
				return true;
			}
			Console.WriteLine("Customer already has an account.");
			return false;

		}

		//Performs a withdrawal if customer has account and sufficient funds.
		public bool Transaction(double sum, int customerId) {
			if(_accounts.ContainsKey(customerId)) {
				BankAccount customerAccount = _accounts[customerId];
				var result = customerAccount.Withdrawal(sum);
				return result;
			}
			Console.WriteLine("Person does not have an account.");
			return false;
		}

		//Prints out all accounts in _accounts.
		public void PrintAccounts() {
			foreach(KeyValuePair<int, BankAccount> pair in _accounts) {
				Console.WriteLine("Customer = {0}, Account = {1}", pair.Key, pair.Value);
			}
		}

        //Returns current fund for a specifik bankaccount.
	    public double CheckFunds(int customerId)
	    {
	        if (_accounts.ContainsKey(customerId))
	        {
	            BankAccount customerAccount = _accounts[customerId];
	            var result = customerAccount.GetSum();
	            return result;
	        }
	        return 0;
	    }

	    //Returns accounts.
		public Dictionary<int, BankAccount> GetAccounts() {
			return _accounts;
		}

	}
}
