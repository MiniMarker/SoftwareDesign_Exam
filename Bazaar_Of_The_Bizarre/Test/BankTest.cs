
using Bazaar_Of_The_Bizarre.Bank;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using NUnit.Framework;

namespace Bazaar_Of_The_Bizarre.Test
{
	[TestFixture]
    class BankTest
	{
		private Bank.BankFlyweight.Bank _bank;
	    [SetUp]
	    public void SetUp()
	    {
		     _bank = BankFactory.GetBank("DNB");

		}
		[Test]
	    public void CreateAccountTest()
		{
			_bank.CreateAccount(007);
			_bank.CreateAccount(008);
			_bank.CreateAccount(009);

		    Assert.AreEqual(_bank.GetAccounts().Count, 3);
	    }

	    [Test]
	    public void CreatingBankWithSameNameGetsSameBank()
	    {
		    _bank.CreateAccount(1);
		    _bank.CreateAccount(2);
		    var accounts = _bank.GetAccounts();
		    Assert.AreEqual(2, accounts.Count);
		    var bankDuplicate = BankFactory.GetBank("DNB");
		    accounts = bankDuplicate.GetAccounts();
		    Assert.AreEqual(2, accounts.Count);
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
