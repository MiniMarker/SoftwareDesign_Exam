using System;
using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre {
	class Program {
		public static void Main(string[] args) {
		    var client = new Client(35);
		    client.RunGame();
            Console.ReadKey();
		}
	}
}
