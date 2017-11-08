using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class StickerDecorator : StatueDecorator {

		private readonly Random _random;

		public StickerDecorator(IStatue originalStatue) : base(originalStatue)
		{
			_random = new Random();	
		}

		public override double GetPrice()
		{
			return base.GetPrice() + 3.50;
		}

		public override string GetDescription()
		{
			var description = base.GetDescription();
			if (description.Equals("Statue"))
			{
				description = GetRandomSticker() + " statue";
			}
			else
			{
				
			}
			return description;
		}

		//
		//		private String AddStickerToDecoratedStatue(string currentDescription)
		//		{
		//			var currentDescriptionWords = currentDescription.Split();
		//
		//			var colorToBeAddedToDescription = GetRandomColor();
		//			var revisedDescription = "";
		//			var stickerIsAdded = false;
		//			return null;
		//		}

	}
}
