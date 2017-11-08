using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;
using Bazaar_Of_The_Bizarre.StoreFacade;

namespace Bazaar_Of_The_Bizarre {
	class Program {
		public static void Main(string[] args) {
			/* var stuff = new Store();
			 var stuff1 = new Store();
			 var stuff2 = new Store();
			 var stuff3 = new Store();

			 stuff.GetShop("cheap");
			 stuff1.GetShop("expensive");
			 stuff2.GetShop("cheap");
			 stuff3.GetShop("expensive");

			 Console.WriteLine(stuff.Shop.GetName());
			 Console.WriteLine(stuff.Shop.GetPrice());
			 Console.WriteLine(stuff1.Shop.GetName(), stuff.Shop.GetPrice());
			 Console.WriteLine(stuff1.Shop.GetPrice());
			 Console.WriteLine(stuff2.Shop.GetName(), stuff.Shop.GetPrice());
			 Console.WriteLine(stuff2.Shop.GetPrice());
			 Console.WriteLine(stuff3.Shop.GetName(), stuff.Shop.GetPrice());
			 Console.WriteLine(stuff3.Shop.GetPrice());

			 Bank.BankFlyweight.Bank bank = Bank.BankFlyweight.BankFactory.GetBank("DnB");
			 Customer customer1 = new Customer(120893, "Ellen Elefsen");
			 bank.CreateAccount(customer1.GetSocialSecurityNumber());
			 Customer customer2 = new Customer(120194, "Kai Johnsen");
			 bank.CreateAccount(customer2.GetSocialSecurityNumber());
			 Customer customer3 = new Customer(230266, "Mats Toret");
			 bank.CreateAccount(customer3.GetSocialSecurityNumber());
			 */
			//
			//			var backroom = new Backroom();
			//			Console.WriteLine(backroom.CreateProduct(10).GetDescription());

			IStatue statue = new Statue();
			IStatue colorStatue = new ColorDecorator(statue);
			IStatue colorStatue1 = new ColorDecorator(colorStatue);
			IStatue colorStatue2 = new ColorDecorator(colorStatue1);
			IStatue colorStatue3 = new ColorDecorator(colorStatue2);
			IStatue colorStatue4 = new ColorDecorator(colorStatue3);

			IStatue stickerStatue = new StickerDecorator(statue);
			IStatue stickerStatue1 = new StickerDecorator(stickerStatue);
			IStatue stickerStatue2 = new StickerDecorator(stickerStatue1);
			IStatue stickerStatue3 = new StickerDecorator(stickerStatue2);


			Console.WriteLine(stickerStatue.GetDescription());
			Console.WriteLine(stickerStatue1.GetDescription());
			Console.WriteLine(stickerStatue2.GetDescription());
			Console.WriteLine(stickerStatue3.GetDescription());

			Console.WriteLine(colorStatue.GetDescription());
			Console.WriteLine(colorStatue1.GetDescription());
			Console.WriteLine(colorStatue2.GetDescription());
			Console.WriteLine(colorStatue3.GetDescription());
			Console.WriteLine(colorStatue4.GetDescription());

			Console.ReadKey();

		}
	}
}
