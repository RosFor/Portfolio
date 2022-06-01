using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Data;
using Vending.Model;
using Vending.Model.Responses;

namespace Vending.BLL
{
    public class DepositRule : IDeposit
    {
        public DepositResponse Deposit(Product product, decimal amountInserted)
        {
            DepositResponse response = new DepositResponse();
            if(product.UnitsInStock == 0)
            {
                response.Success = false;
                response.Message = "Cannot purchase item that is out of stock.";
                return response;
            }
            if(product.ItemPrice > amountInserted)
            {
                response.Success = false;
                response.Message = "Not enough money was inserted to purchase this item.";
                return response;
            }
            response.Success = true;
            response.Product = product;
            response.AmountInserted = amountInserted;
            decimal decimalChange = amountInserted - response.Product.ItemPrice;
            response.Change = VendingManager.ReturnChange(decimalChange);
            product.UnitsInStock--;
            return response;
        }
    }
}
