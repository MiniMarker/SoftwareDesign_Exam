using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.statueDecorator {

	class Statue : IStatue
	{

		private readonly string _description;
		private readonly double _price;

		public Statue(double price = 20.0, string description = "Statue")
		{
			_description = description;
			_price = price;
		}

		public virtual string GetDescription()
		{
			return _description;
		}

		public virtual double GetPrice()
		{
			return _price;
		}
	}
}
