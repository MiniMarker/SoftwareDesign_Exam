using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				description = getRandomColor() + " statue";
			}
			else
			{
				description = AddColorToDecoratedStatue();
			}
			return description;
		}

		private string getRandomColor()
		{
			var rnd = new Random();
			Array colorValues = Enum.GetValues(typeof(Colors));
			return colorValues.GetValue(rnd.Next(colorValues.Length)).ToString();
		}

		private enum Colors
		{
			Green,
			Red,
			Blue,
			Black,
			Yellow,
			Orange
		}

		private string AddColorToDecoratedStatue()
		{
			var currentDescription = base.GetDescription().Split();

			var revisedDescription = getRandomColor() + " ";
			if (Enum.IsDefined(typeof(Colors), currentDescription[0]))
			{
				revisedDescription += "and ";
				currentDescription[0] = currentDescription[0].ToLower();
			}

			foreach (var word in currentDescription)
			{
				revisedDescription = revisedDescription + " " + word;
			}

			return revisedDescription;
		}


		private bool checkIfColorHasBeenUsedInCurrentDescription(String color)
		{
			var currentDescription = base.GetDescription().Split();
			bool colorHasBeenUsed = false;
			foreach (var descriptiveWord in currentDescription)
			{
				if (Enum.IsDefined(typeof(Colors), descriptiveWord))
				{

				}
			}
			return colorHasBeenUsed;
		}
	}
}