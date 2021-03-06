﻿using System;
using Bazaar_Of_The_Bizarre.controller;
using NUnit.Framework;

namespace Bazaar_Of_The_Bizarre.Test {
	[TestFixture]
	public class BazaarTests {

		private Bank.BankFlyweight.Bank _bank;
		private Bazaar _bazaar;
		private Customer _customer;

		[SetUp]
		public void SetUp() {
			_bank = Bank.BankFlyweight.BankFactory.GetBank("DNB");
			_bazaar = new Bazaar();
			_customer = new Customer(1, "TestyTest", _bank, _bazaar);
		}

		[Test]
		public void CreateBazaarCreates4StoresTest() {
			Assert.AreEqual(4, _bazaar.ListOfAllStores.Count);
		}

		[Test]
		public void GetProductFromStoreForCustomer()
		{
			var statue = _bazaar.GetProductFromStoreForCustomer(1, "TestyTest");
			Assert.NotNull(statue);
		}
	}
}