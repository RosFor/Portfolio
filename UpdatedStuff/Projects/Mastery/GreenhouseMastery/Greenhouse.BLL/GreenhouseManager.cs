using Greenhouse.Data;
using Greenhouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.BLL
{
    public class GreenhouseManager
    {
        private IOrder _orderRepo;
        private IProduct _productRepo;
        private ITax _taxRepo;
        public GreenhouseManager(IOrder orderRepo, IProduct productRepo, ITax taxRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _taxRepo = taxRepo;
        }

        public Order CreateOrder(Order order)
        {
            Order createOrder = new Order();
            createOrder = _orderRepo.CreateOrder(order);
            
            return createOrder;
        }
        public Order UpdateOrder(Order order)
        {
            Order updateOrder = new Order();
            updateOrder = _orderRepo.UpdateOrder(order);
            
            return updateOrder;
        }
        public bool DeleteOrder(DateTime orderDate, int orderNumber)
        {
            Order deleteOrder = new Order();
            if (deleteOrder != null)
            {
                return _orderRepo.DeleteOrder(orderDate, orderNumber);
            }
            else
            {
                return false;
            }
        }
        public List<Order> GetOrderByDate(DateTime orderDate)
        {
            List<Order> ordersByDate = new List<Order>();
            ordersByDate = _orderRepo.ReadAll(orderDate);
            if(ordersByDate == null)
            {
                throw new GreenhouseExceptionDefinition("Date is invalid.");
            }
            return ordersByDate;
        }
        public Order GetOrderByID(DateTime orderDate, int orderNumber)
        {
            Order orderByID = new Order();
            orderByID = _orderRepo.ReadByID(orderDate, orderNumber);
            
            return orderByID;
        }
        public Order ValidateOrderNumber(Order order)
        {
            if (order == null) //doesn't have order number
            {
                throw new GreenhouseExceptionDefinition("Order number does not exist.");
            }
            return order;
        }
        public Order ValidateOrder(Order order)
        {
            //All Validation steps
            if (string.IsNullOrEmpty(order.CustomerName))
            {
                throw new GreenhouseExceptionDefinition("Customer name may not be empty.");
            }
            else if (order.Quantity < 5)
            {
                throw new GreenhouseExceptionDefinition("Order must have at least 5 plants.");
            }
            else if (order.Quantity > 1000)
            {
                throw new GreenhouseExceptionDefinition("Order may not exceed 1000 plants.");
            }
            order.Product = _productRepo.ReadByID(order.Product.PlantType);
            if (order.Product == null)
            {
                throw new GreenhouseExceptionDefinition("Plant does not exist.");
            }
            order.Taxes = _taxRepo.ReadByID(order.Taxes.StateAbbreviation);
            if (order.Taxes == null)
            {
                throw new GreenhouseExceptionDefinition("State does not exist.");
            }
            if (order.OrderNumber == 0) //doesn't have order number
            {
                order.OrderNumber = GenerateOrderNumber(order.OrderDate);
            }
            
            //All Calculation steps
            order.TotalPlantCost = (order.Quantity * order.Product.CostPerPlant);
            order.TotalShippingCost = (order.Quantity * order.Product.ShippingCostPerPlant);
            order.Tax = Decimal.Round(((order.TotalPlantCost + order.TotalShippingCost) * (order.Taxes.TaxRate / 100)), 2);
            order.Total = Decimal.Round((order.TotalPlantCost + order.TotalShippingCost + order.Tax), 2);

            //Return
            return order;
        }
        private int GenerateOrderNumber(DateTime orderDate)
        {
            List<Order> orders = _orderRepo.ReadAll(orderDate);
            if (orders != null && orders.Count == 0)
            {
                return 1;
            }

            return orders.Max(o => o.OrderNumber) + 1;
        }
    }
}
