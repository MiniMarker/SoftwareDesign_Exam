using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;

namespace Bazaar_Of_The_Bizarre {
	class Backroom
	{
		//private IStatue statue = new Statue();

		public void CreateProduct(int numberOfDecorations)
		{
			IStatue statue = new Statue();
			var random = new Random();

			for (var i = 0; i < numberOfDecorations; i++)
			{
				
				var value = random.Next(1, 4);

				switch (value)
				{
					//armsDecorator
					case 1:
						IStatue armDecoratedStatue = new ArmsDecorator(statue);
						statue = armDecoratedStatue;
						Console.WriteLine("1");
						break;

					//hatDecorator
					case 2:
						IStatue hatDecoratedStatue= new HatDecorator(statue);
						statue = hatDecoratedStatue;
						Console.WriteLine("2");
						break;
					
					//colorDecorator
					case 3:
						IStatue colorDecoratedStatue = new ColorDecorator(statue);
						statue = colorDecoratedStatue;
						Console.WriteLine("3");
						break;	
				}
			}
			Console.WriteLine(statue.GetDescription());
			//return statue;
		}
	}
}
