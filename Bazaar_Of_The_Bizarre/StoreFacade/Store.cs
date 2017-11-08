using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory;

namespace Bazaar_Of_The_Bizarre.StoreFacade {
	class Store
	{
		public IShop Shop;
        public Backroom Backroom { get; set; }
        public string Name { get; set; }
        public int Quota { get; set; }
	    private List<Statue> _productsForSale;

   
        public Statue RecieveProductFromBackroom()
        {
	        return null;
        }

        public Statue ViewSoldProducts()
        {
	        return null;
        }

        public Boolean CloseStore()
        {
            return true;
        }

        public void SellProduct(int price, int socialSecurityNumber)
        {

        }

        private void GetShop(string type)
        {
	        ShopFactory.ShopFactory.CreateShop(ShopType.CheapShop, "cheapshit", 20);
        }
    }
}
