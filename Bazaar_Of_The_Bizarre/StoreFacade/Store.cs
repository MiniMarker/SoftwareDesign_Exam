using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory;

namespace Bazaar_Of_The_Bizarre.StoreFacade {
	class Store {
		public IShop Shop;
		public Backroom Backroom { get; set; }
		public string Name { get; set; }
		public int Quota { get; set; }
		private List<Statue> _productsForSale;
		Random rnd = new Random();

		public Statue RecieveProductFromBackroom() {
			return null;
		}

		public Statue ViewSoldProducts() {
			return null;
		}

		public Boolean CloseStore() {
			return true;
		}

		public void SellProduct(int price, int socialSecurityNumber) {

		}

		public void GetShop()
		{
			var shopType = ChooseRandomShopType();
			
			Shop = ShopFactory.ShopFactory.CreateShop(shopType, ChooseRandomPrice(shopType));
		}

		private ShopType ChooseRandomShopType() {
			var randomType = rnd.Next(2);

			if(randomType == 0) {
				return ShopType.CheapShop;
			}

			return ShopType.ExpensiveShop;
		}

		private int ChooseRandomPrice(ShopType shopType)
		{
			var productPrice = rnd.Next(30);

			if(shopType == ShopType.ExpensiveShop) {
				productPrice = rnd.Next(30, 40);
			}
			return productPrice;
		}

	}
}
