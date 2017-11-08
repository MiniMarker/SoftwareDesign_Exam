using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade;

namespace Bazaar_Of_The_Bizarre {
	class Program {
        public static void Main(string[] args)
        {
	        var stuff = new Store();
	        stuff.GetShop();

			Console.WriteLine(stuff.Shop.GetName());
			
            Console.ReadKey();

        }
    }
}
