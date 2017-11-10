using System;
using System.Collections.Generic;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre.StoreFacade
{
	class Backroom
	{
		private List<string> _stickerList;
		private List<string> _jewelList;
		private List<string> _colorList;

		private IStatue _statue = new Statue();
		private readonly Random _random = new Random();

		public IStatue CreateProduct(int numberOfDecorations)
		{
			for (var i = 0; i < numberOfDecorations; i++)
			{
				var value = _random.Next(1, 4);

				switch (value)
				{
					case 1:
						if (CanUseDecoration(_statue.GetDescription(), "jewel"))
						{
							IStatue jewelDecoratedStatue = new JewelDecorator(_statue);
							_statue = jewelDecoratedStatue;
							break;
						}
						i--;
						break;
					case 2:
						if (CanUseDecoration(_statue.GetDescription(), "sticker"))
						{
							IStatue stickerDecoratedStatue = new StickerDecorator(_statue);
							_statue = stickerDecoratedStatue;
							break;
						}
						i--;
						break;
					case 3:
						if (CanUseDecoration(_statue.GetDescription(), "color"))
						{
							IStatue colorDecoratedStatue = new ColorDecorator(_statue);
							_statue = colorDecoratedStatue;
							break;
						}
						i--;
						break;
				}
			}
			SortDescription(_statue.GetDescription());
			Console.WriteLine(PrintStatueDesc());
			return _statue;
		}

		public List<IStatue> CreateManyStatues(int numberOfStatuesToBeCreated)
		{
			List<IStatue> staueList = new List<IStatue>();

			for (var i = 0; i < numberOfStatuesToBeCreated; i++)
			{
				var numberOfDecorations = _random.Next(5, 10);

				CreateProduct(numberOfDecorations);
				_statue = new Statue();
			}
			return staueList;
		}

		private bool CanUseDecoration(string description, string decorationType)
		{
			if (GetAmountOfUsedDecorationsOfType(description, decorationType) < GetAmountOfPossibleDecorations(decorationType))
			{
				return true;
			}
			return false;
		}

		private int GetAmountOfPossibleDecorations(string decoration)
		{
			var possibleDecorations = 0;
			switch (decoration)
			{
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


		private int GetAmountOfUsedDecorationsOfType(string description, string decorationType)
		{
			var descriptionWords = description.Split();

			var amountOfStickers = 0;
			var amountOfJewels = 0;
			var amountOfColors = 0;


			foreach (var word in descriptionWords)
			{
				if (Enum.IsDefined(typeof(Stickers), word))
				{
					amountOfStickers++;
				}
				if (Enum.IsDefined(typeof(Colors), word))
				{
					amountOfColors++;
				}
				if (Enum.IsDefined(typeof(Jewels), word))
				{
					amountOfJewels++;
				}
			}

			switch (decorationType.ToLower())
			{
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
			string colors = "";
			string jewels = "";
			string stickers = "";

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
			return String.Format(
				"{0} Statue \n " +
				"- 'Jewels': {1} \n " +
				"- Stickers: {2}",
				colors, jewels, stickers); 
		}
	}
}