using CarDealership.Data.ADO;
using CarDealership.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.ProdTests
{
    [TestFixture]
    public class CRUDVehicleTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        [Test]
        public void ReadAllTestCanLoadAllNotSoldVehicles()
        {
            var repo = new VehicleRepositoryADO();

            var vehicles = repo.GetAll();

            Assert.AreEqual(12, vehicles.Count);

            Assert.AreEqual(2, vehicles[0].VehicleID);
            Assert.AreEqual(2019, vehicles[0].VehicleYear);
            Assert.AreEqual(22222, vehicles[0].Mileage);
            Assert.AreEqual("1G1JC1243T7246823", vehicles[0].VinNumber);
            Assert.AreEqual("Used black automatic Cadillac Escalade, with grey interior.", vehicles[0].VehicleDescription);
            Assert.AreEqual(70000.00, vehicles[0].MSRP);
        }
        [Test]
        public void ReadByIDTestCanLoadByID()
        {
            var repo = new VehicleRepositoryADO();
            var vehicle = repo.GetByID(1);

            Assert.IsNotNull(vehicle);

            Assert.AreEqual(1, vehicle.VehicleID);
            Assert.AreEqual(1, vehicle.VehicleModel.VehicleModelID);
            Assert.AreEqual(2, vehicle.Condition.ConditionID);
            Assert.AreEqual(1, vehicle.Body.BodyID);
            Assert.AreEqual(2, vehicle.Transmission.TransmissionID);
            Assert.AreEqual(7, vehicle.Color.ColorID);
            Assert.AreEqual(5, vehicle.InteriorColor.InteriorColorID);
            Assert.AreEqual(1974, vehicle.VehicleYear);
            Assert.AreEqual(11111, vehicle.Mileage);
            Assert.AreEqual("JKBVNKD167A013982", vehicle.VinNumber);
            Assert.AreEqual("Used blue-grey automatic Cadillac DeVille , with grey interior.", vehicle.VehicleDescription);
            Assert.AreEqual("CarIMG.png", vehicle.VehicleImageFile);
            Assert.AreEqual(15000.00, vehicle.MSRP);
            Assert.AreEqual(12000.00, vehicle.SalePrice);
            Assert.AreEqual(false, vehicle.IsFeatured);
            Assert.AreEqual(true, vehicle.IsSold);
        }
        [Test]
        public void CreateTestCanAddVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();

            VehicleModel vmToAdd = new VehicleModel();
            Make mToAdd = new Make();
            Condition cnToAdd = new Condition();
            Body bToAdd = new Body();
            Transmission tToAdd = new Transmission();
            Color crToAdd = new Color();
            InteriorColor icToAdd = new InteriorColor();
            var repo = new VehicleRepositoryADO();

            vmToAdd.VehicleModelID = 1;
            mToAdd.MakeID = 1;
            cnToAdd.ConditionID = 1;
            bToAdd.BodyID = 3;
            tToAdd.TransmissionID = 2;
            crToAdd.ColorID = 4;
            icToAdd.InteriorColorID = 5;
            vehicleToAdd.VehicleYear = 2022;
            vehicleToAdd.Mileage = 0;
            vehicleToAdd.VinNumber = "12345678901234567";
            vehicleToAdd.MSRP = 10000;
            vehicleToAdd.SalePrice = 1000;
            vehicleToAdd.VehicleDescription = "An added car test.";
            vehicleToAdd.VehicleImageFile = "CarIMG.png";

            vehicleToAdd.DateAdded = DateTime.Now;

            vehicleToAdd.VehicleModel = vmToAdd;
            vehicleToAdd.VehicleModel.Make = mToAdd;
            vehicleToAdd.Condition = cnToAdd;
            vehicleToAdd.Body = bToAdd;
            vehicleToAdd.Transmission = tToAdd;
            vehicleToAdd.Color = crToAdd;
            vehicleToAdd.InteriorColor = icToAdd;

            repo.Insert(vehicleToAdd);

            Assert.AreEqual(19, vehicleToAdd.VehicleID);
        }
        [Test]
        public void DeleteTestCanDeleteVehicle()
        {
            Vehicle listingToAdd = new Vehicle();
            var repo = new VehicleRepositoryADO();

            var loaded = repo.GetByID(2);
            Assert.IsNotNull(loaded);

            repo.Delete(2);
            loaded = repo.GetByID(2);

            Assert.IsNull(loaded);
        }
    }
}
