using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;

namespace Bazaar_Of_The_Bizarre {
	class Program {
        public static void Main(string[] args)
        {
			var backroom = new Backroom();

	        backroom.CreateProduct(20);


	        /*
            IStatue statue = new Statue();
            IStatue arm1 = new ArmsDecorator(statue);
            IStatue arm2 = new ArmsDecorator(arm1);
            IStatue arm3 = new ArmsDecorator(arm2);
            IStatue arm4 = new ArmsDecorator(arm3);
            IStatue arm5 = new ArmsDecorator(arm4);

	        
	        IStatue arm4hat1 = new HatDecorator(arm4);
            
	        IStatue arm4hat2 = new HatDecorator(arm4hat1);

            IStatue arm5hat2 = new ArmsDecorator(arm4hat2);

            IStatue arm5hat3 = new HatDecorator(arm5hat2);
            
			//IStatue arm4hat1 = new HatDecorator(arm4);
			//IStatue arm4hat2 = new HatDecorator(arm4hat1);


			Console.WriteLine(statue.GetDescription());
            

            Console.WriteLine(arm1.GetDescription());
            

            Console.WriteLine(arm2.GetDescription());
	       

            Console.WriteLine(arm3.GetDescription());

            Console.WriteLine(arm4.GetDescription());
            
			Console.WriteLine(arm5.GetDescription());

			
			Console.WriteLine(arm4hat1.GetDescription());

	        /*Console.WriteLine(arm5hat2.GetDescription());

	        Console.WriteLine(arm5hat3.GetDescription());
	        */

			Console.ReadKey();

        }
    }
}
