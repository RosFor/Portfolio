using CarDealership.Data.Factory;
using CarDealership.Models;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeIndexVM();
            model.specials = SpecialsRepositoryFactory.GetRepository().GetAll();
            model.vehicles = VehicleRepositoryFactory.GetRepository().FeaturedVehicles();
            return View(model);
        }

        public ActionResult Specials()
        {
            ViewBag.Message = "Specials.";
            var model = SpecialsRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ContactVM model = new ContactVM();

            string url = Request.RawUrl;
            if(url.Length > 15)
            {
                string vin = url.Substring(24);
                model.Contact.ContactMessage = "VIN #: " + vin;
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactVM model)
        {
            var repo = ContactRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                Contact contact = new Contact();
                contact.ContactName = model.Contact.ContactName;
                contact.ContactEmail = model.Contact.ContactEmail;
                contact.ContactPhone = model.Contact.ContactPhone;
                contact.ContactMessage = model.Contact.ContactMessage;

                repo.Insert(contact);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}