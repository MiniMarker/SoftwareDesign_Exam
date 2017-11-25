using System;
using System.Collections.Generic;
using System.Threading;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using Bazaar_Of_The_Bizarre.controller;
using Bazaar_Of_The_Bizarre.Controller;

namespace Bazaar_Of_The_Bizarre.controller {
	class Client {
		public static readonly Random Rnd = new Random();
        private readonly Bank.BankFlyweight.Bank _bank;
		public Bazaar Bazaar;
	    public static readonly PrintHandler PrintProduct = PrintHandler.GetInstance();
        private Customer[] _customers;
		private Thread[] _customerThreads;
		private Thread[] _storeThreads;
		private static int _socialSecurityNumber;

		public Client(int amountOfCustomers) {
			_bank = BankFactory.GetBank("DNB");
			Bazaar = new Bazaar();
			_socialSecurityNumber = 120;
			_customers = new Customer[amountOfCustomers];
			_customerThreads = new Thread[amountOfCustomers];
			_storeThreads = new Thread[4];
		}

		/**
		 * App has to run threads until customer has less money than x
		 * App has to run threads until stores are no longer open.  
		 */
		public void StartAllCustomerThreads() {

			CreateAllCustomers();
			CreateAllCustomerThreads();

			foreach(var customerThread in _customerThreads) {
				customerThread.Start();
			}
		}


		private void CreateAllCustomers() {
			for(var i = 0; i < _customers.Length; i++) {
				_customers[i] = AddCustomerToList();
				Console.WriteLine("Name " + _customers[i].Name + " ; SocialSecurityNumber: " + _customers[i].SocialSecurityNumber);
			}
		}

		private Customer AddCustomerToList() {
			var values = Enum.GetValues(typeof(Names));
			var customerName = values.GetValue(Rnd.Next(0, values.Length));
			var nameIsTaken = false;
			while(!nameIsTaken) {
				if(_customers.Length == 0) {

					foreach(var customer in _customers) {
						if(customer.Name.Equals(customerName.ToString())) {
							nameIsTaken = true;
						}
					}
				}
				if(nameIsTaken) {
					customerName = values.GetValue(Rnd.Next(values.Length));
					nameIsTaken = false;
				}
				else {

					return new Customer(_socialSecurityNumber++, customerName.ToString(), _bank, Bazaar);
				}
			}
			return null;
		}

		private void CreateAllCustomerThreads() {
			for(var i = 0; i < _customerThreads.Length; i++) {
				var customer = _customers[i];
				var thread = new Thread(customer.BuyItem);
				_customerThreads[i] = thread;
			}
		}

		private void CreateAllStoresThreads() {
			var storesList = Bazaar.GetStoreList();

			var i = 0;
			foreach(var store in storesList) {
				var thread = new Thread(store.FillProducts);
				_storeThreads[i] = thread;
				++i;
			}
		}

		public void StartAllStoresThreads() {
			CreateAllStoresThreads();
			foreach(var storeThread in _storeThreads) {
				storeThread.Start();
			}
		}

		public bool AnyThreadRunning() {
			bool threadIsRunning = false;
			foreach(var customerThread in _customerThreads) {
				if(customerThread.IsAlive) {
					threadIsRunning = true;
				}
			}
			return threadIsRunning;
		}

		//Checks if the bazar should be closed.
		public bool IsBazarClosed() {
			var result = Bazaar.IsBazarOpen();
			return result;
		}

		//Prints out all sold of the day by stores.
		public void EndOfDay() {
			foreach(var store in Bazaar.GetStoreList()) {
				store.ViewSoldProducts();
			}
		}
	}
}
