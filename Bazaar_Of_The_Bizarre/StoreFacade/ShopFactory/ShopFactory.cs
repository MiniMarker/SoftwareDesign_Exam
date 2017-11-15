using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory {

	class ShopFactory {
		private static readonly Random _rnd = new Random();
		private ShopFactory() { }

		public static IShop CreateShop(ShopType typeOfShop)
		{
			//
//			Thread.Sleep(450);
			IShop shop = null;
			switch (typeOfShop)
			{
				case ShopType.ExpensiveShop:
					shop = new ExpensiveShop(ChooseRandomPrice(ShopType.ExpensiveShop), _rnd);
					break;
				case ShopType.CheapShop:
					shop = new CheapShop(ChooseRandomPrice(ShopType.CheapShop), _rnd);
					break;
			}
			return shop;
		}


		//Chooses a random price for products.
		private static int ChooseRandomPrice(ShopType shopType)
		{
			var productPrice = _rnd.Next(30);
			if (shopType == ShopType.ExpensiveShop)
			{
				productPrice += 7;
			}
			return productPrice;
		}

	}
}
