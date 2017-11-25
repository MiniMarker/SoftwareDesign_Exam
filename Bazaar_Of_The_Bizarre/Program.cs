using System;
using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre {
	class Program {
		//TODO refactor program
		public static void Main(string[] args) {
		    var client = new Client(21);
		    client.RunGame();
            Console.ReadKey();
		}
	}
}
