using System;
using System.Collections.Generic;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre.StoreFacade
{
	class Backroom
	{


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
			return _statue;
		}

		public List<IStatue> CreateMultipleStatues(int numberOfStatuesToBeCreated)
		{
			var staueList = new List<IStatue>();

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

	}
}