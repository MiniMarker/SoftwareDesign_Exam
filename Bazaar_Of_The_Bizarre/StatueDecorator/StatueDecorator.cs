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

		protected string ReplaceAndWithSeparator(string description) {

			var fixedDescription = description;
			var descriptionWords = description.Split();
			var amountOfAnd = GetAmountOfAndInDescription(descriptionWords);
			
			if(amountOfAnd > 1)
			{
				fixedDescription = ReplaceAndWithComma(amountOfAnd, descriptionWords);
			}

			return fixedDescription;
		}

		protected string ReplaceAndWithComma(int amount, string[] descriptionWords)
		{
			var result = "";

			foreach(var word in descriptionWords) {
				if(word.Equals("and") && amount > 1) {
					result += ",";
					amount--;
				}
				else {
					if(word == descriptionWords[0]) {
						result += word;
					}
					else {
						result += " " + word;
					}
				}
			}
			return result;
		}

		protected int GetAmountOfAndInDescription(string[] descriptionWords)
		{
			var amount = 0;

			foreach(var words in descriptionWords) {
				if(words.Equals("and")) {
					amount++;
				}
			}

			return amount;
		}
	}
}
