using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre {
	class BankAccount
	{
<<<<<<< Updated upstream
	    public double Sum { get; private set; }
=======
<<<<<<< Updated upstream
	    private double _sum { get; set; }
>>>>>>> Stashed changes

	    public BankAccount(double sum)
=======
	    private int _sum { get; set; }
	    private readonly Object _lock = new Object();



        public BankAccount(int sum)
>>>>>>> Stashed changes
	    {
	        Sum = sum;
	    }

        // Withdrawal tries to subtract SumToWithdraw if there is enough funds.
        public bool Withdrawal(double SumToWithdraw)
	    {
<<<<<<< Updated upstream
            //If the sum is smaller or equal to current Sum, a withdrawal of sum is performed.
	        if (Sum >= SumToWithdraw)
	        {
	            Sum -= SumToWithdraw;
                Console.WriteLine("Withdrawal of {0} from account has been made. Current balance of account is {1} kr.", SumToWithdraw, Sum );
	            return true;
	        }
	        else
=======
            //If the sum is smaller or equal to current _sum, a withdrawal of sum is performed
	        lock (_lock)
>>>>>>> Stashed changes
	        {
	            if (_sum >= SumToWithdraw)
	            {
	                _sum -= SumToWithdraw;
	                Console.WriteLine("Withdrawal of {0} from account has been made. Current balance of account is {1} kr.", SumToWithdraw, _sum);
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
}
