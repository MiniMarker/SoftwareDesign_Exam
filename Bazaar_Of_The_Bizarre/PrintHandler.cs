using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre {
	class PrintHandler {

		private List<string> _stickerList;
		private List<string> _jewelList;
		private List<string> _colorList;

		public string SortAndRetrieveProductDescription(IStatue statue) {
			SortStatueDescription(statue.GetDescription());
			return FormatProductDescription();
		}

		private void SortStatueDescription(string description) {
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

		private string FormatProductDescription() {
			var colors = FormatDecorations(_colorList);
			var jewels = FormatDecorations(_jewelList);
			var stickers = FormatDecorations(_stickerList);

			return $"{colors} Statue \n " + $"- 'Jewels': {jewels} \n " + $"- Stickers: {stickers}";
		}

		private string FormatDecorations(List<string> decorationList) {
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
