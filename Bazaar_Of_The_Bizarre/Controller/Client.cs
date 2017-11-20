using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre.controller {
	class Client {

		private readonly Bank.BankFlyweight.Bank _bank;
		private Bazaar _bazaar;
		private Customer[] _customers;
		private Thread[] _customerThreads;

		public Client(int amountOfCustomers) {
			_bank = BankFactory.GetBank("DNB");
			_bazaar = new Bazaar();

			_customers = new Customer[amountOfCustomers];
			_customerThreads = new Thread[amountOfCustomers];
		}

		/**
		 * App has to run threads until customer has less money than x
		 * App has to run threads until stores are no longer open.  
		 */
		public void StartAllCustomerThreads() {

			CreateAllCustomers();
			CreateAllCustomerThreads();

			foreach (var customerThread in _customerThreads)
			{
				customerThread.Start();
			}
		}

		private void CreateAllCustomers()
		{
			var socialSecurityNumber = 120;

			for(var i = 0; i < _customers.Length; i++) {
				_customers[i] = new Customer(socialSecurityNumber++, "Kunde" + i, _bank, _bazaar);
			}
		}

		private void CreateAllCustomerThreads()
		{
			for(var i = 0; i < _customerThreads.Length; i++) {
				var customer = _customers[i];
				var thread = new Thread(customer.BuyItem);
				_customerThreads[i] = thread;
			}
		}




	}
}
