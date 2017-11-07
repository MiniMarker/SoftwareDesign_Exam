using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.statueDecorator{
	class StatueDecorator : IStatue
	{

		private readonly IStatue _originalStatue;

		protected StatueDecorator(IStatue originalStatue)
		{
			_originalStatue = originalStatue;
		}

		public virtual string GetDescription()
		{
			return _originalStatue.GetDescription();
		}

		public virtual double GetPrice()
		{
			return _originalStatue.GetPrice();
		}
	}
}
