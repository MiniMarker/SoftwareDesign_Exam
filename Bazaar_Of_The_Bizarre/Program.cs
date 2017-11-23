using System;
using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre {
	class Program {
        //TODO All randoms are refered to by Program.Rnd. Search for this when changing to Random.Rnd
	    public static readonly Random Rnd = new Random();

        public static void Main(string[] args) {
			var client = new Client(10);
            client.StartAllStoresThreads();

            //TODO Should customer shop until their money is none? If then this need to be implemented.
            while (client._bazaar.IsBazarOpen())
		    {
		        client.StartAllCustomerThreads();
            }

            client.EndOfDay();
           
            Console.WriteLine("Bazar is now closed.");

			Console.ReadKey();

		}
	}
}
