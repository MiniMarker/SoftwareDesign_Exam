using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory {

	class ShopFactory {
		private ShopFactory() { }

		public static IShop CreateShop(ShopType typeOfShop, int productPrice)
		{
			IShop shop = null;
			switch (typeOfShop)
			{
				case ShopType.ExpensiveShop:
					shop = new ExpensiveShop(productPrice);
					break;
				case ShopType.CheapShop:
					shop = new CheapShop(productPrice);
					break;
			}
			return shop;
		}
	}
}
