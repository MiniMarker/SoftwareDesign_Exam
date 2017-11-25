using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bazaar_Of_The_Bizarre.StatueDecorator;

namespace Bazaar_Of_The_Bizarre.statueDecorator {
	class StickerDecorator : StatueDecorator {
        
		public StickerDecorator(IStatue originalStatue) : base(originalStatue) {
		
		}

		public override double GetPrice() {
			return base.GetPrice() + 3.50;
		}

		public override string GetDescription() {
			var description = base.GetDescription();
			if(description.Equals("Statue")) {
				description += " " + GetRandomDecoration("sticker");
			}
			else {
				description = AddDecorationToDescription(description, "sticker");
			}
			return description;
		}


		private string AddStickerToDecoratedStatue(string currentDescription) {
			var currentDescriptionWords = currentDescription.Split();
			foreach(var desc in currentDescriptionWords) {
				if(Enum.IsDefined(typeof(Stickers), desc)) {
				}
			}

			var revisedDescription = "";
			var stickerIsAdded = false;
			var stickerToBeAdded = GetRandomDecoration("sticker");


			while(!stickerIsAdded) {
				if(!CheckIfDecorationHasBeenUsedInCurrentDescription(stickerToBeAdded, currentDescription)) {

					stickerIsAdded = true;
				}
				else {
					stickerToBeAdded = GetRandomDecoration("sticker");
				}
			}
			//Sort all stickers out.
			//Add all colors first.
			//Then add stickers.
			//Then add jewels
			revisedDescription += "Statue with ";

			return revisedDescription;
		}

	}
}
