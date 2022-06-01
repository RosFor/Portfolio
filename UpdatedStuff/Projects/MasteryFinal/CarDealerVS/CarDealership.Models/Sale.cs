using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public States States { get; set; }
        public PurchaseTypes PurchaseType { get; set; }
        public Vehicle Vehicle { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerStreet1 { get; set; }
        public string CustomerStreet2 { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerZip { get; set; }
        public decimal SalePurchasePrice { get; set; }
        public DateTime SalePurchaseDate { get; set; }
        public string UserEmail { get; set; }
    }
}
