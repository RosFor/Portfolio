using Greenhouse.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Data
{
    public class OrderRepository : IOrder
    {
        Dictionary<int, Order> dictionary = new Dictionary<int, Order>();
        
        public Order CreateOrder(Order order)
        {
            LoadOrder(order.OrderDate);
            dictionary.Add(order.OrderNumber, order);
            SaveOrder(order.OrderDate);
            return order;
        }
        
        public List<Order> ReadAll(DateTime orderDate)
        {
            LoadOrder(orderDate);
            return dictionary.Values.ToList();
        }

        public Order ReadByID(DateTime orderDate, int orderNumber)
        {
            LoadOrder(orderDate);
            Order order;
            dictionary.TryGetValue(orderNumber, out order);
            return order;
        }

        public Order UpdateOrder(Order orderToUpdate)
        {
            LoadOrder(orderToUpdate.OrderDate);
            dictionary[orderToUpdate.OrderNumber] = orderToUpdate;
            SaveOrder(orderToUpdate.OrderDate);
            return orderToUpdate;
        }
        
        public bool DeleteOrder(DateTime orderDate, int orderNumber)
        {
            LoadOrder(orderDate);
            bool deleteOrder = dictionary.Remove(orderNumber);
            SaveOrder(orderDate);
            return deleteOrder;
        }

        private void LoadOrder(DateTime orderDate)
        {
            string path = @"C:\TSG-PlantSampleData\Orders_" + orderDate.ToString("MMddyyy") + ".txt";
            dictionary = new Dictionary<int, Order>();
            if (!File.Exists(path))
            {
                return;
            }
            string[] rows = File.ReadAllLines(path);
            for(int i = 1; i < rows.Length; i++)
            {
                Order order = new Order();
                order = ConvertTextToObject(rows[i]);
                order.OrderDate = orderDate;
                dictionary.Add(order.OrderNumber,order);
            }
        }
        private void SaveOrder(DateTime orderDate)
        {
            string path = @"C:\TSG-PlantSampleData\Orders_" + orderDate.ToString("MMddyyy") + ".txt";
            string header = "OrderNumber,CustomerName,State,TaxRate,PlantName,Quantity,CostPerPlant,ShippingCostPerPlant,TotalPlantCost,TotalShippingCost,Tax,Total";
            string[] lines = new string[dictionary.Count + 1];
            lines[0] = header;

            for (int i = 0; i < lines.Length - 1; i++)
            {
                string line = ConvertObjectToText(dictionary[i + 1]);
                lines[i + 1] = line;
            }
            File.WriteAllLines(path, lines);
        }
        private Order ConvertTextToObject(string line)
        {
            string[] columns = line.Split(',');
            Order order = new Order();
            Taxes tax = new Taxes();
            Product product = new Product();
            order.Taxes = tax;
            order.Product = product;
            order.OrderNumber = Int32.Parse(columns[0]);
            order.CustomerName = columns[1];
            order.Taxes.StateAbbreviation = columns[2];
            order.Taxes.TaxRate = Decimal.Parse(columns[3]);
            order.Product.PlantType = columns[4];
            order.Quantity = Int32.Parse(columns[5]);
            order.Product.CostPerPlant = Decimal.Parse(columns[6]);
            order.Product.ShippingCostPerPlant = Decimal.Parse(columns[7]);
            order.TotalPlantCost = Decimal.Parse(columns[8]);
            order.TotalShippingCost = Decimal.Parse(columns[9]);
            order.Tax = Decimal.Parse(columns[10]);
            order.Total = Decimal.Parse(columns[11]);
            return order;
        }
        private string ConvertObjectToText(Order order)
        {
            string row = $"{order.OrderNumber},{order.CustomerName},{order.Taxes.StateAbbreviation},{order.Taxes.TaxRate},{order.Product.PlantType},{order.Quantity},{order.Product.CostPerPlant},{order.Product.ShippingCostPerPlant},{order.TotalPlantCost},{order.TotalShippingCost},{order.Tax},{order.Total}";
            return row;
        }
    }
}
