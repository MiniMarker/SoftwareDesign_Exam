using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory {
	class ShopFactory {
        /// <summary>
        /// Constructor
        /// </summary>
        private ShopFactory() { }

        /// <summary>
        /// Creates an expensive shop or cheap shop
        /// </summary>
        /// <param name="typeOfShop"></param>
        /// <returns>IShop Returns a shop</returns>
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

        /// <summary>
        /// Choses a random price for product
        /// </summary>
        /// <param name="shopType"></param>
        /// <returns>int Returns price for product</returns>
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
