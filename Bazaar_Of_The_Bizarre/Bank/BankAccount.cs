using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre {
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
				if(_sum >= sumToWithdraw) {
					_sum -= sumToWithdraw;
					Console.WriteLine(
						"Withdrawal of {0} from account has been made. Current balance of account is {1} kr.",
						sumToWithdraw, _sum);
					return true;
				}
				else {
					Console.WriteLine("Not enough funds. Withdrawal was cancelled.");
					return false;
				}
			}

		}
	}
}
