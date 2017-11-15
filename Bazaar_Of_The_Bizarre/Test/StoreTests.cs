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
			var store = new Store("Christians most awesome items", 2, ShopType.CheapShop);
			store.RecieveProductFromBackroom(10);
			store.RecieveProductFromBackroom(4);


			Assert.IsTrue(store.Name.Equals("Christians most awesome items"));



			Console.WriteLine(store.GetProductList().Count);
			//Assert.IsTrue(store.GetProductList().Count == 4);

		}
	}
}