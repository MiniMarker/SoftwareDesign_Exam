namespace Bazaar_Of_The_Bizarre.statueDecorator {
	internal class JewelDecorator : StatueDecorator {
		/// <summary>
		///		Constructor
		/// </summary>
		/// <param name="originalStatue">
		///		Object of statue to be decorated
		/// </param>
		public JewelDecorator(IStatue originalStatue) : base(originalStatue) {
		}

		/// <summary>
		///		Adds expence to the base Statue
		/// </summary>
		/// <returns>
		///		Adds 7.5kr to the price of base.statue
		/// </returns>
		public override double GetPrice() {
			return base.GetPrice() + 7.50;
		}

		/// <summary>
		///		Adds a random jewel from enum by using a helpingmethod
		/// </summary>
		/// <returns>
		///		An updated description of statue with added description word to be formatted later
		/// </returns>
		public override string GetDescription() {
			var description = base.GetDescription();
			if(description.Equals("Statue"))
				description = GetRandomDecoration("jewel") + " statue";
			else
				description = AddDecorationToDescription(description, "jewel");
			return description;
		}
	}
}