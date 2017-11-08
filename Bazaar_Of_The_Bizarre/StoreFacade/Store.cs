using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Bazaar_Of_The_Bizarre.statueDecorator;

namespace Bazaar_Of_The_Bizarre {
	class Store
    {
         IShop _shop { get; set; }
         Backroom Backroom { get; set; }
         String Name { get; set; }
         int Quota { get; set; }
         List<Statue> _products { get; set; }

   
        public Statue RecieveProductFromBackroom()
        {
	        return null;
        }

        public Statue ViewSoldProducts()
        {
	        return null;
        }

        public Boolean CloseStore()
        {
            return true;
        }

        public void SellProduct(int price, int socialSecurityNumber)
        {

        }

        private void CreateShop(String type)
        {

        }
    }
}
