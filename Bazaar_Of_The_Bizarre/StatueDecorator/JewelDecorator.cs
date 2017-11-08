using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre.statueDecorator
{
	class JewelDecorator : StatueDecorator
	{
		private readonly Random _random;

		public JewelDecorator(IStatue originalStatue) : base(originalStatue)
		{
			_random = new Random();
		}

		public override double GetPrice()
		{
			return base.GetPrice() + 7.50;

		}

		public override string GetDescription()
		{
			return base.GetDescription() + " with jewel(s) of " + GetRandomJewel();

			/*var description = base.GetDescription();

			if (description.Contains("jewel"))
			{
				description = "jewel of " + GetRandomJewel();
			}
			else
			{
				description = AddJewelToDecoratedStatue(description);
			}
			return description; */
		}

		public string GetRandomJewel()
		{
			var jewelList = Enum.GetValues(typeof(Jewels));
			return jewelList.GetValue(_random.Next(jewelList.Length)).ToString();
		}
		
		public string AddJewelToDecoratedStatue(string currentDescription)
		{
			var currentDescriptionWords = currentDescription.Split();

			var randomJewelToAddToDescription = GetRandomJewel();
			var revisedDescription = " ";
			var jewelIsAdded = false;

			while (!jewelIsAdded)
			{
				if (!CheckIfJewelHasBeenUsedInCurrentDescription(randomJewelToAddToDescription, currentDescription))
				{
					revisedDescription = randomJewelToAddToDescription;

					for (int i = 0; i < currentDescriptionWords.Length; i++)
					{
						if (Enum.IsDefined(typeof(Jewels), currentDescription[i]))
						{
							revisedDescription += " and";
						}
						currentDescriptionWords[i] = currentDescriptionWords[i].ToLower();
						jewelIsAdded = true;
					}
				}
				else
				{
					randomJewelToAddToDescription = GetRandomJewel();
				}
			}
			foreach (var word in currentDescriptionWords)
			{
				revisedDescription += " ";
			}
		}

		private bool CheckIfJewelHasBeenUsedInCurrentDescription(string randomJewelToAddToDescription, string currentDescription)
		{
			throw new NotImplementedException();
		}
	}
}
