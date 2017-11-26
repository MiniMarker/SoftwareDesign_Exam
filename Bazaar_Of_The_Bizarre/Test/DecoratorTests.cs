using System;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StatueDecorator;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;

namespace Bazaar_Of_The_Bizarre.Test {
	[TestFixture]
	public class DecoratorTests {
		private readonly IStatue _baseStatue = new Statue();
		private string[] _descriptionWords;

		[Test]
		public void DecorateProductWithColorTest() {
			IStatue colorBaseStatue = new ColorDecorator(_baseStatue);

			_descriptionWords = colorBaseStatue.GetDescription().Split();

			//Color will be added before the word "Statue"
			Assert.IsTrue(Enum.IsDefined(typeof(Colors), _descriptionWords[0]));
		}

		[Test]
		public void DecorateProductWithStickerTest() {
			IStatue stickerBaseStatue = new StickerDecorator(_baseStatue);

			_descriptionWords = stickerBaseStatue.GetDescription().Split();

			//Sticker will be added after the word "Statue"
			Assert.IsTrue(Enum.IsDefined(typeof(Stickers), _descriptionWords[1]));
		}

		[Test]
		public void DecorateProductWithJewelTest() {
			IStatue jewelBaseStatue = new JewelDecorator(_baseStatue);

			_descriptionWords = jewelBaseStatue.GetDescription().Split();

			//Jewel will be added before the word "Statue"
			Assert.IsTrue(Enum.IsDefined(typeof(Jewels), _descriptionWords[0]));
		}
	}
}