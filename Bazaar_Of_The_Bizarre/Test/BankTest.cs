
using Bazaar_Of_The_Bizarre.Bank;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using NUnit.Framework;

namespace Bazaar_Of_The_Bizarre.Test
{
	[TestFixture]
    class BankTest
    {
		[Test]
	    public void CreateAccountTest()
		{
		    var DnB = BankFactory.GetBank("DnB");

		    DnB.CreateAccount(007);
		    DnB.CreateAccount(008);
		    DnB.CreateAccount(009);

		    Assert.AreEqual(DnB.GetAccounts().Count, 3);
	    }

		[Test]
	    public void WithdrawalSuccessTest()
	    {
			var account = new BankAccount(150);

		    Assert.IsTrue(account.Withdrawal(100));

			Assert.AreEqual(account.GetSum(), (150-100));
	    }

	    [Test]
	    public void WithdrawalFailTest()
	    {
		    var account = new BankAccount(150);

		    Assert.IsFalse(account.Withdrawal(1000));
			Assert.AreEqual(account.GetSum(), 150);
	    }
	}
}
