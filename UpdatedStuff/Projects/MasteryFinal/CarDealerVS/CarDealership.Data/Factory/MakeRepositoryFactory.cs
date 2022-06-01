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
    public static class MakeRepositoryFactory
    {
        public static IMakeRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new MakeRepositoryADO();
                case "Mock":
                    return new MakeRepositoryMock();
                default:
                    throw new Exception("Could not find valid Repository configuration value.");

            }
        }
    }
}
