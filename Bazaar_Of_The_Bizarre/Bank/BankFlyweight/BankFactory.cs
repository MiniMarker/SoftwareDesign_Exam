using System;
using System.Collections.Generic;

namespace Bazaar_Of_The_Bizarre.Bank.BankFlyweight {
	/// <summary>
	/// This class is a part of the design pattern flyweight. Due to that only one bank is created during the program, the implementation is not neccessary. Flyweight was implemented to show understanding of the specific design pattern.
	/// </summary>
	class BankFactory {
		private static readonly Dictionary<string, Bank> BankMap = new Dictionary<string, Bank>();

		/// <summary>
		///		Creates new bank if it does not exist and returns it. Otherwise existing bank is returned.
		/// </summary>
		/// <param name="name">
		///     Name of the bank
		/// </param>
		/// <returns>
		///     Bank Returns bank
		/// </returns>
		public static Bank GetBank(string name) {
			if(!BankMap.ContainsKey(name)) {
				BankMap.Add(name, new Bank(name));
			}
			return BankMap[name];
		}

		/// <summary>
		///		Prints out all banks.
		/// </summary>
		public static void PrintBanks() {
			foreach(var pair in BankMap) {
				Console.WriteLine("Name = {0}, Bank = {1}", pair.Key, pair.Value);
			}
		}
	}
}
