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
	        IStatue color = new ColorDecorator(statue);
	        IStatue color1 = new ColorDecorator(color);
	        IStatue color2 = new ColorDecorator(color1);
	        IStatue color3 = new ColorDecorator(color2);

			Console.WriteLine(color.GetDescription());
			Console.WriteLine(color1.GetDescription());
			Console.WriteLine(color2.GetDescription());
			Console.WriteLine(color3.GetDescription());
			IStatue armColor = new ArmsDecorator(color1Statue);


         

            Console.ReadKey();

        }
    }
}
