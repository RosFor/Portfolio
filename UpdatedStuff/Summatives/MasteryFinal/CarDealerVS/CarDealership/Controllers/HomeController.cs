using CarDealership.Data.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = VehicleRepositoryFactory.GetRepository().FeaturedVehicles();
            return View(model);
        }
    }
}