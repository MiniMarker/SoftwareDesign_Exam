using System;
using System.Collections.Generic;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade;
using Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory;


namespace Bazaar_Of_The_Bizarre.controller {
	class Bazaar {
		private List<Store> _listOfAllStores;
		private Boolean _bazarClosed;

		/// <summary>
		/// Constructor for 
		/// </summary>
		public Bazaar() {
			_listOfAllStores = new List<Store>();
			_bazarClosed = false;
			CreateStores(4);
		}

		// Checks if any store is open, if not the bazar closes.
		public Boolean IsBazarOpen() {
			var isAnyStoreOpen = false;
			foreach(var store in _listOfAllStores) {
				if(store.StoreIsOpen) {
					isAnyStoreOpen = true;
				}
			}

			if(isAnyStoreOpen == false) {
				_bazarClosed = true;
			}

			return isAnyStoreOpen;
		}

		//If there are any open stores in the bazar then the customer can buy a product.
		public IStatue GetProductFromStoreForCustomer(int socialSecurityNumber, string name) {
			if(IsBazarOpen()) {
				var storeToShopFrom = GetRandomStore();
				return storeToShopFrom.SellProduct(socialSecurityNumber, name);
			}
			return null;
		}

		// Gets random store, if it's not open, gets the first open store.
		private Store GetRandomStore() {
			var store = _listOfAllStores[Program.Rnd.Next(1, _listOfAllStores.Count)];

			//TODO  If the first random store is not open, take the first open store. Should it be random?
			if(!store.StoreIsOpen) {
				for(int i = 0; i < _listOfAllStores.Count; i++) {
					if(_listOfAllStores[i].StoreIsOpen) {
						store = _listOfAllStores[i];
						break;
					}
				}
			}
			return store;
		}

		/// <summary>
		/// Creates stores, amount set in param.
		/// </summary>
		/// <param name="amountOfStores"></param>
		public void CreateStores(int amountOfStores) {
			for(var i = 0; i < amountOfStores; i++) {
				//TODO how much should the quota be? Change here.
				var quota = Program.Rnd.Next(5, 10);
				_listOfAllStores.Add(i % 2 == 0 ? new Store(quota, ShopType.ExpensiveShop) : new Store(quota, ShopType.CheapShop));
			}
		}

		//Returns a list of the different stores.
		public List<Store> GetStoreList() {
			return _listOfAllStores;
		}
	}
}
