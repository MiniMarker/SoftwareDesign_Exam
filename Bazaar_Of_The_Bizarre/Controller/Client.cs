using System;
using System.Collections.Generic;
using System.Threading;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using Bazaar_Of_The_Bizarre.controller;
using Bazaar_Of_The_Bizarre.Controller;

namespace Bazaar_Of_The_Bizarre.controller
{
	class Client
	{
		public static readonly Random Rnd = new Random();
		private readonly Bank.BankFlyweight.Bank _bank;
		public Bazaar Bazaar;
		private Customer[] _customers;
		private Thread[] _customerThreads;
		private Thread[] _storeThreads;
		private static int _socialSecurityNumber;

		public Client(int amountOfCustomers)
		{
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
		public void StartAllCustomerThreads()
		{

			CreateAllCustomers();
			CreateAllCustomerThreads();

			foreach (var customerThread in _customerThreads)
			{
				customerThread.Start();
			}
		}


		private void CreateAllCustomers()
		{
			List<string> nameList = new List<string>();

			for (var i = 0; i < _customers.Length; i++)
			{
				_customers[i]  = AddCustomerToList(nameList);
			}
		}

		private Customer AddCustomerToList(List<string> nameList)
		{
			var values = Enum.GetValues(typeof(Names));
			var customerName = values.GetValue(Rnd.Next(0, values.Length));
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
					customerName = values.GetValue(Rnd.Next(values.Length));
					nameIsTaken = false;
				}
				else {
					nameList.Add(customerName.ToString());
					return new Customer(_socialSecurityNumber++, customerName.ToString(), _bank, Bazaar);
				}
			}
			return null;
		}

		private void CreateAllCustomerThreads()
		{
			for (var i = 0; i < _customerThreads.Length; i++)
			{
				var customer = _customers[i];
				var thread = new Thread(customer.BuyItem);
				_customerThreads[i] = thread;
			}
		}

		private void CreateAllStoresThreads()
		{
			var storesList = Bazaar.GetStoreList();

			var i = 0;
			foreach (var store in storesList)
			{
				var thread = new Thread(store.FillProducts);
				_storeThreads[i] = thread;
				++i;
			}
		}

		public void StartAllStoresThreads()
		{
			CreateAllStoresThreads();
			foreach (var storeThread in _storeThreads)
			{
				storeThread.Start();
			}
		}

		//Checks if the bazar should be closed.
		public bool IsBazarClosed()
		{
			var result = Bazaar.IsBazarOpen();
			return result;
		}

		//Prints out all sold of the day by stores.
		public void EndOfDay()
		{
			foreach (var store in Bazaar.GetStoreList())
			{
				store.ViewSoldProducts();
			}
		}
	}
}
