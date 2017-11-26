using System;
using System.Collections.Generic;
using System.Threading;
using Bazaar_Of_The_Bizarre.controller;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory;

namespace Bazaar_Of_The_Bizarre.StoreFacade {
	class Store {

		public IShop Shop;
		public Backroom Backroom { get; set; }
		public bool StoreIsOpen { get; private set; }
		public string Name { get; set; }
		public int Quota { get; set; }
		private readonly List<IStatue> _productsForSale;
		private readonly List<IStatue> _productsSold;
		private readonly object _syncLock = new object();

		/// <summary>
		///		Constructor
		/// </summary>
		/// <param name="quota">
		///		Sets the quota for product to be made for each backroom
		/// </param>
		/// <param name="typeOfShop">
		///		Enum of types of shop to be created.
		/// </param>
		public Store(int quota, ShopType typeOfShop) {
			Quota = quota;
			Shop = ShopFactory.ShopFactory.CreateShop(typeOfShop);
			Name = Shop.GetName();
			Backroom = new Backroom();
			_productsForSale = Backroom.CreateMultipleStatues(5);
			_productsSold = new List<IStatue>();
			StoreIsOpen = true;
		}

		/// <summary>
		///		Makes backroom create a product and adds it to _productsForSale
		/// </summary>
		/// <param name="numberOfDecorations">
		///		number of times a random decoration should be added to the statue
		/// </param>
		private void RecieveProductsForSaleFromBackroom(int numberOfDecorations) {
			lock(_syncLock) {
				if(_productsForSale.Count + _productsSold.Count < Quota) {
					var result = Backroom.CreateProduct(numberOfDecorations);
					_productsForSale.Add(result);
				}
			}
		}

		/// <summary>
		///		When products sold is equal to quota the store closes.
		/// </summary>
		public void CheckIfStoreShouldClose() {
			lock(_syncLock) {
				if(StoreIsOpen) {
					if(_productsSold.Count == Quota) {
						StoreIsOpen = false;
					}
				}
			}
		}

		/// <summary>
		///		Creates a new product every second until qouta is full.
		/// </summary>
		public void FillProducts() {
			while(StoreIsOpen) {
				CheckIfStoreShouldClose();
				RecieveProductsForSaleFromBackroom(Client.Rnd.Next(1, 10));
				Thread.Sleep(1000);
			}
			Thread.CurrentThread.Join();
		}

		/// <summary>
		///		If the store is open and there is products for sale a customer buys it.
		/// </summary>
		/// <param name="socialSecurityNumber">
		///		socialSecurityNumber is a unique identicator for each customer
		/// </param>
		/// <param name="name">
		///		name the customer who is buying a product
		/// </param>
		/// <returns>
		///		IStatue returns product if transaction was true
		/// </returns>
		public IStatue SellProduct(int socialSecurityNumber, string name) {
			var bank = Bank.BankFlyweight.BankFactory.GetBank("DNB");
			lock(_productsForSale)
				lock(_productsSold) {
					CheckIfStoreShouldClose();
					if(StoreIsOpen && _productsForSale.Count > 0) {
						var product = _productsForSale[0];
						var price = product.GetPrice();
						if(bank.Transaction(price, socialSecurityNumber)) {
							_productsSold.Add(product);
							_productsForSale.Remove(product);
							CheckIfStoreShouldClose();
							Console.WriteLine("Following product was sold to {0} for {1} kr from {2}.{3}{4}{5}", name,
								price, Name, System.Environment.NewLine, Client.PrintProduct.SortAndRetrieveProductDescription(product),
								System.Environment.NewLine);
							return product;
						}
						Console.WriteLine("{0} tried to buy a product at {1} for {2} kr. Withdrawal rejected. Insufficient funds.{3}", name, Name, price, System.Environment.NewLine);
					}
				}
			return null;
		}

		/// <summary>
		///		Prints out amount of products sold and total income.
		/// </summary>
		public void PrintDailyRevenue() {
			var sumOfDay = 0.0;
			var amountOfProducts = 0;
			lock(_syncLock) {
				foreach(var product in _productsSold) {
					amountOfProducts++;
					sumOfDay += product.GetPrice();
				}
			}
			Console.WriteLine("Store {0} is now closed. {1} products were sold, quota of the day was {2} and generated {3} kr.", Name, amountOfProducts, Quota, sumOfDay);
		}
	}
}