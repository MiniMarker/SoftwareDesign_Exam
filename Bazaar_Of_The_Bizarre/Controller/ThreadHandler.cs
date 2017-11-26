
using System;
using System.Collections.Generic;
using System.Threading;
using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre.Controller {
	class ThreadHandler {
		public Thread[] StoreThreads { get; private set; }

		public List<Customer> Customers { get; private set; }
		public List<Thread> CustomerThreads { get; private set; }
		public int AmountOfCustomers { get; private set; }

		private static int _socialSecurityNumber;
		private readonly List<string> _nameList = new List<string>();

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="amountOfCustomers"></param>
		public ThreadHandler(int amountOfCustomers) {
			AmountOfCustomers = amountOfCustomers;
			Customers = new List<Customer>();
			CustomerThreads = new List<Thread>();
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
			AddThreadsForAllCustomers();
			StartAllCustomerThreads();
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

			for(var i = 0; i < AmountOfCustomers - 1; i++) {
				Customers.Add(AddCustomerToList(bank, bazaar));
			}
		}

		/// <summary>
		/// This method is to avoid deadlock in the sense that stores have products to 
		/// sell but customer does not have any money. Creates four customer and threads. 
		/// Start thread after 200 milliseconds.
		/// </summary>
		/// <param name="bank"></param>
		/// <param name="bazaar"></param>
		public void GenerateExtraCustomers(Bank.BankFlyweight.Bank bank, Bazaar bazaar)
		{
			var extraCostumerThreads = new List<Thread>();

			for(var i = 0; i < 5; i++) {
				AddCustomerToList(bank, bazaar);
			}

			for(var i = Customers.Count - 5; i < Customers.Count; i++) {
				var thread = new Thread(Customers[i].BuyItem);
				extraCostumerThreads.Add(thread);
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
		private Customer AddCustomerToList(Bank.BankFlyweight.Bank bank, Bazaar bazaar) {
			var values = Enum.GetValues(typeof(Names));
			var customerName = values.GetValue(Client.Rnd.Next(0, values.Length));
			var nameIsTaken = false;
			while(!nameIsTaken) {
				if(_nameList.Count != 0) {

					foreach(var name in _nameList) {
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
					_nameList.Add(customerName.ToString());
					return new Customer(_socialSecurityNumber++, customerName.ToString(), bank, bazaar);
				}
			}
			return null;
		}

		/// <summary>
		/// Creates all customer threads
		/// </summary>
		private void CreateAllCustomerThreads() {
			for(var i = 0; i < AmountOfCustomers - 1; i++) {
				var customer = Customers[i];
				var thread = new Thread(customer.BuyItem);
				CustomerThreads.Add(thread);
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
		/// adds threads for all customers
		/// </summary>
		private void AddThreadsForAllCustomers() {
			foreach(var customer in Customers) {
				var thread = new Thread(customer.BuyItem);
				CustomerThreads.Add(thread);
			}
		}

		/// <summary>
		/// Starts all threads for customers
		/// </summary>
		private void StartAllCustomerThreads() {
			foreach(var customerThread in CustomerThreads) {
				if((customerThread.ThreadState & ThreadState.Unstarted) != 0) {
					customerThread.Start();
				}
			}
		}
	}
}