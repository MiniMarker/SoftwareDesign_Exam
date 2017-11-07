using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre {
	class Bank : IBank
	{
        private String _name { get; set; }
        private int _customers { get; set; }
	    private int _capital { get; set; }
        private Dictionary<int, BankAccount> _accounts = new Dictionary<int, BankAccount>();

        public Bank(String name)
        {
            this._name = name;
        }

        //Prints out information about the bank.
	    public void HandelingCustomer()
	    {
            Console.WriteLine("The bank {0} as {1} customers and a capital of {2} kr.", _name, _customers, _capital);
	    }

        //Sets customer value.
	    public void SetCustomers(int Customers)
	    {
	        this._customers = Customers;
	    }

	    //Sets capital value.
        public void SetCapital(int Capital)
	    {
	        this._capital = Capital;
	    }

	    //Creates a new account, if customer does not have one, and adds it to _accounts.
	    public bool CreateAccount(int CustomerId)
	    {
            //Creates new account with random sum.
	        Random random = new Random();
	        int Sum = random.Next(1,250);
            BankAccount NewAccount = new BankAccount(Sum);

            //Adds account to _account dictionary if customer hasn't an existing account.
	        if (!_accounts.ContainsKey(CustomerId))
	        {
	            _accounts.Add(CustomerId, NewAccount);
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
	    public bool Transaction(int Sum, int CustomerId)
	    {
	        if (_accounts.ContainsKey(CustomerId))
	        {
	            BankAccount CustomerAccount = _accounts[CustomerId];
	            bool result = CustomerAccount.Withdrawal(Sum);
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
	        foreach (KeyValuePair<int, BankAccount> Pair in _accounts)
	        {
	            Console.WriteLine("Customer = {0}, Account = {1}", Pair.Key, Pair.Value);
            }
        }

	}
}
