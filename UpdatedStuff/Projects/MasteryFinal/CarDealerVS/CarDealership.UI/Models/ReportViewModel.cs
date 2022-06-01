using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class ReportViewModel
    {
        public IEnumerable<Vehicle> ReportNew { get; set; }
        public IEnumerable<Vehicle> ReportUsed { get; set; }
    }
}