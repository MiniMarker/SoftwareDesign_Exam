using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre.statueDecorator
{
	class ColorDecorator : StatueDecorator
	{


		public ColorDecorator(IStatue originalStatue) : base(originalStatue)
		{
		}

		public override double GetPrice()
		{
			return base.GetPrice() + 5.0;
		}

		public override string GetDescription()
		{
			var description = base.GetDescription();
			if (description.Equals("Statue"))
			{
				description = GetRandomDecoration("color") + " statue";
			}
			else
			{
				description = AddDecorationToDescription(description, "color");
			}
			return description;
		}
	}
}