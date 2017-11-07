using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;

namespace Bazaar_Of_The_Bizarre {
	class Program {
		static void Main(string[] args) {
			IStatue statue = new Statue();
			IStatue cd = new ColorDecorator(statue);
			IStatue cd1 = new ColorDecorator(cd);
			IStatue cd2 = new ColorDecorator(cd1);

			Console.WriteLine(cd.GetDescription());
			Console.WriteLine(cd1.GetDescription());
			Console.WriteLine(cd2.GetDescription());
			Console.ReadKey();
		}
	}
}
