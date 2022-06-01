using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Controller;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingController controller = new VendingController();
            controller.Run();
        }
    }
}
