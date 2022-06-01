using CarDealership.Data.Factory;
using CarDealership.Models;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        [Authorize(Roles = "Sales")]
        public ActionResult Index()
        {
            ViewBag.Message = "Sales.";
            var model = new InventoryVM();
            model.vehicles = VehicleRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        [Authorize(Roles = "Sales")]
        [HttpGet]
        public ActionResult PurchaseVehicle(int id)
        {
            ViewBag.Message = "Purchase Vehicle.";

            var model = new PurchaseVehicleVM();

            var stateRepo = StatesRepositoryFactory.GetRepository();
            var purchaseTypeRepo = PurchaseTypesRepositoryFactory.GetRepository();
            var vehicleRepo = VehicleRepositoryFactory.GetRepository();

            model.States = new SelectList(stateRepo.GetAll(), "StateID", "StateName");
            model.PurchaseTypes = new SelectList(purchaseTypeRepo.GetAll(), "PurchaseTypeID", "PurchaseType");
            model.Sale = new Sale();
            model.Vehicle = vehicleRepo.GetByID(id);

            return View(model);
        }

        [Authorize(Roles = "Sales")]
        [HttpPost]
        public ActionResult PurchaseVehicle(PurchaseVehicleVM model)
        {
            if (ModelState.IsValid)
            {
                Sale sale = new Sale();
                sale.CustomerName = model.Sale.CustomerName;
                sale.CustomerPhone = model.Sale.CustomerPhone;
                sale.CustomerEmail = model.Sale.CustomerEmail;
                sale.CustomerStreet1 = model.Sale.CustomerStreet1;
                sale.CustomerStreet2 = model.Sale.CustomerStreet2;
                sale.CustomerCity = model.Sale.CustomerCity;
                sale.CustomerZip = model.Sale.CustomerZip;
                sale.SalePurchasePrice = model.Sale.SalePurchasePrice;
                sale.SalePurchaseDate = model.Sale.SalePurchaseDate;

                States state = new States();
                state.StateID = model.Sale.States.StateID;
                //state.StateName = model.Sale.States.StateName;
                //state.StateAbbreviation = model.Sale.States.StateAbbreviation;

                PurchaseTypes PT = new PurchaseTypes();
                PT.PurchaseTypeID = model.Sale.PurchaseType.PurchaseTypeID;
                //PT.PurchaseType = model.Sale.PurchaseType.PurchaseType;

                Vehicle vehicle = new Vehicle();
                var vehicleRepo = VehicleRepositoryFactory.GetRepository();
                vehicle.VehicleID = model.Vehicle.VehicleID;
                vehicle = vehicleRepo.GetByID(model.Vehicle.VehicleID);
                vehicleRepo.SaleUpdate(model.Vehicle);

                sale.States = state;
                sale.PurchaseType = PT;
                sale.Vehicle = vehicle;

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = userManager.FindByName(User.Identity.Name);
                sale.UserEmail = user.Email;
                
                var repo = SaleRepositoryFactory.GetRepository();
                sale.Vehicle.IsFeatured = false;
                sale.Vehicle.IsSold = true;
                repo.Insert(sale);

                
                /*vehicleRepo.Update(model.Vehicle);*/
                //Update Car as having been sold - method on Interface/repo that takes in an ID
                //Calls Stored Proc that takes in an ID and sets isfeatured to false and IsSold to True
                //MarkAsSold to override
                return RedirectToAction("Index");
            }
            else
            {
                var stateRepo = StatesRepositoryFactory.GetRepository();
                var purchaseTypeRepo = PurchaseTypesRepositoryFactory.GetRepository();
                var vehicleRepo = VehicleRepositoryFactory.GetRepository();

                model.States = new SelectList(stateRepo.GetAll(), "StateID", "StateName");
                model.PurchaseTypes = new SelectList(purchaseTypeRepo.GetAll(), "PurchaseTypeID", "PurchaseType");
                model.Vehicle = vehicleRepo.GetByID(model.Vehicle.VehicleID);

                return View(model);
            }
        }
    }
}