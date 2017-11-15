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
		public bool StoreIsOpen { get; private set; }
		public string Name { get; set; }
		public int Quota { get; set; }

		private List<IStatue> _productsForSale;
		private List<IStatue> _productsSold;
		private readonly Random _rnd = new Random();

		public Store(int quota, ShopType typeOfShop) {
			Quota = quota;
			Shop = ShopFactory.ShopFactory.CreateShop(typeOfShop);
			Name = Shop.GetName();
			Console.WriteLine("Name of store: " + Name);
			Backroom = new Backroom();
//			_productsForSale = new List<IStatue>();
			_productsForSale = Backroom.CreateMultipleStatues(5);
			_productsSold = new List<IStatue>();
			StoreIsOpen = true;

/*
			_productsForSale.Add(Backroom.CreateProduct(5));
			_productsForSale.Add(Backroom.CreateProduct(5));
			_productsForSale.Add(Backroom.CreateProduct(5));
			_productsForSale.Add(Backroom.CreateProduct(5));
			_productsForSale.Add(Backroom.CreateProduct(5));
			_productsForSale.Add(Backroom.CreateProduct(5));
			Console.WriteLine(_productsForSale.Count);*/
		}

		// Makes backroom create a product and adds it to _productsForSale
		private bool RecieveProductFromBackroom(int numberOfDecorations) {
			if((_productsForSale.Count + _productsSold.Count) < Quota) {
				var result = Backroom.CreateProduct(numberOfDecorations);
				_productsForSale.Add(result);
				return true;
			}
			return false;
		}

		//Prints out amount of products sold and total income.
		private void ViewSoldProducts() {
			var sumOfDay = 0.0;
			var amountOfProducts = 0;

			foreach(var product in _productsSold) {
				amountOfProducts++;
				sumOfDay += product.GetPrice();
			}
			Console.WriteLine("Store {0} is now closed. {1} products were sold and generated {2} kr.", Name, amountOfProducts, sumOfDay);
		}
		
		private void CheckIfStoreShouldClose()
		{
			if(_productsForSale.Count == 0) {
				StoreIsOpen = false;
			}
		}
		
		//TODO insert ThreadLock
		public IStatue SellProduct(int socialSecurityNumber) {
			var bank = Bank.BankFlyweight.BankFactory.GetBank("DNB");
			Console.WriteLine(_productsForSale.Count);
			
			var product = _productsForSale[0];
			var price = product.GetPrice();

			if(bank.Transaction(price, socialSecurityNumber)) {
				_productsSold.Add(product);
				_productsForSale.Remove(product);
				CheckIfStoreShouldClose();
				return product;
			}

			return null;
		}

		/*//Creates a shop based on given type of shop.
		public IShop CreateShop(ShopType shopType) {
			switch(shopType) {
				case ShopType.CheapShop:
					Shop = ShopFactory.ShopFactory.CreateShop(ShopType.CheapShop);
					break;
				case ShopType.ExpensiveShop:
					Shop = ShopFactory.ShopFactory.CreateShop(ShopType.ExpensiveShop);
					break;
			}
			return Shop;
		}*/
	}
}
