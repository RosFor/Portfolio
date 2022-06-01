using Greenhouse.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Data
{
    public class ProductRepository : IProduct
    {
        List<Product> productData = new List<Product>();
        public List<Product> ReadAll()
        {
            LoadProduct();
            return productData;
        }
        public Product ReadByID(string productType)
        {
            ReadAll();
            var results = (from products in productData
                           where products.PlantType == productType
                           select products).FirstOrDefault();
            return results;
        }
        private void LoadProduct()
        {
            string path = @"C:\TSG-PlantSampleData\Plants.txt";

            productData = new List<Product>();
            string[] rows = File.ReadAllLines(path);
            for (int i = 1; i < rows.Length; i++)
            {
                Product product = new Product();
                product = ConvertTextToObject(rows[i]);
                productData.Add(product);
            }
        }
        private Product ConvertTextToObject(string line)
        {
            string[] columns = line.Split(',');
            Product product = new Product();
            product.PlantType = columns[0];
            product.CostPerPlant = Decimal.Parse(columns[1]);
            product.ShippingCostPerPlant = Decimal.Parse(columns[2]);
            return product;
        }
    }
}
