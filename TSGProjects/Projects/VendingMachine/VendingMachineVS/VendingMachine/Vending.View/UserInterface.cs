using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model;
using Vending.Model.Responses;

namespace Vending.View
{
    public class UserInterface
    {
        private UserInput input;
        public UserInterface()
        {
            input = new UserInput();
        }
        public int GetMenuChoice()
        {
            Console.WriteLine("");
            Console.WriteLine("1. Display Items");
            Console.WriteLine("2. Insert Money & Purchase Item");
            Console.WriteLine("3. Quit");
            int userChoice = input.ReadIntLong("Enter choice: ", 1, 3);
            return userChoice;
        }
        public void DisplayProductDetails(Product displayProduct)
        {
            Console.WriteLine("{0} | {1} | {2}", displayProduct.ItemName, displayProduct.ItemPrice, displayProduct.UnitsInStock);
        }
        public void DisplayAllProducts(List<Product> displayAllProducts)
        {
            Console.WriteLine("");
            Console.WriteLine("Name | Price | UnitsInStock");
            foreach (Product product in displayAllProducts)
            {
                DisplayProductDetails(product);
            }
        }
        public string GetItemChoice()
        {
            Console.WriteLine("");
            string retrieveItem = input.ReadString("Enter product name: ");
            return retrieveItem;
        }
        public decimal GetChangeFromUser()
        {
            Console.WriteLine("");
            decimal userChange = input.ReadDecimal("Insert money: $");
            return userChange;
        }
        public void PrintChange(Change change)
        {
            Console.WriteLine("Your change is: {0} quarters, {1} dimes, {2} nickels, and {3} pennies.", change.Quarters, change.Dimes, change.Nickels, change.Pennies);
        }
    }
}
