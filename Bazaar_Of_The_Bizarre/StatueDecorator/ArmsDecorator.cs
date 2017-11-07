using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class ArmsDecorator : StatueDecorator {

        private int numberOfArms = 0;

        public ArmsDecorator(IStatue originalStatue) : base(originalStatue)
        {

        }

        public override double GetPrice()
        {
            return base.GetPrice() + 7.50;

        }

        public override string GetDescription()
        {
            var description = base.GetDescription();

            if (!description.Contains("arm(s)"))
            {
                numberOfArms++;
                description =  base.GetDescription() + " " + numberOfArms + " arm(s)";

            }
            return description;
        }
    }
}
