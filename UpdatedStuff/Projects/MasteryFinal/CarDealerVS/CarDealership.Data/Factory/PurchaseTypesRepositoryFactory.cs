using CarDealership.Data.ADO;
using CarDealership.Data.Mock;
using CarDealership.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Factory
{
    public static class PurchaseTypesRepositoryFactory
    {
        public static IPurchaseTypesRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new PurchaseTypesRepositoryADO();
                case "Mock":
                    return new PurchaseTypesRepositoryMock();
                default:
                    throw new Exception("Could not find valid Repository configuration value.");

            }
        }
    }
}
