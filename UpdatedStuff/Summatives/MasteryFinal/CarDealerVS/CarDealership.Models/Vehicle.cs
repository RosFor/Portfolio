using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public Condition Condition { get; set; }
        public Body Body { get; set; }
        public Transmission Transmission { get; set; }
        public Color Color { get; set; }
        public InteriorColor InteriorColor { get; set; }
        public int VehicleYear { get; set; }
        public int Mileage { get; set; }
        public string VinNumber { get; set; }
        public string VehicleDescription { get; set; }
        public string VehicleImageFile { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsSold { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
