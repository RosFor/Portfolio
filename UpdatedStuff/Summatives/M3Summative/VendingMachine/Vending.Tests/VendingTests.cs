using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.BLL;
using Vending.Data;
using Vending.Model;
using Vending.Model.Responses;

namespace Vending.Tests
{
    [TestFixture]
    public class VendingTests
    {
        [TestCase("Mochi", 1.99, 1)]
        public void CreateProductAndReadID(string name, decimal price, int unitsAvailable)
        {
            ProductRepository repository = new ProductRepository();
            Product product = new Product();
            product.ItemName = name;
            product.ItemPrice = price;
            product.UnitsInStock = unitsAvailable;

            repository.CreateProduct(product);
            Product retrieveProduct = repository.ReadByID(name);

            Assert.IsNotNull(retrieveProduct.ItemName);
            Assert.AreEqual(1.99, retrieveProduct.ItemPrice);
            Assert.AreEqual(1, retrieveProduct.UnitsInStock);
        }
        [Test]
        public void CreateProductAndReadAll()
        {
            ProductRepository repository = new ProductRepository();
            Product firstProduct = new Product();
            firstProduct.ItemName = "Donburi";
            firstProduct.ItemPrice = 15.00M;
            firstProduct.UnitsInStock = 1;

            Product secondProduct = new Product();
            secondProduct.ItemName = "Gyoza";
            secondProduct.ItemPrice = 3.50M;
            secondProduct.UnitsInStock = 1;

            repository.CreateProduct(firstProduct);
            repository.CreateProduct(secondProduct);

            List<Product> allProducts = repository.ReadAll();

            Assert.IsNotNull(allProducts);
            Assert.AreEqual(8, allProducts.Count());

            /*Assert.IsTrue(repository.ReadAll().Contains(firstProduct));
            Assert.IsTrue(repository.ReadAll().Contains(secondProduct));*/
            Product retrieveFirstProduct = repository.ReadByID(firstProduct.ItemName);
            Product retrieveSecondProduct = repository.ReadByID(secondProduct.ItemName);
            Assert.AreEqual("Donburi", retrieveFirstProduct.ItemName);
            Assert.AreEqual("Gyoza", retrieveSecondProduct.ItemName);
        }
        [Test]
        public void UpdateProduct()
        {
            ProductRepository repository = new ProductRepository();
            Product product = new Product();
            product.ItemName = "Udon";
            product.ItemPrice = 10000.00M;
            product.UnitsInStock = 20;

            repository.CreateProduct(product);
            Product updateProduct = repository.ReadByID(product.ItemName);

            Assert.IsNotNull(updateProduct);
            Assert.AreEqual("Udon", updateProduct.ItemName);

            updateProduct.ItemPrice = 15.00M;
            updateProduct.UnitsInStock = 1;
            Product updatedResult = repository.UpdateProduct(updateProduct);
            
            Assert.IsNotNull(updatedResult);
            Assert.AreEqual(1, updatedResult.UnitsInStock);
        }
        [TestCase("Ramune", 2.50, 10, 2.51, true)]
        [TestCase("Monaka", 3.00, 0, 4.00, false)]
        [TestCase("UmamiSeaweed", 0.99, 2, 0.50, false)]
        [TestCase("awerawerwer", 100.00, 1, 100.00, false)]
        public void PurchaseItem(string name, decimal price, int stock, decimal amount, bool expectedResult)
        {
            VendingManager manager = new VendingManager();
            Product product = new Product();

            product.ItemName = name;
            product.ItemPrice = price;
            product.UnitsInStock = stock;
            
            DepositResponse response = manager.PurchaseValidItem(product.ItemName,amount);
            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
