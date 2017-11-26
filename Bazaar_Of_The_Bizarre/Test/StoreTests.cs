using System;
using System.Globalization;
using Bazaar_Of_The_Bizarre.StoreFacade;
using Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory;
using NUnit.Framework;

namespace Bazaar_Of_The_Bizarre.Test {
	[TestFixture]
	public class StoreTests {

		[Test]
		public void TestCreateStore() {
			var store = new Store(10, ShopType.ExpensiveShop);
			Assert.NotNull(store);
			Assert.AreEqual(5, store.ProductsForSale.Count);
		}
	}
}