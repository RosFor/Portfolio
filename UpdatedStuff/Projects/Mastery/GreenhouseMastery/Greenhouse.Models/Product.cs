using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Models
{
    public class Product
    {
        public string PlantType { get; set; }
        public decimal CostPerPlant { get; set; }
        public decimal ShippingCostPerPlant { get; set; }
    }
}
