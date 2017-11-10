using System;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre.StoreFacade
{
	class Backroom
	{
		IStatue statue = new Statue();

		public IStatue CreateProduct(int numberOfDecorations)
		{
			var random = new Random();
			var numberOfColorsChosen = 0;

			for (var i = 0; i < numberOfDecorations; i++)
			{
				var value = random.Next(1, 4);

				switch (value)
				{
					//armsDecorator
					case 1:
						IStatue armDecoratedStatue = new JewelDecorator(statue);
						this.statue = armDecoratedStatue;
						//Console.WriteLine("1");
						break;

					//hatDecorator
					case 2:
						IStatue hatDecoratedStatue = new StickerDecorator(statue);
						this.statue = hatDecoratedStatue;
						//Console.WriteLine("2");
						break;

					//colorDecorator
					case 3:
						//Console.WriteLine("3");
						IStatue colorDecoratedStatue = new ColorDecorator(statue);
						this.statue = colorDecoratedStatue;
						numberOfColorsChosen++;
						break;
				}
			}
			return statue;
		}
	}
}