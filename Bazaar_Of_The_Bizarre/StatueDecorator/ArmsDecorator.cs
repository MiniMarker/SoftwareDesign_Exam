using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class ArmsDecorator : StatueDecorator {
		protected ArmsDecorator(IStatue originalStatue) : base(originalStatue)
		{

		}
	}
}
