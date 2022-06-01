using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.BLL;
using Vending.Model;
using Vending.Model.Responses;
using Vending.View;

namespace Vending.Controller
{
    public class VendingController
    {
        private UserInterface userInterface;
        private VendingManager manager;
        public VendingController()
        {
            userInterface = new UserInterface();
            manager = new VendingManager();
        }
        public void Run()
        {
            bool keepRunning = true;

            while(keepRunning)
            {
                int menuChoice = userInterface.GetMenuChoice();

                switch (menuChoice)
                {
                    case 1:
                        DisplayProducts();
                        break;
                    case 2:
                        PurchaseItem();
                        break;
                    case 3:
                        keepRunning = false;
                        break;
                }
            }
        }
        private void DisplayProducts()
        {
            List<Product> productList = manager.LoadValidProducts();
            userInterface.DisplayAllProducts(productList);
            Console.ReadKey();
        }
        private void PurchaseItem()
        {
            string retrieveItem = userInterface.GetItemChoice();
            decimal amount = userInterface.GetChangeFromUser();

            DepositResponse response = manager.PurchaseValidItem(retrieveItem,amount);
            
            if(response.Success)
            {
                userInterface.PrintChange(response.Change);
            }
            else
            {
                Console.WriteLine("An error occurred: " + response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
