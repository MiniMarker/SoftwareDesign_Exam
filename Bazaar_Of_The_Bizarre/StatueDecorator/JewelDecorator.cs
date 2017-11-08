using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class JewelDecorator : StatueDecorator {

		private int _numberOfArms;

		public JewelDecorator(IStatue originalStatue) : base(originalStatue) {
			this._numberOfArms = 0;
		}

		public override double GetPrice() {
			return base.GetPrice() + 7.50;

		}

		public override string GetDescription() {
			var desc = base.GetDescription();

			return desc;


		}

	}
}
