using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory {
	class ExpensiveShop : IShop {
		private string _name;
		private int _price;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="price">
        ///     Minimum price for products that the shop sell
        /// </param>
		public ExpensiveShop(int price) {
			SetProductPrice(price);
			GenerateName();
		}

        /// <summary>
        ///     Generates a random name for the shop
        /// </summary>
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

        /// <summary>
        ///     Sets price on products
        /// </summary>
        /// <param name="price">
        ///     Minimum price on product
        /// </param>
		public void SetProductPrice(int price) {
			_price = price;
		}

        /// <summary>
        ///     Sets name on shop
        /// </summary>
        /// <param name="name">
        ///     Name for shop
        /// </param>
		public void SetName(string name) {
			_name = name;
		}

        /// <summary>
        ///     Returns minimum price on products
        /// </summary>
        /// <returns>
        ///     int that is the price
        /// </returns>
		public int GetPrice() {
			return _price;
		}

        /// <summary>
        ///     Returns name of shop
        /// </summary>
        /// <returns>
        ///     Returns a string which is the name
        /// </returns>
		public string GetName() {
			return _name;
		}


	}
}
