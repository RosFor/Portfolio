using Greenhouse.BLL;
using Greenhouse.Models;
using Greenhouse.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Controller
{
    public class GreenhouseController
    {
        private GreenhouseView view;
        private GreenhouseManager manager;
        public GreenhouseController()
        {
            view = new GreenhouseView();
            manager = GreenhouseFactory.CreateMode();
        }

        public void RunProgram()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                int menuChoice = view.GetMenuChoice();
                switch (menuChoice)
                {
                    case 1:
                        DisplayOrder();
                        break;
                    case 2:
                        AddOrder();
                        break;
                    case 3:
                        EditOrder();
                        break;
                    case 4:
                        DeleteOrder();
                        break;
                    case 5:
                        return;
                    default:
                        keepRunning = false;
                        break;
                }
            }
        }
        private void DisplayOrder()
        {
            List<Order> displayOrder = new List<Order>();
            DateTime orderDate = view.GetLookupByDate();
            displayOrder = manager.GetOrderByDate(orderDate);
            foreach (Order order in displayOrder)
            {
                view.DisplayOrderDetails(order);
            }
            Console.ReadKey();
        }
        private void AddOrder()
        {
            Order newOrder;
            while (true)
            {
                newOrder = view.GetNewOrderInfo();
                try
                {
                    manager.ValidateOrder(newOrder);
                    break;
                }
                catch (GreenhouseExceptionDefinition message)
                {
                    view.DisplayError(message.Message);
                }
            }
            
            view.DisplayOrderDetails(newOrder);
            bool confirm = view.GetUserConfirmation(newOrder);
            if(confirm == true)
            {
                manager.CreateOrder(newOrder);
            }
            else
            {
                return;
            }

        }
        private void EditOrder()
        {
            DateTime orderDate;
            int orderNumber;
            Order order;

            while (true)
            {
                orderDate = view.GetLookupByDate();
                orderNumber = view.GetLookupByOrderNumber();
                order = manager.GetOrderByID(orderDate, orderNumber);
                try
                {
                    manager.ValidateOrderNumber(order);
                    break;
                }
                catch (GreenhouseExceptionDefinition message)
                {
                    view.DisplayError(message.Message);
                }
            }

            Order editOrder = view.GetUpdatedOrderInfo(order);
            manager.ValidateOrder(editOrder);
            view.DisplayOrderDetails(editOrder);

            bool confirm = view.GetUserConfirmation(editOrder);
            if (confirm == true)
            {
                manager.UpdateOrder(editOrder);
            }
            else
            {
                return;
            }
        }
        private void DeleteOrder()
        {
            DateTime orderDate;
            int orderNumber;
            Order order;
            while (true)
            {
                orderDate = view.GetLookupByDate();
                orderNumber = view.GetLookupByOrderNumber();
                order = manager.GetOrderByID(orderDate, orderNumber);
                try
                {
                    manager.ValidateOrderNumber(order);
                    break;
                }
                catch (GreenhouseExceptionDefinition message)
                {
                    view.DisplayError(message.Message);
                }
            }

            view.DisplayOrderDetails(order);
            bool confirm = view.GetUserConfirmation(order);
            if (confirm == true)
            {
                manager.DeleteOrder(orderDate, orderNumber);
            }
            else
            {
                return;
            }
        }
    }
}
