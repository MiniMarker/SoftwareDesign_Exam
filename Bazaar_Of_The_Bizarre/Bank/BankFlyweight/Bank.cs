using System;
using System.Collections.Generic;

namespace Bazaar_Of_The_Bizarre.Bank.BankFlyweight {
	class Bank : IBank
	{
        public string Name { get; set; }
        public int Customers { get; set; }
	    public int Capital { get; set; }
		private Random _random;
		private readonly Dictionary<int, BankAccount> _accounts = new Dictionary<int, BankAccount>();

        public Bank(string name)
        {
	        Name = name;
			_random = new Random();

        }

		/// <summary>
		/// Prints out information about the bank.
		/// </summary>
		public void HandelingCustomer()
	    {
            Console.WriteLine("The bank {0} as {1} customers and a capital of {2} kr.", Name, Customers, Capital);
	    }

	    //Creates a new account, if customer does not have one, and adds it to _accounts.
	    public bool CreateAccount(int CustomerId)
	    {
            //Creates new account with random sum.
	        
	        int sum = _random.Next(1,250);
            BankAccount newAccount = new BankAccount(sum);

            //Adds account to _account dictionary if customer hasn't an existing account.
	        if (!_accounts.ContainsKey(CustomerId))
	        {
	            _accounts.Add(CustomerId, newAccount);
                Console.WriteLine("Account has been added.");
	            return true;
	        }
	        else
	        {
	            Console.WriteLine("Customer already has an account.");
                return false;
	        }
	    }
  
        //Performs a withdrawal if customer has account and sufficient funds.
	    public bool Transaction(double sum, int customerId)
	    {
	        if (_accounts.ContainsKey(customerId))
	        {
	            BankAccount customerAccount = _accounts[customerId];
	            bool result = customerAccount.Withdrawal(sum);
				Console.WriteLine(customerId);
	            return result;
	        }
	        else
	        {
                Console.WriteLine("Person does not have an account.");
	            return false;
	        }
	    }

        //Prints out all accounts in _accounts.
	    public void PrintAccounts()
	    {
	        foreach (KeyValuePair<int, BankAccount> pair in _accounts)
	        {
	            Console.WriteLine("Customer = {0}, Account = {1}", pair.Key, pair.Value);
            }
        }

		public Dictionary<int, BankAccount> getAccounts()
		{
			return _accounts;
		}

	}
}
