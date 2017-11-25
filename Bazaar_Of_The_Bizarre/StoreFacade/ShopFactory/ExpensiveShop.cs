using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory {
	class ExpensiveShop : IShop {
		private string _name;
		private int _price;

		public ExpensiveShop(int price) {
			SetProductPrice(price);
			GenerateName();
		}

		public void GenerateName() {
			var chosenStore = Client.Rnd.Next(4);
			switch(chosenStore) {
				case 0:
					SetName("Santom's Amazingly Expensive Shop");
					break;
				case 1:
					SetName("Lauper's Great Expenses Shop");
					break;
				case 2:
					SetName("Arcand's Large Expensive Shop");
					break;
				case 3:
					SetName("Your Wallet Too Small Shop");
					break;
				default:
					SetName("Expensive Shop");
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
