using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
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
		private readonly Random _rnd = new Random();

		public Statue RecieveProductFromBackroom() {
			return null;
		}

		public void ViewSoldProducts()
		{
			var sumOfDay = 0.0;
			var amountOfProducts = 0;

			foreach (var product in _productsForSale)
			{
				amountOfProducts++;
				sumOfDay += product.GetPrice();
			}
			Console.WriteLine("Store {0} is now closed. {1} products were sold and generated {2} kr.", Name, amountOfProducts, sumOfDay);
		}

		public Boolean CloseStore() {
			ViewSoldProducts();
			return true;
		}

		public void SellProduct(int price, int socialSecurityNumber) {
			Bank.BankFlyweight.Bank bank = Bank.BankFlyweight.BankFactory.GetBank("DnB");
			if (bank.Transaction(price, socialSecurityNumber))
			{

			}
			else
			{
			}

		}
		//TODO Make random
		public void GetShop(string shopType)
		{
			switch (shopType.ToLower())
			{
				case "cheap":
					Shop = ShopFactory.ShopFactory.CreateShop(ShopType.CheapShop, ChooseRandomPrice(ShopType.CheapShop));
					break;
				case "expensive":
					Shop = ShopFactory.ShopFactory.CreateShop(ShopType.ExpensiveShop, ChooseRandomPrice(ShopType.ExpensiveShop));
					break;
			}
		}

		/*		private ShopType ChooseRandomShopType()
				{
					var randomType = _rnd.Next(2);
					return randomType == 0 ? ShopType.CheapShop : ShopType.ExpensiveShop;
				}*/

		private int ChooseRandomPrice(ShopType shopType)
		{
			var productPrice = _rnd.Next(30);
			if(shopType == ShopType.ExpensiveShop)
			{
				productPrice += 7;
			}
			return productPrice;
		}

	}
}
