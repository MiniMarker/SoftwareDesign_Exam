using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade;
using Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory;

namespace Bazaar_Of_The_Bizarre.controller {
	class Bazaar
	{
	    private Dictionary<string, Store> _stores;

	    public Bazaar() {
            this._stores = new Dictionary<string, Store>();
			CreateStores();
        }

		//If the store exist and customer has sufficent funds a product is returned.
	    public IStatue GetProductFromStoreForCustomer(int socialSecurityNumber)
	    {
		    IStatue ProductToSell = null;
		    string store = "here we create a random storename";

			if (_stores.ContainsKey(store))
		    {
			    Store StoreToShopFrom = _stores[store];
			    ProductToSell = StoreToShopFrom.SellProduct(socialSecurityNumber);
		    }
		    return ProductToSell;
	    }

		//Creates four different stores and adds them i _stores list.
	    public void CreateStores()
	    {
			var store1 = new Store("TestStore1", 10, ShopType.CheapShop);
		    _stores.Add("TestStore1", store1);
			var store2 = new Store("TestStore2", 15, ShopType.CheapShop);
		    _stores.Add("TestStore2", store2);
			var store3 = new Store("TestStore3", 8, ShopType.ExpensiveShop);
		    _stores.Add("TestStore3", store3);
			var store4 = new Store("TestStore4", 19, ShopType.ExpensiveShop);
		    _stores.Add("TestStore4", store4);
		}
	}
}
