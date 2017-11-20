﻿using System;
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
	    private readonly Object _lock = new Object();

        public Store(int quota, ShopType typeOfShop) {
			Quota = quota;
			Shop = ShopFactory.ShopFactory.CreateShop(typeOfShop);
			Name = Shop.GetName();
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
			if(_productsSold.Count == Quota) {
				StoreIsOpen = false;
			}
		}

        // TODO Should we add  multie products at a time or just one and one?? 
	    public void FillProducts()
	    {
	        while (_productsSold.Count <= Quota)
	        {
	            var amountOfProducts = _rnd.Next(1, 4);

	            if ((_productsSold.Count + amountOfProducts) <= Quota)
	            {
	                var listOfProducts = Backroom.CreateMultipleStatues(amountOfProducts);
	                _productsForSale.AddRange(listOfProducts);
	            }
                Thread.Sleep(1000);
	        }
	        CheckIfStoreShouldClose();
            StoreIsOpen = false;
        }

	    public IStatue SellProduct(int socialSecurityNumber) {
			var bank = Bank.BankFlyweight.BankFactory.GetBank("DNB");
			
			var product = _productsForSale[0];
			var price = product.GetPrice();
		    var transactionMade = false;

		    lock(_lock)
		    {
		        if (bank.Transaction(price, socialSecurityNumber))
		        {
		            _productsSold.Add(product);
		            _productsForSale.Remove(product);
		            CheckIfStoreShouldClose();
		            transactionMade = true;

                    return product;
		        }
		    }

            //Kill thread if no withdrawal was made
		    if (!transactionMade)
		    {
		        Thread.CurrentThread.Join();
            }
            return null;
		}
	}
}
