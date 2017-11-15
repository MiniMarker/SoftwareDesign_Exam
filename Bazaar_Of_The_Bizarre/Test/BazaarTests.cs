using System;
using Bazaar_Of_The_Bizarre.controller;
using Bazaar_Of_The_Bizarre.StoreFacade;
using Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory;
using NUnit.Framework;

namespace Bazaar_Of_The_Bizarre.Test
{
	[TestFixture]
	public class BazaarTests
	{

		[Test]
		public void TestCreateStores()
		{
			Bazaar bazaar = new Bazaar();

			Assert.AreEqual(bazaar.GetStores().Count, 4);
			Assert.IsTrue(bazaar.GetStores().ContainsKey("TestStore1"));
			Assert.IsFalse(bazaar.GetStores().ContainsKey("TestStore10"));
		}

	}
}