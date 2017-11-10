using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory;

namespace Bazaar_Of_The_Bizarre.StoreFacade {
	class Store {
		public IShop Shop;
		public Backroom Backroom { get; set; }
		public string Name { get; set; }
		public int Quota { get; set; }
		private List<IStatue> _productsForSale;
		private readonly Random _rnd = new Random();

		public Store(string name, int quota, ShopType typeOfShop)
		{
			Name = name;
			Quota = quota;
			Shop = CreateShop(typeOfShop);
			Backroom = new Backroom();
			_productsForSale = new List<IStatue>();
			_productsForSale = Backroom.CreateManyStatues(5);

		}

		// Makes backroom create a product and adds it to _productsForSale
		public void RecieveProductFromBackroom(int numberOfDecorations)
		{
			IStatue result = Backroom.CreateProduct(numberOfDecorations);
			_productsForSale.Add(result);
		}

		//Prints out amount of products sold and total income.
		public void ViewSoldProducts()
		{
			var sumOfDay = 0.0;
			var amountOfProducts = 0;

			foreach (var product in _productsForSale)
			{
				amountOfProducts++;
				sumOfDay += product.GetPrice();
			}
			Console.WriteLine("Store {0} is now closed. {1} products were sold and generated {2} kr.", Name, amountOfProducts, sumOfDay);
		}

		//Todo, what should CloseStore actually do?
		public Boolean CloseStore() {
			ViewSoldProducts();
			return false;
		}

		//Todo, when products are 100% done.
		//sjekk pris, hvis kundens balanse
	/*	public IStatue SellProduct(int socialSecurityNumber) {
			Bank.BankFlyweight.Bank bank = Bank.BankFlyweight.BankFactory.GetBank("DnB");
			int price = 0; // Må få pris på produkten?
			if (bank.Transaction(price, socialSecurityNumber))
			{
				
			}
			else
			{
			}

		}*/

		//Creates a shop based on given type of shop.
		public IShop CreateShop(ShopType shopType)
		{
			switch (shopType)
			{
				case ShopType.CheapShop:
					Shop = ShopFactory.ShopFactory.CreateShop(ShopType.CheapShop);
					break;
				case ShopType.ExpensiveShop:
					Shop = ShopFactory.ShopFactory.CreateShop(ShopType.ExpensiveShop);
					break;
			}
			return Shop;
		}

	}
}
