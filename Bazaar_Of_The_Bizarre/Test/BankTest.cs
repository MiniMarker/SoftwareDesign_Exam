using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;

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
		    DnB.CreateAccount(009);

		    Assert.AreEqual(DnB.getAccounts().Count, 2);
	    }

		[Test]
	    public void TestWithdrawal()
	    {
			var DnB = BankFactory.GetBank("DnB");

		    DnB.CreateAccount(007);

		    Assert.IsTrue(DnB.Transaction(1, 1));


		}

       /* static void Main(string[] args)
       {
            //Tries to create two banks with same name.
            Bank pBank = BankFactory.GetBank("pBanki");
            Bank pBank1 = BankFactory.GetBank("pBanki");

            //Prints out all banks to check if BankFactory works properly.
            BankFactory.PrintBanks();

     

            //Registers values to bank.
            pBank.Customers(2323)
            pBank.Capital(1000);
            pBank.HandelingCustomer();
            
            //Creates two accounts with same name.
            pBank.CreateAccount(2323);
            pBank.CreateAccount(2323);

            //Prints out all accounts to check that CreateAccount() works properly.
            pBank.PrintAccounts();
       
            //Checks if possible to withdraw sum from account.
            pBank.Transaction(1, 2323);

            //Checks that no transaction can be bigger than current fund.
            pBank.Transaction(10000, 2323);

            Console.ReadKey();
       }*/
    }
}
