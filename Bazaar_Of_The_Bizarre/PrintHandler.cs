using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre {
	class PrintHandler
	{
	
		private List<string> _stickerList;
		private List<string> _jewelList;
		private List<string> _colorList;

		public void SortDescription(string description)
		{
			_stickerList = new List<string>();
			_jewelList = new List<string>();
			_colorList = new List<string>();

			var descriptionWords = description.Split();

			foreach (var word in descriptionWords)
			{
				if (Enum.IsDefined(typeof(Jewels), word))
				{
					_jewelList.Add(word);
				}

				if (Enum.IsDefined(typeof(Stickers), word))
				{
					_stickerList.Add(word);
				}
				if (Enum.IsDefined(typeof(Colors), word))
				{
					_colorList.Add(word);
				}
			}
		}

		private string PrintStatueDesc()
		{
			var colors = "";
			var jewels = "";
			var stickers = "";

			foreach (var color in _colorList)
			{
				colors += color + ", ";
			}

			foreach (var jewel in _jewelList)
			{
				jewels += jewel + " ,";
			}

			foreach (var sticker in _stickerList)
			{
				stickers += sticker + ", ";
			}
			return $"{colors} Statue \n " + $"- 'Jewels': {jewels} \n " + $"- Stickers: {stickers}";
		}
	}
}
