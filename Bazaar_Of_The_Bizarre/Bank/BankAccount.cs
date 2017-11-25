using System;

namespace Bazaar_Of_The_Bizarre.Bank {
	class BankAccount {
		private double Sum { get; set; }
		private readonly Object _lock = new Object();

		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="sum">
		///     Sum on account
		/// </param>
		public BankAccount(double sum) {
			Sum = sum;
		}

		/// <summary>
		///     Withdrawal tries to subtract sumToWithdraw if there is enough funds.
		/// </summary>
		/// <param name="sumToWithdraw">
		///     Sum to withdraw from account
		/// </param>
		/// <returns>
		///     Boolean Returns true if withdrawal was made
		/// </returns>
		public bool Withdrawal(double sumToWithdraw) {
			//If the sum is smaller or equal to current Sum, a withdrawal of sum is performed.
			lock(_lock) {
				if(Sum >= sumToWithdraw) {
					Sum -= sumToWithdraw;
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///     Returns sum of the account.
		/// </summary>
		/// <returns>
		///     Double Returns current sum of account.
		/// </returns>
		public double GetSum() {
			return Sum;
		}
	}
}
