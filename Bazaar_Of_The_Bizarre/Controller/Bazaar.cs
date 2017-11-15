using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade;
using Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory;

namespace Bazaar_Of_The_Bizarre.controller {
	class Bazaar {
		private List<Store> _stores;

		public Bazaar() {
			_stores = new List<Store>();
			CreateStores(4);
		}

		//If the store exist and customer has sufficent funds a product is returned.
		public IStatue GetProductFromStoreForCustomer(int socialSecurityNumber) {
			IStatue productToSell = null;


			var storeToShopFrom = GetRandomStore();
			//			    ProductToSell = StoreToShopFrom.SellProduct(socialSecurityNumber);

			return productToSell;
		}

		private Store GetRandomStore() {
			var rnd = new Random();

			return _stores[rnd.Next(1,_stores.Count)];

		}
		//Creates four different stores and adds them i _stores list.
		public void CreateStores(int amountOfStores) {
			for(var i = 0; i < amountOfStores; i++) {
				var rnd = new Random();
				var quota = rnd.Next(10, 30);

				if(i % 2 == 0) {
					_stores.Add(new Store(quota, ShopType.ExpensiveShop));
				}
				else {
					_stores.Add(new Store(quota, ShopType.CheapShop));
				}
			}
		}

		/*
				public List<Store> GetStores()
				{
					return _stores;
				}*/
	}
}
