using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model;

namespace Vending.Data
{
    public class ProductRepository : IProduct
    {
        string path = "C:\\TSG-SampleData\\VendingMachineProducts.txt";
        List<Product> productData = new List<Product>();
        //Dictionary<string, Product> productDictionary = new Dictionary<string, Product>();
        public Product CreateProduct(Product productName)
        {
            LoadProduct();
            productData.Add(productName);
            SaveProduct();
            return productName;
        }
        public List<Product> ReadAll()
        {
            LoadProduct();
            return productData;
        }
        public Product ReadByID(string productName)
        {
            LoadProduct();
            var results = (from products in productData
                          where products.ItemName == productName
                          select products).FirstOrDefault();
            return results;
        }
        public Product UpdateProduct(Product updatedProduct)
        {
            LoadProduct();
            Product product = ReadByID(updatedProduct.ItemName);
            product.ItemPrice = updatedProduct.ItemPrice;
            product.UnitsInStock = updatedProduct.UnitsInStock;
            SaveProduct();
            return updatedProduct;
        }
        public void DeleteProduct(string productName)
        {
            LoadProduct();
            productData.RemoveAll(x => x.ItemName == productName);
            SaveProduct();
        }
        private void LoadProduct()
        {
            productData = new List<Product>();
            string[] rows = File.ReadAllLines(path);
            for (int i = 1; i < rows.Length; i++)
            {
                Product product = new Product();
                product = ConvertTextToObject(rows[i]);
                productData.Add(product);
            }
        }
        private void SaveProduct()
        {
            string header = "ItemName,ItemPrice,UnitsInStock";
            string[] lines = new string[productData.Count + 1];
            lines[0] = header;

            for (int i = 0; i < lines.Length - 1; i++)
            {
                string line = ConvertObjectToText(productData[i]);
                lines[i + 1] = line;
            }
            File.WriteAllLines(path, lines);
        }
        private Product ConvertTextToObject(string line)
        {
            string[] columns = line.Split(',');
            Product product = new Product();

            product.ItemName = columns[0];
            decimal itemPrice;
            decimal.TryParse(columns[1], out itemPrice);
            product.ItemPrice = itemPrice;
            int unitsInStock;
            int.TryParse(columns[2], out unitsInStock);
            product.UnitsInStock = unitsInStock;

            return product;
        }
        private string ConvertObjectToText(Product product)
        {
            string row = $"{product.ItemName},{product.ItemPrice},{product.UnitsInStock}";
            return row;
        }
    }
}
