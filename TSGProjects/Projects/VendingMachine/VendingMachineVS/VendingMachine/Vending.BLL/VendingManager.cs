using System;
using System.Collections.Generic;
using Vending.Data;
using Vending.Model;
using Vending.Model.Responses;
using System.Linq;

namespace Vending.BLL
{
    public class VendingManager
    {
        private ProductRepository _productRepo;
        public VendingManager()
        {
            _productRepo = new ProductRepository();
        }
        public List<Product> LoadValidProducts()
        {
            var products = _productRepo.ReadAll();

            var validProducts = (from product in products
                                where product.UnitsInStock > 0
                                select product).ToList();

            return validProducts;
        }
        public DepositResponse PurchaseValidItem(string productName, decimal moneyInserted)
        {
            DepositResponse response = new DepositResponse();

            response.Product = _productRepo.ReadByID(productName);
            if (response.Product == null)
            {
                response.Success = false;
                response.Message = $"{productName} is not a valid product.";
                return response;
            }
            else
            {
                response.Success = true;
            }
            IDeposit depositRule = new DepositRule();
            response = depositRule.Deposit(response.Product, moneyInserted);

            if (response.Success == true)
            {
                _productRepo.UpdateProduct(response.Product);
            }

            return response;
        }
        public static Change ReturnChange(decimal decimalChange)
        {
            Change change = new Change();

            change.Quarters = (int)(decimalChange / .25m);
            decimalChange %= .25m;

            change.Dimes = (int)(decimalChange / .10m);
            decimalChange %= .10m;

            change.Nickels = (int)(decimalChange / .05m);
            decimalChange %= .05m;

            change.Pennies = (int)(decimalChange / .01m);
            decimalChange %= .01m;

            return change;
        }
    }
}
