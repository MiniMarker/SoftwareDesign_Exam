using System;
using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre {
	class Program {

		public static void Main(string[] args) {
			var client = new Client(21);
			client.StartAllStoresThreads();

			//TODO Should customer shop until their money is gone? If then this need to be implemented.
			if(client.Bazaar.IsBazarOpen()) {
				client.StartAllCustomerThreads();
				//todo checking if bazar is open
				while(client.Bazaar.IsBazarOpen()) { }
			}

			client.EndOfDay();

			Console.WriteLine("Bazar is now closed.");

			Console.ReadKey();
		}
	}
}
