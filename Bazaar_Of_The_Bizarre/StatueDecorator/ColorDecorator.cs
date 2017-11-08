using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class ColorDecorator : StatueDecorator {


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
				description = AddDecorationToDescription(description, "color");
			}
			return ReplaceAndWithSeparator(description);
		}

		

		//TODO Figure out how Decorator works.
/*		private string AddColorToDecoratedStatue(string currentDescription) {
			var currentDescriptionWords = currentDescription.Split();

			var colorToBeAddedToDescription = GetRandomColor();
			var revisedDescription = "";
			var colorIsAdded = false;

			while(!colorIsAdded) {
				if(!CheckIfDecorationHasBeenUsedInCurrentDescription(colorToBeAddedToDescription, currentDescription)) {
					revisedDescription = colorToBeAddedToDescription;
					currentDescriptionWords[0] = currentDescriptionWords[0].ToLower();
					colorIsAdded = true;
				}
				else {
					colorToBeAddedToDescription = GetRandomColor();
				}

				revisedDescription += " and";
			}


			foreach(var word in currentDescriptionWords) {
				revisedDescription += " " + word;
			}


			//			Console.WriteLine("Amount of colors used: " + CheckHowManyColorsAreUsedInCurrentDescription(revisedDescription));
			//			Console.WriteLine("Amount of colors used in old: " + CheckHowManyColorsAreUsedInCurrentDescription(currentDescription));
			return revisedDescription;
		}*/
//		//TODO can be more dynamic?
//		private bool CheckIfColorHasBeenUsedInCurrentDescription(string color, string currentDescriptionOfStatue) {
//			var currentDescription = currentDescriptionOfStatue.Split(',',' ');
//			var colorHasBeenUsed = false;
//			foreach(var currentDescribingWord in currentDescription) {
//				if(color.ToLower().Equals(currentDescribingWord.ToLower())) {
//					colorHasBeenUsed = true;
//				}
//			}
//			return colorHasBeenUsed;
//		}

		/*private string ReplaceAndWithSeparator(string description) {

			var fixedDescription = "";
			var counter = 0;
			var descriptionWords = description.Split();

			foreach(var words in descriptionWords) {
				if(words.Equals("and")) {
					counter++;
				}
			}

			if(counter > 1) {

				foreach(var word in descriptionWords) {
					if(word.Equals("and") && counter > 1) {
						fixedDescription += ",";
						counter--;
					}
					else {
						if(word == descriptionWords[0]) {
							fixedDescription += word;
						}
						else {
							fixedDescription += " " + word;
						}
					}
				}
			}
			else {
				fixedDescription = description;
			}


			return fixedDescription;
		}*/

		//		private int CheckHowManyColorsAreUsedInCurrentDescription(string currentDescriptionOfStatue) {
		//			char[] delimiters = { ',', ' ' };
		//			var currentDescription = currentDescriptionOfStatue.Split(delimiters);
		//			var counter = 0;
		//			foreach(var currentDescribingWord in currentDescription) {
		//				Console.WriteLine(currentDescribingWord);
		//				if(!currentDescribingWord.Equals(" ")) {
		//					if(Enum.IsDefined(typeof(Colors), currentDescribingWord.Substring(1, 2).ToUpper())) {
		//						counter++;
		//					}
		//				}
		//
		//			}
		//			return counter;
		//		}
	}
}