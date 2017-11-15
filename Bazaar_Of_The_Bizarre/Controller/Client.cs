using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre.controller {
	class Client
	{

		private readonly Bank.BankFlyweight.Bank _bank;
		private Bazaar _bazaar;

		private int CurrentSocialSecurityNumber;

		public Client()
		{
			CurrentSocialSecurityNumber = 1;
			_bank = BankFactory.GetBank("DNB");
			_bazaar = new Bazaar();
		}

		/**
		 * App has to run threads until customer has less money than x
		 * App has to run threads until stores are no longer open. 
		 * 
		 */
		public void StartAllCustomerThreads()
		{
			Thread[] threads = new Thread[10];
			Customer customer = new Customer(1,"Harald",_bank);

		}

		
	}
}
