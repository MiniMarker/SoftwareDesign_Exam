using System;
using System.Globalization;
using Bazaar_Of_The_Bizarre.StoreFacade;
using Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory;
using NUnit.Framework;

namespace Bazaar_Of_The_Bizarre.Test
{
	[TestFixture]
	public class StoreTests
	{
		[Test]
		public void TestCreateStore()
		{
			Store store = new Store(2, ShopType.CheapShop);

			Assert.IsTrue(store);
			Console.WriteLine(store.Name);


		}
	}
}