using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Specials()
        {
            ViewBag.Message = "Specials.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us.";

            return View();
        }
    }
}