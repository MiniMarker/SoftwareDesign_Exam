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
		private List<Store> _listOfAllStores;

		/// <summary>
		/// Constructor for 
		/// </summary>
		public Bazaar() {
			_listOfAllStores = new List<Store>();
			CreateStores(4);
		}

		//If the store exist and customer has sufficent funds a product is returned.
		public IStatue GetProductFromStoreForCustomer(int socialSecurityNumber) {

			var storeToShopFrom = GetRandomStore();
			while(!storeToShopFrom.StoreIsOpen) {
				storeToShopFrom = GetRandomStore();
			}
			return storeToShopFrom.SellProduct(socialSecurityNumber);
		}

		private Store GetRandomStore() {
			var rnd = new Random();

			return _listOfAllStores[rnd.Next(1, _listOfAllStores.Count)];

		}
		/// <summary>
		/// Creates stores, amount set in param.
		/// </summary>
		/// <param name="amountOfStores"></param>
		public void CreateStores(int amountOfStores) {
			for(var i = 0; i < amountOfStores; i++) {
				var rnd = new Random();
				var quota = rnd.Next(10, 30);

				if(i % 2 == 0) {
					_listOfAllStores.Add(new Store(quota, ShopType.ExpensiveShop));
				}
				else {
					_listOfAllStores.Add(new Store(quota, ShopType.CheapShop));
				}
			}
		}

		public List<Store> GetStoreList()
		{
			return _listOfAllStores;
		}
	}
}
