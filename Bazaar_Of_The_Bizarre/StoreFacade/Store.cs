using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Of_The_Bizarre {
	class Store
    {
        private Shop _shop { get; set; }
        private BackRoom _backroom { get; set; }
        private String _name { get; set; }
        private int _quota { get; set; }
        private List<Products> _products { get; set; }

        public Store(String name)
        {
            this._name = name;
        }

        public String GetName()
        {
            return _name;
        }

        public void SetQuota(int Quota)
        {
            this._quota = Quota;
        }

        public Product recieveProductFromBackroom()
        {

        }

        public Product ViewSoldProducts()
        {

        }

        public Boolean CloseStore()
        {
            return true;
        }

        public void SellProduct(int Price, int SocialSecurityNumber)
        {

        }

        private void CreateShop(String type)
        {

        }
    }
}
