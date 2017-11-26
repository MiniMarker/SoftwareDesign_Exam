using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.controller;
using NUnit.Framework;

namespace Bazaar_Of_The_Bizarre.Test {

	[TestFixture]
	class CustomerTests {

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
		public void ConfirmThatCustomerIsCreatedWithEnoughFunds() {
			Assert.True(_customer.CheckIfEnoughFunds());
		}
	}
}
