using System;
using Bazaar_Of_The_Bizarre.controller;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	internal class StatueDecorator : IStatue {
		private readonly IStatue _originalStatue;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="originalStatue">
		/// The original statue
		/// </param>
		protected StatueDecorator(IStatue originalStatue) {
			_originalStatue = originalStatue;
		}

		/// <summary>
		/// Gets the description of the statue
		/// </summary>
		/// <returns></returns>
		public virtual string GetDescription() {
			return _originalStatue.GetDescription();
		}

		/// <summary>
		/// Gets the price of the statue
		/// </summary>
		/// <returns></returns>
		public virtual double GetPrice() {
			return _originalStatue.GetPrice();
		}
		
		/// <summary>
		/// Checks if a decoration has been used in the description of the statue.
		/// </summary>
		/// <param name="decoration">
		/// The decoration that can be added
		/// </param>
		/// <param name="currentDescriptionOfStatue">
		/// The current description of the statue
		/// </param>
		/// <returns>
		/// True if the description has been used. 
		/// </returns>
		protected bool CheckIfDecorationHasBeenUsedInCurrentDescription(string decoration, string currentDescriptionOfStatue) {
			var currentDescription = currentDescriptionOfStatue.Split();
			var decorationHasBeenUsed = false;
			foreach (var currentDescribingWord in currentDescription)
				if (decoration.ToLower().Equals(currentDescribingWord.ToLower()))
					decorationHasBeenUsed = true;
			return decorationHasBeenUsed;
		}

		/// <summary>
		/// Gets a random description from the Enums
		/// </summary>
		/// <param name="typeOfDecoration">
		/// Type of decoration
		/// </param>
		/// <returns></returns>
		protected string GetRandomDecoration(string typeOfDecoration) {
			var decorationToBeAdded = "";

			switch (typeOfDecoration.ToLower()) {
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

		/// <summary>
		/// Gets a random sticker from the enum
		/// </summary>
		/// <returns>
		/// The random sticker
		/// </returns>
		private string GetRandomSticker() {
			var stickerValues = Enum.GetValues(typeof(Stickers));
			return stickerValues.GetValue(Client.Rnd.Next(stickerValues.Length)).ToString();
		}

		/// <summary>
		/// Gets a random color from the enum
		/// </summary>
		/// <returns>
		/// The random color
		/// </returns>
		private string GetRandomColor() {
			var colorValues = Enum.GetValues(typeof(Colors));
			return colorValues.GetValue(Client.Rnd.Next(colorValues.Length)).ToString();
		}

		/// <summary>
		/// Gets a random jewel from the enum
		/// </summary>
		/// <returns>
		/// The random jewel
		/// </returns>
		private string GetRandomJewel() {
			var jewelValues = Enum.GetValues(typeof(Jewels));
			return jewelValues.GetValue(Client.Rnd.Next(jewelValues.Length)).ToString();
		}

		/// <summary>
		/// Adds a decoration to the description
		/// </summary>
		/// <param name="currentDescription">
		/// The current description
		/// </param>
		/// <param name="decoration">
		/// Decoration to be added.
		/// </param>
		/// <returns></returns>
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