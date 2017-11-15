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
			//Assert.IsFalse(bazaar.GetStores().ContainsKey("TestStore10"));
		}

	}
}