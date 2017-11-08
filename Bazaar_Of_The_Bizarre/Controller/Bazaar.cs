using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade;

namespace Bazaar_Of_The_Bizarre.controller {
	class Bazaar
	{
	    private Dictionary<int, BankAccount> _accounts;

	    public Bazaar() {
            this._accounts = new Dictionary<int, BankAccount>();
        }

	    public IStatue GetProductFromStoreForCustomer(Store store)
	    {
		    return null;
	    }

	    public void CreateStore()
	    {

	    }
	}
}
