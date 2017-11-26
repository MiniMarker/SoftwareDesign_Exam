
using System;
using System.Collections.Generic;
using System.Threading;
using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre.Controller {
	class ThreadHandler {
		public Customer[] Customers { get; private set; }
		public Thread[] CustomerThreads { get; private set; }
		public Thread[] StoreThreads { get; private set; }

		private static int _socialSecurityNumber;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="amountOfCustomers"></param>
		public ThreadHandler(int amountOfCustomers) {
			Customers = new Customer[amountOfCustomers];
			CustomerThreads = new Thread[amountOfCustomers];
			StoreThreads = new Thread[4];
			_socialSecurityNumber = 120;
		}

		/// <summary>
		/// Starts all Customer Threads
		/// </summary>
		/// <param name="bank"></param>
		/// <param name="bazaar"></param>
		public void StartAllCustomerThreads(Bank.BankFlyweight.Bank bank, Bazaar bazaar) {
			CreateAllCustomers(bank, bazaar);
			CreateAllCustomerThreads();

			foreach(var customerThread in CustomerThreads) {
				customerThread.Start();
			}
		}

		/// <summary>
		/// Starts all store threads
		/// </summary>
		/// <param name="bazaar"></param>
		public void StartAllStoresThreads(Bazaar bazaar) {
			CreateAllStoresThreads(bazaar);
			foreach(var storeThread in StoreThreads) {
				storeThread.Start();
			}
		}

		/// <summary>
		/// Creates All Customers
		/// </summary>
		/// <param name="bank"></param>
		/// <param name="bazaar"></param>
		private void CreateAllCustomers(Bank.BankFlyweight.Bank bank, Bazaar bazaar) {
			List<String> nameList = new List<string>();

			for(var i = 0; i < Customers.Length; i++) {
				Customers[i] = AddCustomerToList(nameList, bank, bazaar);
			}
		}

		/// <summary>
		/// This method is to avoid deadlock in the sense that stores have products to sell but customer does not have any money. Creates four customer and threads. Start thread after x milliseconds.
		/// </summary>
		/// <param name="bank"></param>
		/// <param name="bazaar"></param>
		public void GenerateExtraCustomers(Bank.BankFlyweight.Bank bank, Bazaar bazaar) {
			Thread[] extraCostumerThreads = new Thread[5];
			var custom = new Customer(115, "John", bank, bazaar);
			var custom1 = new Customer(116, "Hans", bank, bazaar);
			var custom2 = new Customer(117, "Leila", bank, bazaar);
			var custom3 = new Customer(118, "Tina", bank, bazaar);
			var custom4 = new Customer(119, "Ringo", bank, bazaar);
			var customerList = new List<Customer>();
			customerList.Add(custom);
			customerList.Add(custom1);
			customerList.Add(custom2);
			customerList.Add(custom3);
			customerList.Add(custom4);

			for(var i = 0; i < customerList.Count; i++) {
				var customer = customerList[i];
				var thread = new Thread(customer.BuyItem);
				extraCostumerThreads[i] = thread;
			}

			foreach(var customerThread in extraCostumerThreads) {
				customerThread.Start();
				Thread.Sleep(200);
			}

		}

		/// <summary>
		/// Adds a customer to the list and returns it
		/// </summary>
		/// <param name="bank"></param>
		/// <param name="bazaar"></param>
		/// <returns>Customer Returns a customer if created successfully</returns>
		private Customer AddCustomerToList(List<String> nameList, Bank.BankFlyweight.Bank bank, Bazaar bazaar) {
			var values = Enum.GetValues(typeof(Names));
			var customerName = values.GetValue(Client.Rnd.Next(0, values.Length));
			var nameIsTaken = false;
			while(!nameIsTaken) {
				if(nameList.Count != 0) {

					foreach(var name in nameList) {
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
					nameList.Add(customerName.ToString());
					return new Customer(_socialSecurityNumber++, customerName.ToString(), bank, bazaar);
				}
			}
			return null;
		}

		/// <summary>
		/// Creates all customer threads
		/// </summary>
		private void CreateAllCustomerThreads() {
			for(var i = 0; i < CustomerThreads.Length; i++) {
				var customer = Customers[i];
				var thread = new Thread(customer.BuyItem);
				CustomerThreads[i] = thread;
			}
		}

		/// <summary>
		/// Creates all store threads
		/// </summary>
		/// <param name="bazaar"></param>
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
		/// Checks if there is any thread running
		/// </summary>
		/// <returns>Boolean Returns true if there is a running thread.</returns>
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