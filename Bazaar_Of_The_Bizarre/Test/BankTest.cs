using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using NUnit.Framework;

namespace Bazaar_Of_The_Bizarre.Test
{
	[TestFixture]
    class BankTest
    {
		[Test]
	    public void TestCreateAccount()
	    {
		    var DnB = BankFactory.GetBank("DnB");

		    DnB.CreateAccount(007);
		    DnB.CreateAccount(008);
		    DnB.CreateAccount(009);

		    Assert.AreEqual(DnB.getAccounts().Count, 3);
	    }

		[Test]
	    public void TestWithdrawalSuccess()
	    {
			var account = new BankAccount(150);

		    Assert.IsTrue(account.Withdrawal(100));

			Assert.AreEqual(account.Sum, 50,0);
	    }

	    [Test]
	    public void TestWithdrawalFail()
	    {
		    var account = new BankAccount(150);

		    Assert.IsFalse(account.Withdrawal(1000));
	    }
	}
}
