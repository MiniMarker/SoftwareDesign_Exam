using System;
using System.Threading;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using Bazaar_Of_The_Bizarre.Controller;

namespace Bazaar_Of_The_Bizarre.controller {
	class Client {

		public static readonly Random Rnd = new Random();
		public static readonly PrintHandler PrintProduct = PrintHandler.GetInstance();
		private readonly Bank.BankFlyweight.Bank _bank;
		private readonly Bazaar _bazaar;
		private readonly ThreadHandler _threadHandler;

		/// <summary>
		///		Constructor
		/// </summary>
		/// <param name="amountOfCustomers">
		///		Number of customer to be created
		/// </param>
		public Client(int amountOfCustomers) {
			_bank = BankFactory.GetBank("DNB");
			_bazaar = new Bazaar();
			_threadHandler = new ThreadHandler(amountOfCustomers);
		}

		/// <summary>
		///		Starts the whole prosess of creating threads of customers and stores
		/// </summary>
		public void StartBazaar() {
			_threadHandler.StartAllStoresThreads(_bazaar);

			if(_bazaar.IsBazarOpen()) {
				_threadHandler.StartAllCustomerThreads(_bank, _bazaar);

				while(_bazaar.IsBazarOpen()) {
					_threadHandler.GenerateExtraCustomers(_bank, _bazaar);

				}
				EndOfDay();
				Console.WriteLine("Bazar is now closed.");
			}
		}

		/// <summary>
		///		Prints out an receipt of all sold product of the day for each store.
		/// </summary>
		private void EndOfDay() {
			foreach(var store in _bazaar.ListOfAllStores) {
				store.ViewSoldProducts();
			}
		}
	}
}
