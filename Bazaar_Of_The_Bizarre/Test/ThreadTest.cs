using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.controller;
using Bazaar_Of_The_Bizarre.Controller;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Bazaar_Of_The_Bizarre.Test
{
	[TestFixture]
	class ThreadTest {
		[Test]
		public void CreateCustomerTest()
		{
			var threadHandler = new ThreadHandler(10);
			Assert.IsTrue(threadHandler.Customers.Length == 10);
			Console.WriteLine(threadHandler.Customers.Length);
			Console.WriteLine(threadHandler.CustomerThreads[1].Name);


		}

		[Test]
		public void CheckIfNamesAreUnique()
		{
			ThreadHandler threadHandler = new ThreadHandler(10);

			for (var i = 0; i < threadHandler.Customers.Length-1; i++)
			{
				var iName = threadHandler.Customers[i].Name;

				for (int j = i + 1; j < threadHandler.Customers.Length; j++)
				{
					var jName = threadHandler.Customers[j].Name;
					Assert.AreNotEqual(iName, jName);
				}
			}
		}
	}
}
