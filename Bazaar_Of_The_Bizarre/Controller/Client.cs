using System;
using System.Threading;
using Bazaar_Of_The_Bizarre.Bank.BankFlyweight;
using Bazaar_Of_The_Bizarre.Controller;

namespace Bazaar_Of_The_Bizarre.controller
{
    class Client
    {
        public static readonly Random Rnd = new Random();
        public static readonly PrintHandler PrintProduct = PrintHandler.GetInstance();
        private readonly Bank.BankFlyweight.Bank _bank;
        private readonly Bazaar _bazaar;
        private readonly ThreadHandler _threadHandler;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="amountOfCustomers"></param>
        public Client(int amountOfCustomers)
        {
            _bank = BankFactory.GetBank("DNB");
            _bazaar = new Bazaar();
            _threadHandler = new ThreadHandler(amountOfCustomers);
        }

        /// <summary>
        /// Runs the whole game and start threads
        /// </summary>
        public void RunGame()
        {
            _threadHandler.StartAllStoresThreads(_bazaar);

            if (_bazaar.IsBazarOpen())
            {
                _threadHandler.StartAllCustomerThreads(_bank, _bazaar);
                //TODO MAKE THIS GREAT AGAIN
                while (_bazaar.IsBazarOpen())
                {

                }
                EndOfDay();
                Console.WriteLine("Bazar is now closed.");
            }
        }

        /// <summary>
        /// Prints out all sold of the day by stores.
        /// </summary>
        private void EndOfDay()
        {
            foreach (var store in _bazaar.GetStoreList())
            {
                store.ViewSoldProducts();
            }
        }
    }
}
