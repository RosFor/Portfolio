using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class VehicleSearchParameters
    {
        public string SearchTerm { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
