using CarDealership.Data.Factory;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult New()
        {
            ViewBag.Message = "New Vehicles.";

            var model = new InventoryVM();
            model.vehicles = VehicleRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }
        public ActionResult Used()
        {
            ViewBag.Message = "Used Vehicles.";

            var model = new InventoryVM();
            model.vehicles = VehicleRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            ViewBag.Message = "Vehicle Details.";
            var model = new InventoryVM();
            var repo = VehicleRepositoryFactory.GetRepository();
            model.vehicle = repo.GetByID(id);

            return View(model);
        }
    }
}