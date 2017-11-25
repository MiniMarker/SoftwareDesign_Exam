namespace Bazaar_Of_The_Bizarre.statueDecorator {

	internal class StickerDecorator : StatueDecorator {

		/// <summary>
		///		Empty Constructor
		/// </summary>
		/// <param name="originalStatue">
		///		Object of statue to be decorated
		/// </param>
		public StickerDecorator(IStatue originalStatue) : base(originalStatue) {
		}

		/// <summary>
		///		Adds expence to the base Statue
		/// </summary>
		/// <returns>
		///		Adds 3,5kr to the price of base.statue
		/// </returns>
		public override double GetPrice() {
			return base.GetPrice() + 3.50;
		}

		/// <summary>
		///     Adds a random color from enum by using a helpingmethod
		/// </summary>
		/// <returns>
		///     An updated description of statue with added description word to be formatted later
		/// </returns>
		public override string GetDescription() {
			var description = base.GetDescription();
			if (description.Equals("Statue")) description += " " + GetRandomDecoration("sticker");
			else description = AddDecorationToDescription(description, "sticker");
			return description;
		}
	}
}