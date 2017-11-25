using System;
using Bazaar_Of_The_Bizarre.controller;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	internal class StatueDecorator : IStatue {
		private readonly IStatue _originalStatue;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="originalStatue">
        ///     Object of statue to be decorated
        /// </param>
		protected StatueDecorator(IStatue originalStatue) {
			_originalStatue = originalStatue;
		}
        //TODO xml
        /// <summary>
        ///      Returns description of statue
        /// </summary>
        /// <returns>
        ///     String that is the description
        /// </returns>
		public virtual string GetDescription() {
			return _originalStatue.GetDescription();
		}

	    /// <summary>
	    ///      Returns price of statue
	    /// </summary>
	    /// <returns>
	    ///     double that is the price
	    /// </returns>
        public virtual double GetPrice() {
			return _originalStatue.GetPrice();
		}
		
		protected bool CheckIfDecorationHasBeenUsedInCurrentDescription(string decoration, string currentDescriptionOfStatue) {
			var currentDescription = currentDescriptionOfStatue.Split();
			var decorationHasBeenUsed = false;
			foreach (var currentDescribingWord in currentDescription)
				if (decoration.ToLower().Equals(currentDescribingWord.ToLower()))
					decorationHasBeenUsed = true;
			return decorationHasBeenUsed;
		}

		protected string GetRandomDecoration(string decoration) {
			var decorationToBeAdded = "";

			switch (decoration.ToLower()) {
				case "sticker":
					decorationToBeAdded = GetRandomSticker();
					break;
				case "color":
					decorationToBeAdded = GetRandomColor();
					break;
				case "jewel":
					decorationToBeAdded = GetRandomJewel();
					break;
			}
			return decorationToBeAdded;
		}

		private string GetRandomSticker() {
			var stickerValues = Enum.GetValues(typeof(Stickers));
			return stickerValues.GetValue(Client.Rnd.Next(stickerValues.Length)).ToString();
		}

		private string GetRandomColor() {
			var colorValues = Enum.GetValues(typeof(Colors));
			return colorValues.GetValue(Client.Rnd.Next(colorValues.Length)).ToString();
		}

		private string GetRandomJewel() {
			var jewelValues = Enum.GetValues(typeof(Jewels));
			return jewelValues.GetValue(Client.Rnd.Next(jewelValues.Length)).ToString();
		}

		protected string AddDecorationToDescription(string currentDescription, string decoration) {
			var currentDescriptionWords = currentDescription.Split();
			var decorationIsAdded = false;
			var decorationToBeAddedToDescription = GetRandomDecoration(decoration);

			var descriptionWithAddedDecoration = "";

			while (!decorationIsAdded)
				if (!CheckIfDecorationHasBeenUsedInCurrentDescription(decorationToBeAddedToDescription, currentDescription)) {
					descriptionWithAddedDecoration = decorationToBeAddedToDescription;
					decorationIsAdded = true;
				} else {
					decorationToBeAddedToDescription = GetRandomDecoration(decoration);
				}

			foreach (var word in currentDescriptionWords)
				descriptionWithAddedDecoration += " " + word;

			return descriptionWithAddedDecoration;
		}
	}
}