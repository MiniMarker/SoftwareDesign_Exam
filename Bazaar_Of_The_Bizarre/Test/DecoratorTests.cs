using System;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StatueDecorator;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;

namespace Bazaar_Of_The_Bizarre.Test
{
	[TestFixture]
	public class DecoratorTests
	{

		[Test]
		public void DecorateProduct()
		{
			IStatue baseStatue = new Statue();
			IStatue colorBaseStatue = new ColorDecorator(baseStatue);
			IStatue colorStickerBaseStatue = new StickerDecorator(colorBaseStatue);
			IStatue colorStickerJewelBaseStatue = new JewelDecorator(colorStickerBaseStatue);

			Assert.IsFalse(colorStickerJewelBaseStatue.GetDescription().Contains("blue"));
		}

	}
}