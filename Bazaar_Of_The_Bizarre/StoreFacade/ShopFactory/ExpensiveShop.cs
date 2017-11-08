using System;

namespace Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory {
	class ExpensiveShop : IShop
	{
		private string _name;
		private int _price;

		public ExpensiveShop(string name, int price)
		{
			this._name = name;
			this._price = price;
		}

		public void SetProductPrice(int price)
		{
			this._price = price;
		}

	    public void SetName(string name)
	    {
		    this._name = name;
	    }

		public int GetPrice()
		{
			return _price;
		}

		public string GetName()
		{
			return _name;
		}


	}
}
