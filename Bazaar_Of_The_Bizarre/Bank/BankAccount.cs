using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre {
	class BankAccount
	{
	    public double Sum { get; private set; }

	    public BankAccount(double sum)
	    {
	        Sum = sum;
	    }

        // Withdrawal tries to subtract SumToWithdraw if there is enough funds.
        public bool Withdrawal(double SumToWithdraw)
	    {
            //If the sum is smaller or equal to current Sum, a withdrawal of sum is performed.
	        if (Sum >= SumToWithdraw)
	        {
	            Sum -= SumToWithdraw;
                Console.WriteLine("Withdrawal of {0} from account has been made. Current balance of account is {1} kr.", SumToWithdraw, Sum );
	            return true;
	        }
	        else
	        {
	            Console.WriteLine("Not enough funds. Withdrawal was cancelled.");
	            return false;
	        }
	    }
	}
}
