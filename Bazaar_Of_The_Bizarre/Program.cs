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
            IStatue statue = new Statue();
            IStatue arm1 = new ArmsDecorator(statue);
            IStatue arm2 = new ArmsDecorator(arm1);
            IStatue arm3 = new ArmsDecorator(arm2);
            IStatue arm4 = new ArmsDecorator(arm3);


            Console.WriteLine(statue.GetDescription());
            Console.WriteLine(statue.GetPrice());

            Console.WriteLine(arm1.GetDescription());
            Console.WriteLine(arm1.GetPrice());

            Console.WriteLine(arm2.GetDescription());
            Console.WriteLine(arm2.GetPrice());

            Console.WriteLine(arm3.GetDescription());
            Console.WriteLine(arm3.GetPrice());

            Console.WriteLine(arm4.GetDescription());
            Console.WriteLine(arm4.GetPrice());

            Console.ReadKey();

        }
    }
}
