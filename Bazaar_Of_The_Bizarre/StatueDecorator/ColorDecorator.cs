using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class ColorDecorator : StatueDecorator {

		private readonly Random _random = new Random();

		public ColorDecorator(IStatue originalStatue) : base(originalStatue) {
		}

		public override double GetPrice() {
			return base.GetPrice() + 5.0;
		}

		public override string GetDescription() {
			var description = base.GetDescription();
			if(description.Equals("Statue")) {
				description = GetRandomColor() + " statue";
			}
			else {
				description = AddColorToDecoratedStatue(description);
			}
			return description;
		}

		private string GetRandomColor() {
			Array colorValues = Enum.GetValues(typeof(Colors));
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

		private string AddColorToDecoratedStatue(string currentDescriptionOfStatue) {
			var currentDescriptionWords = currentDescriptionOfStatue.Split();
			var colorToBeAddedToDescription = GetRandomColor();
			var revisedDescription = "";
			var colorIsNotAdded = false;

			if(Enum.IsDefined(typeof(Colors), currentDescriptionWords[0])) {
				while(!colorIsNotAdded) {
					if(!CheckIfColorHasBeenUsedInCurrentDescription(colorToBeAddedToDescription, currentDescriptionOfStatue)) {
						revisedDescription = colorToBeAddedToDescription + " and";
						currentDescriptionWords[0] = currentDescriptionWords[0].ToLower();
						colorIsNotAdded = true;
					}
					else {
						colorToBeAddedToDescription = GetRandomColor();
					}
				}
			}

			foreach(var word in currentDescriptionWords) {
				Console.WriteLine(word);
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