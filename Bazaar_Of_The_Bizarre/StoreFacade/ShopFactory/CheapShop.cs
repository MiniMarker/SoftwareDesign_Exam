using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory {
	class CheapShop : IShop {
		private string _name;
		private int _price;

	    /// <summary>
	    ///     Constructor
	    /// </summary>
	    /// <param name="price">
	    ///     Minimum price for products that the shop sell
	    /// </param>
        public CheapShop(int price) {
			SetProductPrice(price);
			GenerateName();
		}

	    /// <summary>
	    ///     Generates a random name for the shop
	    /// </summary>
		public void GenerateName() {
			var chosenStoreName = Client.Rnd.Next(5);
			switch(chosenStoreName) {
				case 0:
					SetName("Emma's Cheapskate Shop");
					break;
				case 1:
					SetName("Christian's Supercheap Shop");
					break;
				case 2:
					SetName("Olav V's Cheap Viking Souvenirs");
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
        ///     Name on shop
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

        //TODO Set explaination on singleton and flyweight
	}
}