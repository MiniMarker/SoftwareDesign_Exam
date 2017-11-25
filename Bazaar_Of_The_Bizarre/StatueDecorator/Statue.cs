namespace Bazaar_Of_The_Bizarre.statueDecorator {
	internal class Statue : IStatue {
		private readonly string _description;
		private readonly double _price;

		/// <summary>
		///		Constructor for base Statue
		/// </summary>
		/// <param name="price">
		///		default 20.0
		/// </param>
		/// <param name="description">
		///		default = "Statue"
		/// </param>
		public Statue(double price = 20.0, string description = "Statue") {
			_description = description;
			_price = price;
		}

		public virtual string GetDescription() {
			return _description;
		}

		public virtual double GetPrice() {
			return _price;
		}
	}
}