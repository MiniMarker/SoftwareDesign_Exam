using System;
using System.Collections.Generic;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade;
using Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory;


namespace Bazaar_Of_The_Bizarre.controller {
	class Bazaar {
		public List<Store> _listOfAllStores { get; set; }
		//List<Store> _listOfAllStores;

		/// <summary>
		/// Constructor 
		/// </summary>
		public Bazaar() {
			_listOfAllStores = new List<Store>();
			CreateStores(4);
		}

        /// <summary>
        /// Checks if any store is open, if not the bazar closes.
        /// </summary>
        /// <returns>Boolean Returns true if a store is open, this means that the bazar is open.</returns>
		public bool IsBazarOpen() {
			var isAnyStoreOpen = false;
			foreach(var store in _listOfAllStores) {
                store.CheckIfStoreShouldClose();
				if(store.StoreIsOpen) {

					//                    Console.WriteLine("{0} is open so Bazaar won't stop.", store.Name);
					isAnyStoreOpen = true;
				}
			}
			return isAnyStoreOpen;
		}

        /// <summary>
        /// If there are any open stores in the bazar then the customer can buy a product.
        /// </summary>
        /// <param name="socialSecurityNumber"></param>
        /// <param name="name"></param>
        /// <returns>IStatue Returns product from store to customer.</returns>
        public IStatue GetProductFromStoreForCustomer(int socialSecurityNumber, string name) {
			if(IsBazarOpen()) {
				var storeToShopFrom = GetRandomStore();
				return storeToShopFrom.SellProduct(socialSecurityNumber, name);
			}
			return null;
		}

        /// <summary>
        /// Gets random store, if it's not open, gets the first open store.
        /// </summary>
        /// <returns>Store Returns random open store</returns>
        private Store GetRandomStore() {
			var store = _listOfAllStores[Client.Rnd.Next(1, _listOfAllStores.Count)];
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
				//TODO how much should the be? Change here.
				var quota = Client.Rnd.Next(5, 10);
				_listOfAllStores.Add(i % 2 == 0 ? new Store(quota, ShopType.ExpensiveShop) : new Store(quota, ShopType.CheapShop));
			}
		}

        /// <summary>
        /// /Returns a list of the different stores.
        /// </summary>
        /// <returns>List Returns list of all stores</returns>
        public List<Store> GetStoreList() {
			return _listOfAllStores;
		}
	}
}
