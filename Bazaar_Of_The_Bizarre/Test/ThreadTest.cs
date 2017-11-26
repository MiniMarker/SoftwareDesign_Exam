using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using Bazaar_Of_The_Bizarre.controller;
using Bazaar_Of_The_Bizarre.Controller;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Bazaar_Of_The_Bizarre.Test {

	[TestFixture]
	class ThreadTest
	{
		private Bazaar _bazaar;
		private Bank.BankFlyweight.Bank _bank;

		[SetUp]
		public void Initialize() {
			_bazaar = new Bazaar();
			_bank = BankFactory.GetBank("DnB");

		}



		[Test]
		public void CreateCustomerTest() {
			var threadHandler = new ThreadHandler(10);
			threadHandler.GenerateExtraCustomerIfNeeded(_bank, _bazaar);
			Assert.IsTrue(threadHandler.Customers.Count == 10);
		}

		[Test]
		public void CheckIfNamesAreUnique() {
			var threadHandler = new ThreadHandler(10);

			threadHandler.StartAllCustomerThreads(_bank, _bazaar);

			for(var i = 0; i < threadHandler.Customers.Count - 1; i++) {
				var iName = threadHandler.Customers[i].Name;

				for(var j = i + 1; j < threadHandler.Customers.Count; j++) {
					var jName = threadHandler.Customers[j].Name;
					Assert.AreNotEqual(iName, jName);
				}
			}
		}
	}
}
