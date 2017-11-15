using System;
using Bazaar_Of_The_Bizarre.controller;
using NUnit.Framework;
using NUnit.Mocks;

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
			Assert.IsTrue(bazaar.GetStores().ContainsKey("TestStore2"));
			Assert.IsTrue(bazaar.GetStores().ContainsKey("TestStore3"));
			Assert.IsTrue(bazaar.GetStores().ContainsKey("TestStore4"));
			//Assert.IsFalse(bazaar.GetStores().ContainsKey("TestStore10"));
		}

	}
}