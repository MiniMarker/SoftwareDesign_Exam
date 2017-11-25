
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;
using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre.Controller {
	class ThreadHandler {
		//		public Customer[] Customers { get; private set; }
		//		public Thread[] CustomerThreads { get; private set; }
		public Thread[] StoreThreads { get; private set; }

		public List<Customer> Customers { get; private set; }
		public List<Thread> CustomerThreads { get; private set; }
		private int AmountOfCustomers { get; set; }

		private static int _socialSecurityNumber;
		public List<string> NameList = new List<string>();

		/// <summary>
		///		Constructor
		/// </summary>
		/// <param name="amountOfCustomers">
		///		Amount of customers to be created
		/// </param>
		public ThreadHandler(int amountOfCustomers) {
			//			Customers = new Customer[amountOfCustomers];
			//			CustomerThreads = new Thread[amountOfCustomers];
			AmountOfCustomers = amountOfCustomers;
			Customers = new List<Customer>();
			CustomerThreads = new List<Thread>();
			StoreThreads = new Thread[4];
			_socialSecurityNumber = 120;
		}

		/// <summary>
		///		Starts all Customer Threads
		/// </summary>
		/// <param name="bank">
		///		object of bank to be set
		/// </param>
		/// <param name="bazaar">
		///		object of Bazaar to be used
		/// </param>
		public void StartAllCustomerThreads(Bank.BankFlyweight.Bank bank, Bazaar bazaar) {
			CreateAllCustomers(bank, bazaar);
			CreateAllCustomerThreads();

			foreach(var customerThread in CustomerThreads) {
				customerThread.Start();
			}
		}

		/// <summary>
		///		Starts all store threads
		/// </summary>
		/// <param name="bazaar">
		///		object of Bazaar to be used
		/// </param>
		public void StartAllStoresThreads(Bazaar bazaar) {
			CreateAllStoresThreads(bazaar);
			foreach(var storeThread in StoreThreads) {
				storeThread.Start();
			}
		}

		/// <summary>
		///		Creates All Customers
		/// </summary>
		/// <param name="bank">
		///		object of Bank to be used
		/// </param>
		/// <param name="bazaar">
		///		object of Bazaar to be used
		/// </param>
		private void CreateAllCustomers(Bank.BankFlyweight.Bank bank, Bazaar bazaar) {

			for(var i = 0; i < AmountOfCustomers - 1; i++) {
				Customers.Add(AddCustomerToList(bank, bazaar));
			}
		}

		/// <summary>
		///		This method is to avoid deadlock in the sense that stores have products to sell but customer does not have any money. 
		///		Creates four customer and threads. Start thread after x milliseconds.
		/// </summary>
		/// <param name="bank">
		///		object of Bank to be used
		/// </param>
		/// <param name="bazaar">
		///		object of Bazaar to be used
		/// </param>
		public void GenerateExtraCustomerIfNeeded(Bank.BankFlyweight.Bank bank, Bazaar bazaar) {
			Customers.Add(AddCustomerToList(bank, bazaar));
			var backupThreads = new List<Thread>();

			foreach(var customer in Customers) {
				var thread = new Thread(customer.BuyItem);
				backupThreads.Add(thread);
			}

			foreach(var customerThread in backupThreads) {
				customerThread.Start();

			}
		}

		/// <summary>
		///		Adds a customer to the list and returns it.
		///		The name is unique for each customer to be made.
		///		If a name is used by another customer, choose a new one from Enum
		/// </summary>

		///	<param name="bank">
		///		Object of Bank to be used by the Customer
		/// </param>
		/// <param name="bazaar">
		///		Object of Bazaar to be used by the Customer
		/// </param>
		/// <returns>
		///		Customer Returns a customer if created successfully
		/// </returns>
		private Customer AddCustomerToList(Bank.BankFlyweight.Bank bank, Bazaar bazaar) {
			var values = Enum.GetValues(typeof(Names));
			var customerName = values.GetValue(Client.Rnd.Next(0, values.Length));
			var nameIsTaken = false;
			while(!nameIsTaken) {
				if(NameList.Count != 0) {
					foreach(var name in NameList) {
						if(name.Equals(customerName.ToString())) {
							nameIsTaken = true;
						}
					}
				}
				if(nameIsTaken) {
					customerName = values.GetValue(Client.Rnd.Next(values.Length));
					nameIsTaken = false;
				}
				else {
					NameList.Add(customerName.ToString());
					return new Customer(_socialSecurityNumber++, customerName.ToString(), bank, bazaar);
				}
			}
			return null;
		}

		/// <summary>
		///		Creates all customer threads
		/// </summary>
		private void CreateAllCustomerThreads() {
			for(var i = 0; i < AmountOfCustomers - 1; i++) {
				var customer = Customers[i];
				var thread = new Thread(customer.BuyItem);
				CustomerThreads.Add(thread);
			}
		}

		/// <summary>
		///		Creates all store threads
		/// </summary>
		/// <param name="bazaar">
		///		Object of Bazaar to be used
		/// </param>
		private void CreateAllStoresThreads(Bazaar bazaar) {
			var storesList = bazaar.ListOfAllStores;

			var i = 0;
			foreach(var store in storesList) {
				var thread = new Thread(store.FillProducts);
				StoreThreads[i] = thread;
				++i;
			}
		}

		/// <summary>
		///		Checks if there is any thread running
		/// </summary>
		/// <returns>
		///		Boolean Returns true if there is a running thread.
		///	</returns>
		public bool AnyThreadRunning() {
			bool threadIsRunning = false;
			foreach(var customerThread in CustomerThreads) {
				if(customerThread.IsAlive) {
					threadIsRunning = true;
				}
			}
			return threadIsRunning;
		}
	}
}
