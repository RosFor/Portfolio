using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending.Model.Responses
{
    public class DepositResponse : Response
    {
        public Product Product { get; set; }
        public Change Change { get; set; }
        public decimal AmountInserted { get; set; }
    }
}
