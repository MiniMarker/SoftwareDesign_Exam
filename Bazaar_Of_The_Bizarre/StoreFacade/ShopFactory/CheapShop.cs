using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory {
	class CheapShop : IShop {
		private string _name;
		private int _price;
		private Random _random;

		public CheapShop(int price) {
			SetProductPrice(price);
		}

		public void GenerateName() {
			_random = new Random();
			var chosenStoreName = _random.Next(5);
			switch(chosenStoreName) {
				case 0:
					SetName("Emma's Cheapskate Shop");
					break;
				case 1:
					SetName("Christian's Supercheap Shop");
					break;
				case 2:
					SetName("Olav's Cheap Viking Souvenirs");
					break;
				case 3:
					SetName("Henke's Cheap Statue Shop");
					break;
				case 4:
					SetName("Even's Hipsterstatue Shop");
					break;
				default:
					SetName("Cheap Shop");
					break;
			}
		}

		public void SetProductPrice(int price) {
			_price = price;
		}

		public void SetName(string name) {
			_name = name;
		}

		public int GetPrice() {
			return _price;
		}

		public string GetName() {
			return _name;
		}
	}
}
