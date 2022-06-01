using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class ReportSearchVM
    {
        public IEnumerable<Sale> Sales { get; set; }
        public Sale Sale { get; set; }
    }
}