using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class StickerDecorator : StatueDecorator {
        
		public StickerDecorator(IStatue originalStatue) : base(originalStatue) {
		
		}

		public override double GetPrice() {
			return base.GetPrice() + 3.50;
		}

		public override string GetDescription() {
			var description = base.GetDescription();
			if(description.Equals("Statue")) {
				description += " " + GetRandomDecoration("sticker");
			}
			else {
				description = AddDecorationToDescription(description, "sticker");
			}
			return description;
		}
	}
}
