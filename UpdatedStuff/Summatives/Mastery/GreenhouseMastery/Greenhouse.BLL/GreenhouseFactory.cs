using Greenhouse.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.BLL
{
    public static class GreenhouseFactory
    {
        public static GreenhouseManager CreateMode()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "LiveData":
                    return new GreenhouseManager(new OrderRepository(), new ProductRepository(), new TaxRepository());
                case "MockData":
                    return new GreenhouseManager(new MockOrderRespository(), new ProductRepository(), new TaxRepository());
                default:
                    throw new Exception("Contact IT: Mode not supported.");
            }
        }
    }
}
