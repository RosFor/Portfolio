using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Models
{
    public class Order
    {
        public Taxes Taxes { get; set; }
        public Product Product { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPlantCost { get; set; }
        public decimal TotalShippingCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}
