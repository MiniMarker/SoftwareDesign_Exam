using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class ArmsDecorator : StatueDecorator {

        private int numberOfArms;

        public ArmsDecorator(IStatue originalStatue) : base(originalStatue)
        {
	        this.numberOfArms = 0;
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 7.50;

        }

        public override string GetDescription()
        {
	        var desc = base.GetDescription();

	        if (!desc.Contains("arm(s)"))
	        {
				numberOfArms++;
		        desc = base.GetDescription() + " " + numberOfArms + " arm(s)";
			}
	        else
	        {
		        numberOfArms++;

			}
	        return desc;


	        /*var description = base.GetDescription();

	        if (!description.Contains("arm(s)"))
	        {
		        numberOfArms++;
		        description = base.GetDescription() + " " + numberOfArms + " arm(s)";

	        }
	        else
	        {
		        numberOfArms++;
	        }

			return description;*/
        }
    }
}
