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
    public static class InteriorColorRepositoryFactory
    {
        public static IInteriorColorRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new InteriorColorRepositoryADO();
                case "Mock":
                    return new InteriorColorRepositoryMock();
                default:
                    throw new Exception("Could not find valid Repository configuration value.");

            }
        }
    }
}
