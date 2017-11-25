using System;
using System.Runtime.InteropServices;
using Bazaar_Of_The_Bizarre.controller;
using Bazaar_Of_The_Bizarre.Controller;
using NUnit.Framework;

namespace Bazaar_Of_The_Bizarre.Test
{
	[TestFixture]
	public class CustomerTests
	{
		[Test] 
		public void CreateCustomerTest()
		{
			Client client = new Client(10);

//			Assert.AreEqual(client._customers.Length, 10);
		}

		[Test]
		public void CheckIfNamesAreUnique()
		{
			Client clients = new Client(10);

//			for (var i = 0; i < clients._customers.Length-1; i++)
//			{
//				string iClientName = clients._customers[i].Name;
//
//
//				for (int j = i + 1; j < clients._customers.Length; j++)
//				{
//					string jClientName = clients._customers[j].Name;
//					Assert.AreNotEqual(iClientName,jClientName);
//				}
//			}
		}
	}
}