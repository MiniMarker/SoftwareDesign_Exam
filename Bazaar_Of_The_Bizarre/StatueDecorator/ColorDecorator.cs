using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				description = getRandomColor() + " statue";
			}
			else {
				try
				{
					description = AddColorToDecoratedStatue();
				}
				catch (StackOverflowException e)
				{
					Console.Write(e.StackTrace);
				}
			}
			return description;
		}

		private string getRandomColor() {
			var rnd = new Random();
			Array colorValues = Enum.GetValues(typeof(Colors));
			return colorValues.GetValue(rnd.Next(colorValues.Length)).ToString();
		}

		private enum Colors {
			Green,
			Red,
			Blue,
			Black,
			Yellow,
			Orange
		}

		//Method to check if method contains anything from enum. if it does,
		//make the previous color start with a lower-case letter and add this + and

		private string AddColorToDecoratedStatue() {
			var currentDescription = GetDescription().Split();

			var revisedDescription = getRandomColor() + " ";
			Console.WriteLine(currentDescription[0]);
			if(Enum.IsDefined(typeof(Colors), currentDescription[0])) {
				revisedDescription += "and ";
				currentDescription[0] = currentDescription[0].ToLower();
			}

			foreach(var word in currentDescription) {
				revisedDescription += word;
			}

			return revisedDescription;
		}

	}
}
