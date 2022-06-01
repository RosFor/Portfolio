using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Mock
{
    public class VehicleRepositoryMock : IVehicleRepository
    {
        public void Delete(int vehicleID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> FeaturedVehicles()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetByID(int vehicleID)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetDetails(int vehicleID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> ReportSearch(ReportSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> ReportsNew()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> ReportsUsed()
        {
            throw new NotImplementedException();
        }

        public Vehicle SaleUpdate(int vehicleID)
        {
            throw new NotImplementedException();
        }

        public void SaleUpdate(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> SearchNew(VehicleSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> SearchNewAndUsed(VehicleSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> SearchUsed(VehicleSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
