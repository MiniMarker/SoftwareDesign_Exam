using System;
using System.Collections.Generic;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre {
	sealed class PrintHandler {
		private static PrintHandler _instance;
		private static readonly object Lock = new object();
		private List<string> _stickerList;
		private List<string> _jewelList;
		private List<string> _colorList;

		/// <summary>
		/// Constructor
		/// </summary>
		private PrintHandler() {
		}

		/// <summary>
		/// Returns PrintHandler if there is none, if it already exists it returns it.
		/// </summary>
		/// <returns>PrintHandler Returns existing PrintHandler </returns>
		public static PrintHandler GetInstance() {
			if(_instance == null) {
				lock(Lock) {
					_instance = new PrintHandler();
				}
			}
			return _instance;
		}

		/// <summary>
		/// Sorts and returns a description of a statue
		/// </summary>
		/// <param name="statue">
		/// Statue to get description of
		/// </param>
		/// <returns>
		/// Sorted description of statue param
		/// </returns>
		public string SortAndRetrieveProductDescription(IStatue statue) {
			SortStatueDescription(statue.GetDescription());
			return FormatProductDescription();
		}

		/// <summary>
		/// Sorts the statue description
		/// </summary>
		/// <param name="description">
		/// The description to be sorted. 
		/// </param>
		public void SortStatueDescription(string description) {
			_stickerList = new List<string>();
			_jewelList = new List<string>();
			_colorList = new List<string>();

			var descriptionWords = description.Split();

			foreach(var word in descriptionWords) {
				if(Enum.IsDefined(typeof(Jewels), word)) {
					_jewelList.Add(word);
				}
				if(Enum.IsDefined(typeof(Stickers), word)) {
					_stickerList.Add(word);
				}
				if(Enum.IsDefined(typeof(Colors), word)) {
					_colorList.Add(word);
				}
			}

			if(_stickerList.Count == 0) {
				_stickerList.Add("none");
			}

			if(_jewelList.Count == 0) {
				_jewelList.Add("none");
			}
		}

		/// <summary>
		/// Formats the description of the product
		/// </summary>
		/// <returns>
		/// string formatted description
		/// </returns>
		public string FormatProductDescription() {
			var colors = FormatDecorations(_colorList);
			var jewels = FormatDecorations(_jewelList);
			var stickers = FormatDecorations(_stickerList);

			return $"{colors} Statue \n " + $"- 'Jewels': {jewels} \n " + $"- Stickers: {stickers}";
		}

		/// <summary>
		/// Formats the decorations to be printed
		/// based on how many decorations
		/// </summary>
		/// <param name="decorationList">
		/// Decorations to be formatted
		/// </param>
		/// <returns>
		/// string formatted decorations
		/// </returns>
		public string FormatDecorations(List<string> decorationList) {
			if(decorationList == null)
				return null;

			var decorationsFormatted = "";
			for(var i = 0; i < decorationList.Count; i++) {
				var toBeAddedToDescription = "";
				if(i == 0) {
					decorationsFormatted += decorationList[i].Substring(0, 1).ToUpper() + decorationList[i].Substring(1);

				}
				else {
					toBeAddedToDescription += decorationList[i];

				}

				if(decorationList.Count != 0) {
					if(decorationList.Count - i > 1 && i != 0) {
						decorationsFormatted += ", " + toBeAddedToDescription;
					}
					else if(decorationList.Count - i == 1 && !toBeAddedToDescription.Equals("")) {

						decorationsFormatted += " and " + toBeAddedToDescription;
					}
				}
			}
			return decorationsFormatted;
		}

	}
}
