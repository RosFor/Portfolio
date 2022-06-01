using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interface
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAll();
        Vehicle GetByID(int vehicleID);
        void Insert(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(int vehicleID);
        void SaleUpdate(Vehicle vehicle);
        IEnumerable<Vehicle> FeaturedVehicles();
        IEnumerable<Vehicle> SearchNew(VehicleSearchParameters parameters);
        IEnumerable<Vehicle> SearchUsed(VehicleSearchParameters parameters);
        IEnumerable<Vehicle> SearchNewAndUsed(VehicleSearchParameters parameters);
        IEnumerable<Vehicle> ReportsNew();
        IEnumerable<Vehicle> ReportsUsed();
    }
}
