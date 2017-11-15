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
			Store store = new Store("Christians most awesome items", 2, ShopType.CheapShop);

			Assert.AreEqual(store.Name, "Christians most awesome items");


		}
	}
}