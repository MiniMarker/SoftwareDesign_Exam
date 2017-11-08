using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class StickerDecorator : StatueDecorator {


		public StickerDecorator(IStatue originalStatue) : base(originalStatue)
		{

		}

		public override double GetPrice()
		{
			return base.GetPrice() + 3.50;
		}

		public override string GetDescription()
		{
			var description = base.GetDescription();

			return description;
		}
	
	}
}
