using System;
using System.Collections.Generic;
using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre.Bank.BankFlyweight {
	class Bank : IBank {
		public string Name { get; set; }
		public int Customers { get; set; }
		public int Capital { get; set; }
        private readonly Dictionary<int, BankAccount> _accounts = new Dictionary<int, BankAccount>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of bank</param>
		public Bank(string name) {
			Name = name;
		}

		/// <summary>
		/// Prints out information about the bank.
		/// </summary>
		public void PrintBankInformation() {
			Console.WriteLine("The bank {0} as {1} customers and a capital of {2} kr.", Name, Customers, Capital);
		}

        /// <summary>
        /// Creates a new account, if customer does not have one, and adds it to _accounts.
        /// </summary>
        /// <param name="customerId">Unique identifier for a customer.</param>
        /// <returns>Bool Returns true if account was created</returns>
        public bool CreateAccount(int customerId) {
			//Creates new account with random sum.    
			var sum = Client.Rnd.Next(100, 200);
			var newAccount = new BankAccount(sum);

			//Adds account to _account dictionary if customer hasn't an existing account.
			if(!_accounts.ContainsKey(customerId)) {
				_accounts.Add(customerId, newAccount);
				return true;
			}
//			Console.WriteLine("Customer already has an account.");
			return false;

		}

        /// <summary>
        /// Performs a withdrawal if customer has account and sufficient funds.
        /// </summary>
        /// <param name="sum">Sum to withdraw</param>
        /// <param name="customerId">Unique identifier for a customer.</param>
        /// <returns>Bool returns true if transaction was made</returns>
        public bool Transaction(double sum, int customerId) {
			if(_accounts.ContainsKey(customerId)) {
				BankAccount customerAccount = _accounts[customerId];
				var result = customerAccount.Withdrawal(sum);
				return result;
			}
			Console.WriteLine("Person does not have an account.");
			return false;
		}

        /// <summary>
        /// Prints out all accounts in _accounts.
        /// </summary>
        public void PrintAccounts() {
			foreach(KeyValuePair<int, BankAccount> pair in _accounts) {
				Console.WriteLine("Customer = {0}, Account = {1}", pair.Key, pair.Value);
			}
		}

        /// <summary>
        /// Returns current fund for a specifik bankaccount.
        /// </summary>
        /// <param name="customerId">Unique identifier for a customer.</param>
        /// <returns>Double Returns current fund of the bankaccount</returns>
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

	    /// <summary>
        /// Returns account
        /// </summary>
        /// <returns>Dictionary of int,BankAccount Returns dictionary with bankaccounts.</returns>
		public Dictionary<int, BankAccount> GetAccounts() {
			return _accounts;
		}

	}
}
