using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class VehicleModel
    {
        public int VehicleModelID { get; set; }
        public Make Make { get; set; }
        public string ModelName { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserEmail { get; set; }
        public string Count { get; set; }
    }
}
