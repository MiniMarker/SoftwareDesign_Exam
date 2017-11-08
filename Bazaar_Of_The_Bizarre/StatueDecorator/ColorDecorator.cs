using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class ColorDecorator : StatueDecorator
	{

		private readonly Random _random;

		public ColorDecorator(IStatue originalStatue) : base(originalStatue) {
			_random = new Random();
		}

		public override double GetPrice() {
			return base.GetPrice() + 5.0;
		}

		public override string GetDescription() {
			var description = base.GetDescription();
			Console.WriteLine("Base description: "+description);
			if(description.Equals("Statue")) {
				description = GetRandomColor() + " statue";
			}
			else {
				description = AddColorToDecoratedStatue(description);
			}
			return description;
		}

		private string GetRandomColor() {
			var colorValues = Enum.GetValues(typeof(Colors));
			return colorValues.GetValue(_random.Next(colorValues.Length)).ToString();
		}

		private enum Colors {
			Green,
			Red,
			Blue,
			Black,
			Yellow,
			Orange
		}
		//TODO Figure out how Decorator works.
		private string AddColorToDecoratedStatue(string currentDescriptionOfStatueOfNewStatue)
		{
			var currentDescriptionWords = currentDescriptionOfStatueOfNewStatue.Split();

			var colorToBeAddedToDescription = GetRandomColor();
			var revisedDescription = "";
			var colorIsAdded = false;

			while (!colorIsAdded)
			{
				if (!CheckIfColorHasBeenUsedInCurrentDescription(colorToBeAddedToDescription, currentDescriptionOfStatueOfNewStatue))
				{
					revisedDescription = colorToBeAddedToDescription;
					if (Enum.IsDefined(typeof(Colors), currentDescriptionWords[0]))
					{
						revisedDescription += " and";
					}
					currentDescriptionWords[0] = currentDescriptionWords[0].ToLower();
					colorIsAdded = true;
				}
				else
				{
					colorToBeAddedToDescription = GetRandomColor();
				}
			}
			foreach (var word in currentDescriptionWords)
			{
				revisedDescription += " " + word;
			}

			return revisedDescription;
		}

		private bool CheckIfColorHasBeenUsedInCurrentDescription(string color, string currentDescriptionOfStatue) {
			var currentDescription = currentDescriptionOfStatue.Split();
			var colorHasBeenUsed = false;
			foreach(var currentDescribingWord in currentDescription) {
				if(color.ToLower().Equals(currentDescribingWord.ToLower())) {
					colorHasBeenUsed = true;
				}
			}
			return colorHasBeenUsed;
		}
	}
}