using System;
using System.Collections.Generic;
using Bazaar_Of_The_Bizarre.controller;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre.StoreFacade {
	class Backroom {

		/// <summary>
		///     Creates a product and returns it
		/// </summary>
		/// <param name="numberOfDecorations">
		///     How many decorations to have on statue
		/// </param>
		/// <returns>
		///     IStatue Returns a product
		/// </returns>
		public IStatue CreateProduct(int numberOfDecorations) {
			IStatue statue = new Statue();

			for(var i = 0; i < numberOfDecorations; i++) {
				var value = Client.Rnd.Next(1, 4);

				switch(value) {
					case 1:
						if(CanUseDecoration(statue.GetDescription(), "jewel")) {
							var jewelDecoratedStatue = new JewelDecorator(statue);
							statue = jewelDecoratedStatue;
							break;
						}
						i--;
						break;
					case 2:
						if(CanUseDecoration(statue.GetDescription(), "sticker")) {
							var stickerDecoratedStatue = new StickerDecorator(statue);
							statue = stickerDecoratedStatue;
							break;
						}
						i--;
						break;
					case 3:
						if(CanUseDecoration(statue.GetDescription(), "color")) {
							var colorDecoratedStatue = new ColorDecorator(statue);
							statue = colorDecoratedStatue;
							break;
						}
						i--;
						break;
				}
			}
			return statue;
		}

		/// <summary>
		/// Creates multiple products and returns it in a list
		/// </summary>
		/// <param name="numberOfStatuesToBeCreated">
		///     How many statues to be created
		/// </param>
		/// <returns>
		///     List Returns a list with products
		/// </returns>
		public List<IStatue> CreateMultipleStatues(int numberOfStatuesToBeCreated) {
			var statueList = new List<IStatue>();

			for(var i = 0; i < numberOfStatuesToBeCreated; i++) {
				var numberOfDecorations = Client.Rnd.Next(5, 9);
				var product = CreateProduct(numberOfDecorations);
				statueList.Add(product);
			}
			return statueList;
		}

        /// <summary>
        ///     Checks if there is more of a specific decoration type available
        /// </summary>
        /// <param name="description">
        ///     Description for the statue
        /// </param>
        /// <param name="decorationType">
        ///     The type to check available decoration types
        /// </param>
        /// <returns>
        ///     Returns true if there are more available decoration types
        /// </returns>
		private bool CanUseDecoration(string description, string decorationType)
        {
            if (GetAmountOfUsedDecorationsOfType(description, decorationType) < GetAmountOfPossibleDecorations(decorationType))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Checks how many available decorations there are
        /// </summary>
        /// <param name="decoration">
        ///     If the decoration is a sticker, jewels or color.
        /// </param>
        /// <returns>
        ///     Returns an int how how many available decorations for each type.
        /// </returns>
		private int GetAmountOfPossibleDecorations(string decoration) {
			var possibleDecorations = 0;
			switch(decoration) {
				case "sticker":
					possibleDecorations = Enum.GetValues(typeof(Stickers)).Length;
					break;
				case "color":
					possibleDecorations = Enum.GetValues(typeof(Colors)).Length;
					break;
				case "jewel":
					possibleDecorations = Enum.GetValues(typeof(Jewels)).Length;
					break;
			}
			return possibleDecorations;
		}

        /// <summary>
        ///     Checks how many decoration of a specific type a statue has
        /// </summary>
        /// <param name="description">
        ///     The statues description
        /// </param>
        /// <param name="decorationType">
        ///     The type of decoration to check how many occurences there are
        /// </param>
        /// <returns>
        ///     Returns int that is how many times a decoration on a statue is occuring
        /// </returns>
		private int GetAmountOfUsedDecorationsOfType(string description, string decorationType) {
			var descriptionWords = description.Split();

			var amountOfStickers = 0;
			var amountOfJewels = 0;
			var amountOfColors = 0;


			foreach(var word in descriptionWords) {
				if(Enum.IsDefined(typeof(Stickers), word)) {
					amountOfStickers++;
				}
				if(Enum.IsDefined(typeof(Colors), word)) {
					amountOfColors++;
				}
				if(Enum.IsDefined(typeof(Jewels), word)) {
					amountOfJewels++;
				}
			}

			switch(decorationType.ToLower()) {
				case "sticker":
					return amountOfStickers;
				case "color":
					return amountOfColors;
				case "jewel":
					return amountOfJewels;
				default:
					return 0;
			}
		}

	}
}