﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class JewelDecorator : StatueDecorator {


		public JewelDecorator(IStatue originalStatue) : base(originalStatue) {
		}

		public override double GetPrice() {
			return base.GetPrice() + 7.50;

		}

		public override string GetDescription() {
			var description = base.GetDescription();
			if (description.Equals("Statue"))
			{
				description = GetRandomDecoration("jewel") + " statue";
			}
			else
			{
				description = AddDecorationToDescription(description, "jewel");
			}
			return description;
		}

	}
}