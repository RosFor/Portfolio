using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class HomeIndexVM
    {
        public IEnumerable<Vehicle> vehicles { get; set; }
        public List<Specials> specials { get; set; }
    }
}