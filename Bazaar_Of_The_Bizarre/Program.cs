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

			IStatue colorStatue = new ColorDecorator(arm1);
			IStatue color1Statue = new ColorDecorator(statue);

			IStatue armColor = new ArmsDecorator(color1Statue);

			Console.WriteLine(colorStatue.GetDescription());

         

            Console.ReadKey();

        }
    }
}
