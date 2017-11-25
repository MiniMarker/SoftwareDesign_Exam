using System.Collections.Generic;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade;
using Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory;


namespace Bazaar_Of_The_Bizarre.controller {
	class Bazaar {
		public List<Store> ListOfAllStores { get; set; }

		/// <summary>
		///		Constructor
		/// </summary>
		public Bazaar() {
			ListOfAllStores = new List<Store>();
			CreateStores(4);
		}

        /// <summary>
        ///		Checks if any store is open, if not the bazar closes.
        /// </summary>
        /// <returns>
        ///		Boolean Returns true if a store is open, this means that the bazar is open.
        /// </returns>
		public bool IsBazarOpen() {
			var isAnyStoreOpen = false;

			foreach(var store in ListOfAllStores) {
                store.CheckIfStoreShouldClose();

				if(store.StoreIsOpen) {
					isAnyStoreOpen = true;
				}
			}
			return isAnyStoreOpen;
		}

        /// <summary>
        ///		If there are any open stores in the bazar then the customer can buy a product.
        /// </summary>
        /// <param name="socialSecurityNumber">
        ///		socialSecurityNumber is a unique identicator for each customer
        /// </param>
        /// <param name="name">
        ///		name the customer who is buying a product
        /// </param>
        /// <returns>IStatue Returns product from store to customer.</returns>
        public IStatue GetProductFromStoreForCustomer(int socialSecurityNumber, string name) {
			if(IsBazarOpen()) {
				var storeToShopFrom = GetRandomStore();
				return storeToShopFrom.SellProduct(socialSecurityNumber, name);
			}
			return null;
		}

        /// <summary>
        ///		Gets random store, if it's not open, gets the first open store.
        /// </summary>
        /// <returns>
        ///		Store Returns random open store
        /// </returns>
        private Store GetRandomStore() {
			var store = ListOfAllStores[Client.Rnd.Next(1, ListOfAllStores.Count)];
			if(!store.StoreIsOpen) {
				for(int i = 0; i < ListOfAllStores.Count; i++) {
					if(ListOfAllStores[i].StoreIsOpen) {
						store = ListOfAllStores[i];
						break;
					}
				}
			}
			return store;
		}

		/// <summary>
		///		Creates stores.
		/// </summary>
		/// <param name="amountOfStores">
		///		Number of stores to be opened
		/// </param>
		public void CreateStores(int amountOfStores) {

			for(var i = 0; i < amountOfStores; i++) {
				//quota
				var quota = Client.Rnd.Next(5, 10);
				ListOfAllStores.Add(i % 2 == 0 ? new Store(quota, ShopType.ExpensiveShop) : new Store(quota, ShopType.CheapShop));
			}
		}
	}
}
