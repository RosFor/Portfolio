using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending.Model
{
    public class Product
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool Equals(Product product)
        {
            // Would still want to check for null etc. first.
            return this.ItemName == product.ItemName &&
                   this.ItemPrice == product.ItemPrice &&
                   this.UnitsInStock == product.UnitsInStock;
        }
    }
}
