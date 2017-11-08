using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory {
	class CheapShop : IShop
	{
		private string _name;
		private int _price;

		public CheapShop(string name, int price) {
			this._name = name;
			this._price = price;
		}

		public void SetProductPrice(int price) {
			this._price = price;
		}

		public void SetName(string name) {
			this._name = name;
		}

		public int GetPrice() {
			return _price;
		}

		public string GetName() {
			return _name;
		}
	}
}
