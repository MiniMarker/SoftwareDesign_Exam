using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre {
	class Client {
	    private Bank _bank { get; set; }
	    private Customer _Customer1 { get; set;}
	    private Customer _Customer2 { get; set; }
	    private Customer _Customer3 { get; set; }


        public Client()
	    {
            _bank = BankFactory.GetBank("DnB");
	        _Customer1 = new Customer(120893, "Ellen Elefsen");
	        _bank.CreateAccount(_Customer1.GetSocialSecurityNumber());
	        _Customer2 = new Customer(120194, "Kai Johnsen");
	        _bank.CreateAccount(_Customer2.GetSocialSecurityNumber());
            _Customer3 = new Customer(230266, "Mats Toret");
	        _bank.CreateAccount(_Customer3.GetSocialSecurityNumber());
        }


    }
}
