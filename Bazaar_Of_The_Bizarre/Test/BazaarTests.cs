using System;
using Bazaar_Of_The_Bizarre.controller;
using Bazaar_Of_The_Bizarre.StoreFacade.ShopFactory;
using NUnit.Framework;
using NUnit.Mocks;

namespace Bazaar_Of_The_Bizarre.Test
{
	[TestFixture]
	public class BazaarTests
	{
		[Test]
		public void CreateStoresTest()
		{
			Bazaar bazaar = new Bazaar();

			Assert.AreEqual(bazaar.GetStoreList().Count, 4);
		}
	}
}