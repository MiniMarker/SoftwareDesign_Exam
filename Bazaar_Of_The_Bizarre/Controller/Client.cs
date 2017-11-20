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
	    private Thread[] _storeThreads;
	    private static int _socialSecurityNumber;

        public Client(int amountOfCustomers) {
			_bank = BankFactory.GetBank("DNB");
			_bazaar = new Bazaar();

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

			foreach (var customerThread in _customerThreads)
			{
				customerThread.Start();
			}
		}

		private void CreateAllCustomers()
		{


			for(var i = 0; i < _customers.Length; i++) {
				_customers[i] = new Customer(_socialSecurityNumber++, "Kunde" + i, _bank, _bazaar);
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

	    public void StartAllStoresThreads()
	    {
	        CreateAllStoresThreads();
	        foreach (var storeThread in _storeThreads)
	        {
	            storeThread.Start();
	        }
        }

        private void CreateAllStoresThreads()
        {
            var storesList = _bazaar.GetStoreList();

            int i = 0;
            foreach (var store in storesList) {
                    var thread = new Thread(store.FillProducts);
                    _storeThreads[i] = thread;
                    ++i;
             }
        }

	    public Boolean IsBazarClosed()
	    {
	        var isAnyStoreOpen = false;
	        var StoresList = _bazaar.GetStoreList();
	        foreach (var store in StoresList)
	        {
	            if (store.StoreIsOpen)
	            {
	                isAnyStoreOpen = true;
	            }
	        }

	        Console.WriteLine("Hellu I am done now. {0}", isAnyStoreOpen);
	        return isAnyStoreOpen;
	    }
	}
}
