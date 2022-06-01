using CarDealership.Data.Factory;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            ViewBag.Message = "Reports.";
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Inventory()
        {
            ViewBag.Message = "Inventory Report.";

            var model = new ReportViewModel();
            model.ReportNew = VehicleRepositoryFactory.GetRepository().ReportsNew();
            model.ReportUsed = VehicleRepositoryFactory.GetRepository().ReportsUsed();
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult ReportSales()
        {
            ViewBag.Message = "Sales Report.";
            var model = new ReportSearchVM();
            model.Sales = SaleRepositoryFactory.GetRepository().ReportSale();
            return View(model);
        }
    }
}