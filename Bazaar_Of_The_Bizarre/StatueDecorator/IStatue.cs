using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	interface IStatue
	{
		string GetDescription();
		double GetPrice();
		string ToString();
	}
}
