using Greenhouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Data
{
    public class MockOrderRespository : IOrder
    {
        private static List<Order> _orders = new List<Order>();
        public MockOrderRespository()
        {
            if (!_orders.Any())
            {
                _orders.AddRange(new List<Order>()
                {
                    
                    new Order
                    {
                        OrderNumber = 1,
                        OrderDate = DateTime.Parse("8.27.22"),
                        CustomerName = "Em",
                        Taxes = new Taxes
                        {
                            StateAbbreviation = "OH",
                        },
                        Product = new Product
                        {
                            PlantType = "Tomato",
                        },
                        Quantity = 10,
                    },
                    new Order
                    {
                        OrderNumber = 2,
                        OrderDate = DateTime.Parse("8.27.22"),
                        CustomerName = "Emi",
                        Taxes = new Taxes
                        {
                            StateAbbreviation = "PA",
                        },
                        Product = new Product
                        {
                            PlantType = "Squash",
                        },
                        Quantity = 10,
                    },
                    new Order
                    {
                        OrderNumber = 3,
                        OrderDate = DateTime.Parse("8.27.22"),
                        CustomerName = "Emily",
                        Taxes = new Taxes
                        {
                            StateAbbreviation = "MI",
                        },
                        Product = new Product
                        {
                            PlantType = "BellPepper",
                        },
                        Quantity = 10,
                    }
                });
            };
        }
        public Order CreateOrder(Order order)
        {
            _orders.Add(order);
            return order;
        }

        public bool DeleteOrder(DateTime orderDate, int orderNumber)
        {
            ReadAll(orderDate);
            if(orderDate != null)
            {
                _orders.RemoveAll(o => o.OrderNumber == orderNumber);
            }
            return true;
        }

        public List<Order> ReadAll(DateTime orderDate)
        {
            Order order = new Order();
            _orders.FindAll(o => o.OrderDate == orderDate);
            return _orders;
        }

        public Order ReadByID(DateTime orderDate, int orderNumber)
        {
            Order order = new Order();
            ReadAll(orderDate);
            order = _orders.Find(o => o.OrderNumber == orderNumber);
            
            return order;
        }

        public Order UpdateOrder(Order orderToUpdate)
        {
            CreateOrder(orderToUpdate);
            return orderToUpdate;
        }
    }
}
