using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class StatueDecorator : IStatue {

		private readonly IStatue _originalStatue;
		private readonly Random _random;

		protected StatueDecorator(IStatue originalStatue) {
			_random = new Random();
			_originalStatue = originalStatue;
		}

		public virtual string GetDescription() {
			return _originalStatue.GetDescription();
		}

		public virtual double GetPrice() {
			return _originalStatue.GetPrice();
		}

		protected string ReplaceAndWithSeparator(string description) {

			var fixedDescription = description;
			var descriptionWords = description.Split();
			var amountOfAnd = GetAmountOfAndInDescription(descriptionWords);

			if(amountOfAnd > 1) {
				fixedDescription = ReplaceAndWithComma(amountOfAnd, descriptionWords);
			}

			return fixedDescription;
		}

		protected string ReplaceAndWithComma(int amount, string[] descriptionWords) {
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

		protected int GetAmountOfAndInDescription(string[] descriptionWords) {
			var amount = 0;

			foreach(var words in descriptionWords) {
				if(words.Equals("and")) {
					amount++;
				}
			}

			return amount;
		}

		protected bool CheckIfDecorationHasBeenUsedInCurrentDescription(string decoration, string currentDescriptionOfStatue) {
			var currentDescription = currentDescriptionOfStatue.Split(',', ' ', '-');
			var decorationHasBeenUsed = false;
			foreach(var currentDescribingWord in currentDescription) {
				if(decoration.ToLower().Equals(currentDescribingWord.ToLower())) {
					decorationHasBeenUsed = true;
				}
			}
			return decorationHasBeenUsed;
		}

		protected string GetRandomDecoration(string decoration) {
			var decorationToBeAdded = "";

			switch(decoration.ToLower()) {
				case "sticker":
					decorationToBeAdded = GetRandomSticker();
					break;
				case "color":
					decorationToBeAdded = GetRandomColor();
					break;
				case "jewel":
					break;
			}
			return decorationToBeAdded;
		}

		protected string GetRandomSticker() {
			var stickerValues = Enum.GetValues(typeof(Stickers));
			return stickerValues.GetValue(_random.Next(stickerValues.Length)).ToString();
		}

		protected string GetRandomColor() {
			var colorValues = Enum.GetValues(typeof(Colors));
			return colorValues.GetValue(_random.Next(colorValues.Length)).ToString();
		}

		protected string AddDecorationToDecoratedStatue(string currentDescription, string decoration) {
			var revisedDescription = "";

			switch(decoration) {
				case "color":
					revisedDescription = AddColorToDescription(currentDescription);
					break;
				case "sticker":
					break;
				case "jewel":
					break;
			}
			return revisedDescription;
		}

		protected string AddColorToDescription(string currentDescription) {
			var currentDescriptionWords = currentDescription.Split();
			var colorIsAdded = false;
			var decorationToBeAddedToDescription = GetRandomColor();

			var descriptionWithAddedDecoration = "";

			while(!colorIsAdded) {
				if(!CheckIfDecorationHasBeenUsedInCurrentDescription(decorationToBeAddedToDescription, currentDescription)) {
					descriptionWithAddedDecoration = decorationToBeAddedToDescription;
					currentDescriptionWords[0] = currentDescriptionWords[0].ToLower();
					colorIsAdded = true;
				}
				else {
					decorationToBeAddedToDescription = GetRandomColor();
				}

				descriptionWithAddedDecoration += " and";
			}

			foreach(var word in currentDescriptionWords) {
				descriptionWithAddedDecoration += " " + word;
			}

			return descriptionWithAddedDecoration;
		}

		protected string AddDecorationToDescription(string currentDescription, string decoration) {
			var currentDescriptionWords = currentDescription.Split();
			var decorationIsAdded = false;
			var decorationToBeAddedToDescription = GetRandomDecoration(decoration);

			var descriptionWithAddedDecoration = "";

			while(!decorationIsAdded) {
				if(!CheckIfDecorationHasBeenUsedInCurrentDescription(decorationToBeAddedToDescription, currentDescription)) {
					descriptionWithAddedDecoration = decorationToBeAddedToDescription;
					currentDescriptionWords[0] = currentDescriptionWords[0].ToLower();
					decorationIsAdded = true;
				}
				else
				{
					decorationToBeAddedToDescription = GetRandomDecoration(decoration);
				}
				descriptionWithAddedDecoration += GetEndingToDecorationInDescription(decoration);
			}

			foreach(var word in currentDescriptionWords) {
				descriptionWithAddedDecoration += " " + word;
			}

			return descriptionWithAddedDecoration;
		}

		//TODO Make decoration type
		private string GetEndingToDecorationInDescription(string decoration)
		{
			switch (decoration)
			{
				case "sticker":
					return "-sticker,";
				case "color":
					return " and";
				case "jewel":
					break;

			}
			return "";
		}
	}
}
