using Greenhouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.View
{
    public class GreenhouseView : UserIO
    {
        private UserIO input;
        public GreenhouseView()
        {
            input = new UserIO();
        }
        public int GetMenuChoice()
        {
            DisplayMenu();
            int userChoice = input.GetUserInt("Enter a choice: ", 1, 5);
            return userChoice;
        }
        public Order GetNewOrderInfo()
        {
            Console.Clear();
            Order order = new Order();
            Taxes tax = new Taxes();
            Product product = new Product();
            order.Taxes = tax;
            order.Product = product;
            order.OrderDate = input.GetOrderDate("Enter an order date: ");
            order.CustomerName = input.GetNewCustomerName("Enter a customer name: ");
            order.Taxes.StateAbbreviation = input.GetUserStateAbbr("Enter a state: ");
            order.Product.PlantType = input.GetUserString("Enter a plant type: ");
            order.Quantity = input.GetUserInt("Enter an order quantity: ", 5, 1000);
            return order;
        }
        public Order GetUpdatedOrderInfo(Order updateOrder)
        {
            Console.Clear();
            Console.Write($"Enter a customer name, or leave blank: ({updateOrder.CustomerName})");
            string customerName = Console.ReadLine();
            if (string.IsNullOrEmpty(customerName))
            {
                customerName = updateOrder.CustomerName;
            }
            else
            {
                updateOrder.CustomerName = input.EditCustomerName(customerName);
            }
            Console.Write($"Enter a state (abbreviation), or leave blank: ({updateOrder.Taxes.StateAbbreviation})");
            string state = Console.ReadLine();
            if (string.IsNullOrEmpty(state))
            {
                state = updateOrder.Taxes.StateAbbreviation;
            }
            else
            {
                updateOrder.Taxes.StateAbbreviation = input.EditStateAbbr(state);
            }
            Console.Write($"Enter a plant type, or leave blank: ({updateOrder.Product.PlantType})");
            string plantType = Console.ReadLine();
            if (string.IsNullOrEmpty(plantType))
            {
                plantType = updateOrder.Product.PlantType;
            }
            else
            {
                updateOrder.Product.PlantType = input.EditPlantType(plantType);
            }

            updateOrder.Quantity = input.EditOrderQuantity($"Enter an order quantity, or leave blank: ({updateOrder.Quantity})", updateOrder.Quantity, 5, 1000);

            return updateOrder;
        }
        public int GetLookupByOrderNumber()
        {
            Console.Clear();
            int orderNumber = input.GetUserInt("Enter an order number: ");
            return orderNumber;
        }
        public DateTime GetLookupByDate()
        {
            Console.Clear();
            DateTime userDate = input.GetLookupDate("Enter a lookup date: ");
            return userDate;
        }
        public bool GetUserConfirmation(Order order)
        {
            string userInput = input.GetUserYesNo("Do you wish to confirm?");
            if (userInput == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DisplayError(string message)
        {
            Console.WriteLine("Error: " + message);
            Console.WriteLine("Hit enter to start over & try again.");
            Console.ReadKey();
        }
        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Greenhouse Plant Ordering System");
            Console.WriteLine("\n-------------------");
            Console.WriteLine("1. Display Orders");
            Console.WriteLine("2. Add an Order");
            Console.WriteLine("3. Edit an Order");
            Console.WriteLine("4. Remove an Order");
            Console.WriteLine("5. Quit");
            Console.WriteLine("\n-------------------");
        }
        public void DisplayOrderDetails(Order displayOrder)
        {
            Console.WriteLine("\n-------------------");
            Console.WriteLine($"{displayOrder.OrderNumber} | { displayOrder.OrderDate.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"{displayOrder.CustomerName}");
            Console.WriteLine($"{displayOrder.Taxes.StateAbbreviation}");
            Console.WriteLine($"Plant Name: {displayOrder.Product.PlantType}");
            Console.WriteLine($"Units: {displayOrder.Quantity}");
            Console.WriteLine($"Plant Cost: ${displayOrder.TotalPlantCost}");
            Console.WriteLine($"Shipping Cost: ${displayOrder.TotalShippingCost}");
            Console.WriteLine($"Tax: ${displayOrder.Tax}");
            Console.WriteLine("Total: ${0}", displayOrder.Total);
        }
        public void DisplayAllProducts(List<Product> displayAllProducts)
        {
            Console.Clear();
            Console.WriteLine("Plant Type | Cost/Plant | Shipping Cost/Plant");
            foreach (Product product in displayAllProducts)
            {
                DisplayProductDetails(product);
            }
        }
        public void DisplayAllTaxes(List<Taxes> displayAllTaxes)
        {
            Console.Clear();
            Console.WriteLine("State | Tax Rate");
            foreach (Taxes tax in displayAllTaxes)
            {
                DisplayTaxDetails(tax);
            }
        }
        private void DisplayProductDetails(Product displayProduct)
        {
            Console.WriteLine("{0} | {1} | {2}", displayProduct.PlantType, displayProduct.CostPerPlant, displayProduct.ShippingCostPerPlant);
        }
        private void DisplayTaxDetails(Taxes displayTax)
        {
            Console.WriteLine("{0} | {1}", displayTax.StateAbbreviation, displayTax.TaxRate);
        }
    }
}
