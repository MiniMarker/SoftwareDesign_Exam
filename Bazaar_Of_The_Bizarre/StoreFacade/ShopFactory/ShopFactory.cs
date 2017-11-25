using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory {
	class ShopFactory { 
		private ShopFactory() { }

		public static IShop CreateShop(ShopType typeOfShop)
		{
			IShop shop = null;
			switch (typeOfShop)
			{
				case ShopType.ExpensiveShop:
					shop = new ExpensiveShop(ChooseRandomPrice(ShopType.ExpensiveShop));
					break;
				case ShopType.CheapShop:
					shop = new CheapShop(ChooseRandomPrice(ShopType.CheapShop));
					break;
			}
			return shop;
		}

		//Chooses a random price for products.
		private static int ChooseRandomPrice(ShopType shopType)
		{
			var productPrice = Client.Rnd.Next(10, 30);
			if (shopType == ShopType.ExpensiveShop)
			{
				productPrice += 20;
			}
			return productPrice;
		}
	}
}
