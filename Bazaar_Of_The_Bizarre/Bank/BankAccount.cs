using System;

namespace Bazaar_Of_The_Bizarre.Bank {
	class BankAccount {
		private double _sum { get; set; }
		private readonly Object _lock = new Object();

		public BankAccount(double sum) {
			_sum = sum;
		}

		// Withdrawal tries to subtract sumToWithdraw if there is enough funds.
		public bool Withdrawal(double sumToWithdraw) {
			//If the sum is smaller or equal to current Sum, a withdrawal of sum is performed.
			lock(_lock) {
				if(_sum >= sumToWithdraw)
				{
				    _sum -= sumToWithdraw;
					return true;
				}
				else {
					return false;
				}
			}

		}

        //Returns sum of the account.
	    public double GetSum()
	    {
	        return _sum;
	    }
	}
}
