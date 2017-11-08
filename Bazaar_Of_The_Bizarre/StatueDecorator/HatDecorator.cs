using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class HatDecorator : StatueDecorator {

		private int numberOfHats = 0;

		public HatDecorator(IStatue originalStatue) : base(originalStatue)
		{

		}

		public override double GetPrice()
		{
			return base.GetPrice() + 3.50;
		}

		public override string GetDescription()
		{
			var description = base.GetDescription();

			if (!description.Contains("hat(s)"))
			{
				numberOfHats++;
				description = base.GetDescription() + " " + numberOfHats + " hat(s)";
			}
			else
			{
				numberOfHats++;
			}
			return description;
		}
		
		public void addArm()
		{
			//TODO FIX THIS PROBLEM!
		}
	}
}
