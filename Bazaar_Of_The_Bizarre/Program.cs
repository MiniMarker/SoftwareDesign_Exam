using System;
using Bazaar_Of_The_Bizarre.controller;

namespace Bazaar_Of_The_Bizarre {
	class Program {

		/// <summary>
		///		main - Responsible for starting the application
		/// </summary>
		public static void Main(string[] args) {
		    var client = new Client(35);
		    client.StartBazaar();
            Console.ReadKey();
		}
	}
}
