using CarDealership.Data.ADO;
using CarDealership.Data.Interface;
using CarDealership.Data.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Factory
{
    public static class BodyRepositoryFactory
    {
        public static IBodyRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new BodyRepositoryADO();
                case "Mock":
                    return new BodyRepositoryMock();
                default:
                    throw new Exception("Could not find valid Repository configuration value.");

            }
        }
    }
}
