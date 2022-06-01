using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Model;

namespace Vending.Data
{
    public interface IProduct
    {
        Product CreateProduct(Product productName);
        List<Product> ReadAll();
        Product ReadByID(string productName);
        Product UpdateProduct(Product productName);
        void DeleteProduct(string productName);
    }
}
