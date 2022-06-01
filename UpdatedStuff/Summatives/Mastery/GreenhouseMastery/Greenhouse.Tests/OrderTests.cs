using Greenhouse.BLL;
using Greenhouse.Data;
using Greenhouse.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Tests
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void TestCreateOrderAndReadByID()
        {
            GreenhouseManager manager;
            manager = GreenhouseFactory.CreateMode();
            OrderRepository repository = new OrderRepository();

            Order order = new Order
            {
                OrderNumber = 1,
                OrderDate = DateTime.Parse("8.27.22"),
                CustomerName = "Em",
                Taxes = new Taxes
                {
                    StateAbbreviation = "OH",
                    TaxRate = 5.25M,
                },
                Product = new Product
                {
                    PlantType = "Tomato",
                    CostPerPlant = 1.60M,
                    ShippingCostPerPlant = 0.80M
                },
                Quantity = 10,
            };
            
            manager.ValidateOrder(order);
            repository.CreateOrder(order);
            Order retrieveOrder = repository.ReadByID(order.OrderDate, order.OrderNumber);

            Assert.IsNotNull(retrieveOrder.CustomerName);
            Assert.AreEqual(1, retrieveOrder.OrderNumber);
            Assert.AreEqual(10, retrieveOrder.Quantity);
        }
        [Test]
        public void TestCreateAndReadAll()
        {
            GreenhouseManager manager;
            manager = GreenhouseFactory.CreateMode();
            OrderRepository repository = new OrderRepository();

            Order firstOrder = new Order
            {
                OrderNumber = 1,
                OrderDate = DateTime.Parse("8.28.22"),
                CustomerName = "Em",
                Taxes = new Taxes
                {
                    StateAbbreviation = "OH",
                    TaxRate = 5.25M,
                },
                Product = new Product
                {
                    PlantType = "Tomato",
                    CostPerPlant = 1.60M,
                    ShippingCostPerPlant = 0.80M
                },
                Quantity = 10,
            };
            Order secondOrder = new Order
            {
                OrderNumber = 2,
                OrderDate = DateTime.Parse("8.28.22"),
                CustomerName = "Emi",
                Taxes = new Taxes
                {
                    StateAbbreviation = "PA",
                    TaxRate = 6.75M,
                },
                Product = new Product
                {
                    PlantType = "Squash",
                    CostPerPlant = 1.35M,
                    ShippingCostPerPlant = 0.90M
                },
                Quantity = 10,
            };
            manager.ValidateOrder(firstOrder);
            manager.ValidateOrder(secondOrder);
            repository.CreateOrder(firstOrder);
            repository.CreateOrder(secondOrder);

            List<Order> orderList = repository.ReadAll(firstOrder.OrderDate);

            Assert.IsNotNull(orderList);
            Assert.AreEqual(2, orderList.Count());
        }
        [Test]
        public void TestUpdateOrder()
        {
            GreenhouseManager manager;
            manager = GreenhouseFactory.CreateMode();
            OrderRepository repository = new OrderRepository();

            Order order = new Order
            {
                OrderNumber = 1,
                OrderDate = DateTime.Parse("8.29.22"),
                CustomerName = "Em",
                Taxes = new Taxes
                {
                    StateAbbreviation = "OH",
                    TaxRate = 5.25M,
                },
                Product = new Product
                {
                    PlantType = "Tomato",
                    CostPerPlant = 1.60M,
                    ShippingCostPerPlant = 0.80M
                },
                Quantity = 10,
            };
            manager.ValidateOrder(order);
            repository.CreateOrder(order);
            Order updateOrder = repository.ReadByID(order.OrderDate, order.OrderNumber);

            Assert.IsNotNull(order);
            Assert.AreEqual("Em",order.CustomerName);
            Assert.AreEqual("Tomato", order.Product.PlantType);
            Assert.AreEqual(10, order.Quantity);

            updateOrder.Product.PlantType = "BellPepper";
            updateOrder.Quantity = 5;
            Order updateResult = repository.UpdateOrder(updateOrder);

            Assert.IsNotNull(updateResult);
            Assert.AreEqual("Em", updateResult.CustomerName);
            Assert.AreEqual("BellPepper", updateResult.Product.PlantType);
            Assert.AreEqual(5, updateResult.Quantity);

        }
        [Test]
        public void TestDeleteOrder()
        {
            GreenhouseManager manager;
            manager = GreenhouseFactory.CreateMode();
            OrderRepository repository = new OrderRepository();

            Order firstOrder = new Order
            {
                OrderNumber = 1,
                OrderDate = DateTime.Parse("8.30.22"),
                CustomerName = "Em",
                Taxes = new Taxes
                {
                    StateAbbreviation = "OH",
                    TaxRate = 5.25M,
                },
                Product = new Product
                {
                    PlantType = "Tomato",
                    CostPerPlant = 1.60M,
                    ShippingCostPerPlant = 0.80M
                },
                Quantity = 10,
            };
            Order secondOrder = new Order
            {
                OrderNumber = 2,
                OrderDate = DateTime.Parse("8.30.22"),
                CustomerName = "Emi",
                Taxes = new Taxes
                {
                    StateAbbreviation = "PA",
                    TaxRate = 6.75M,
                },
                Product = new Product
                {
                    PlantType = "Squash",
                    CostPerPlant = 1.35M,
                    ShippingCostPerPlant = 0.90M
                },
                Quantity = 5,
            };
            manager.ValidateOrder(firstOrder);
            manager.ValidateOrder(secondOrder);
            repository.CreateOrder(firstOrder);
            repository.CreateOrder(secondOrder);

            List<Order> orderList = repository.ReadAll(firstOrder.OrderDate);

            Assert.IsNotNull(orderList);
            Assert.AreEqual(2, orderList.Count());

            Assert.AreEqual("Em", firstOrder.CustomerName);
            Assert.AreEqual("Tomato", firstOrder.Product.PlantType);
            Assert.AreEqual(10, firstOrder.Quantity);

            Assert.AreEqual("Emi", secondOrder.CustomerName);
            Assert.AreEqual("Squash", secondOrder.Product.PlantType);
            Assert.AreEqual(5, secondOrder.Quantity);

            bool deleteOrder = repository.DeleteOrder(secondOrder.OrderDate, secondOrder.OrderNumber);

            List<Order> updatedOrderList = repository.ReadAll(firstOrder.OrderDate);
            Assert.IsTrue(deleteOrder);
            Assert.IsNotNull(updatedOrderList);
            Assert.AreEqual(1, updatedOrderList.Count());

            Assert.AreEqual("Em", firstOrder.CustomerName);
            Assert.AreEqual("Tomato", firstOrder.Product.PlantType);
            Assert.AreEqual(10, firstOrder.Quantity);
        }
        [TestCase("8.01.22", "Em", "ZZ", 0, "Tomato", 5, 0, 0, "State does not exist.")]
        [TestCase("8.01.22", "Em", "OH", 0, "Beetle", 5, 0, 0, "Plant does not exist.")]
        [TestCase("8.01.22", "Em", "OH", 0, "Tomato", 0, 0, 0, "Order must have at least 5 plants.")]
        public void TestInvalidValidateOrder(string orderDate, string customerName, string stateAbbr, decimal taxRate, string plantType, int quantity, decimal costPerPlant, decimal shipPerPlant, string expectedMessage)
        {
            GreenhouseManager manager;
            manager = GreenhouseFactory.CreateMode();

            Order order = new Order
            {
                OrderDate = DateTime.Parse(orderDate),
                CustomerName = customerName,
                Taxes = new Taxes
                {
                    StateAbbreviation = stateAbbr,
                    TaxRate = taxRate,
                },
                Product = new Product
                {
                    PlantType = plantType,
                    CostPerPlant = costPerPlant,
                    ShippingCostPerPlant = shipPerPlant,
                },
                Quantity = quantity,
            };

            try
            {
                manager.ValidateOrder(order);
                manager.CreateOrder(order);
                Assert.Fail(expectedMessage);
            }
            catch(GreenhouseExceptionDefinition exMessage)
            {
                Assert.AreEqual(expectedMessage, exMessage.Message);
            }
        }
        [TestCase("03.01.22", "Em", "OH", 6.25, "Tomato", 5, 1.60, 0.80)]
        [TestCase("8.31.22", "Emily", "PA", 6.75, "BellPepper", 5, 2.25, 1.05)]
        public void TestValidValidateOrder(string orderDate, string customerName, string stateAbbr, decimal taxRate, string plantType, int quantity, decimal costPerPlant, decimal shipPerPlant)
        {
            GreenhouseManager manager;
            manager = GreenhouseFactory.CreateMode();

            Order order = new Order
            {
                OrderDate = DateTime.Parse(orderDate),
                CustomerName = customerName,
                Taxes = new Taxes
                {
                    StateAbbreviation = stateAbbr,
                    TaxRate = taxRate,
                },
                Product = new Product
                {
                    PlantType = plantType,
                    CostPerPlant = costPerPlant,
                    ShippingCostPerPlant = shipPerPlant,
                },
                Quantity = quantity,
            };

            try
            {
                manager.ValidateOrder(order);
                Order createOrder = manager.CreateOrder(order);
                Assert.AreEqual(order, createOrder);
            }
            catch (Exception exMessage)
            {
                Assert.Fail("No exception should be thrown in this test");
            }
        }
    }
}
