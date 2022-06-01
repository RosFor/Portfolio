using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Mock
{
    public class VehicleModelRepositoryMock : IVehicleModelRepository
    {
        public List<VehicleModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public VehicleModel GetByID(int vehicleModelID)
        {
            throw new NotImplementedException();
        }

        public void Insert(VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }
    }
}
