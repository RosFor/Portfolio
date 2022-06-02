using CarDealership.Data.Factory;
using CarDealership.Models;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            ViewBag.Message = "Admin.";
            var model = new InventoryVM();
            model.vehicles = VehicleRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Specials()
        {
            ViewBag.Message = "Specials.";
            var model = new SpecialsVM();
            model.SpecialsList = SpecialsRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddSpecial()
        {
            var model = new SpecialsVM();

            model.Specials = new Specials();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddSpecial(SpecialsVM model)
        {
            if (ModelState.IsValid)
            {
                Specials specials = new Specials();
                specials.SpecialsTitle = model.Specials.SpecialsTitle;
                specials.SpecialsDescription = model.Specials.SpecialsDescription;

                var repo = SpecialsRepositoryFactory.GetRepository();
                repo.Insert(specials);
                return RedirectToAction("Specials");
            }
            else
            {
                return View(model);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Make()
        {
            ViewBag.Message = "Makes.";

            var model = new MakeVM();
            model.Make = new Make();
            model.MakeList = MakeRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Make(MakeVM model)
        {
            if (ModelState.IsValid)
            {
                Make make = new Make();
                make.MakeName = model.Make.MakeName;

                var repo = MakeRepositoryFactory.GetRepository();
                model.MakeList = repo.GetAll();
                repo.Insert(make);
                return RedirectToAction("Make");
            }
            else
            {
                model.MakeList = MakeRepositoryFactory.GetRepository().GetAll();
                return View(model);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Model()
        {
            ViewBag.Message = "Models.";

            var model = new VehicleModelVM();
            model.VehicleModel = new VehicleModel();
            model.VehicleModelList = VehicleModelRepositoryFactory.GetRepository().GetAll();

            var makeRepo = MakeRepositoryFactory.GetRepository();
            model.MakeList = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Model(VehicleModelVM model)
        {
            if (ModelState.IsValid)
            {
                
                VehicleModel vm = new VehicleModel();

                Make make = new Make();
                var makeRepo = MakeRepositoryFactory.GetRepository();
                vm.ModelName = model.VehicleModel.ModelName;
                vm.DateAdded = model.VehicleModel.DateAdded;
                make.MakeID = model.VehicleModel.Make.MakeID;
                make = makeRepo.GetByID(model.VehicleModel.Make.MakeID);
                vm.Make = make;

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = userManager.FindByName(User.Identity.Name);
                vm.UserEmail = user.Email;

                var repo = VehicleModelRepositoryFactory.GetRepository();
                repo.Insert(vm);
                return RedirectToAction("Model");
            }
            else
            {
                var makeRepo = MakeRepositoryFactory.GetRepository();
                model.MakeList = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");
                model.VehicleModelList = VehicleModelRepositoryFactory.GetRepository().GetAll();
                var repo = VehicleModelRepositoryFactory.GetRepository();
                return View(model);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeleteSpecial(int id)
        {
            var repo = SpecialsRepositoryFactory.GetRepository();
            repo.Delete(id);
            return RedirectToAction("Specials");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddVehicle()
        {
            ViewBag.Message = "Add Vehicle.";

            var model = new AdminAddVehicleVM();

            var makeRepo = MakeRepositoryFactory.GetRepository();
            var conditionRepo = ConditionRepositoryFactory.GetRepository();
            var bodyRepo = BodyRepositoryFactory.GetRepository();
            var transmissionRepo = TransmissionRepositoryFactory.GetRepository();
            var colorRepo = ColorRepositoryFactory.GetRepository();
            var intColorRepo = InteriorColorRepositoryFactory.GetRepository();

            model.Make = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");
            model.Condition = new SelectList(conditionRepo.GetAll(), "ConditionID", "ConditionType");
            model.BodyStyle = new SelectList(bodyRepo.GetAll(), "BodyID", "BodyStyle");
            model.Transmission = new SelectList(transmissionRepo.GetAll(), "TransmissionID", "TransmissionType");
            model.Color = new SelectList(colorRepo.GetAll(), "ColorID", "ColorName");
            model.InteriorColor = new SelectList(intColorRepo.GetAll(), "InteriorColorID", "InteriorColorName");
            model.Vehicle = new Vehicle();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddVehicle(AdminAddVehicleVM model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();

                try
                {

                    if (model.UploadImage != null && model.UploadImage.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.UploadImage.FileName);
                        string extension = Path.GetExtension(model.UploadImage.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        model.UploadImage.SaveAs(filePath);
                        model.Vehicle.VehicleImageFile = Path.GetFileName(filePath);
                    }

                    repo.Insert(model.Vehicle);

                    return RedirectToAction("EditVehicle", new { id = model.Vehicle.VehicleID});
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var makeRepo = MakeRepositoryFactory.GetRepository();
                var vehicleModelRepo = VehicleModelRepositoryFactory.GetRepository();
                var conditionRepo = ConditionRepositoryFactory.GetRepository();
                var bodyRepo = BodyRepositoryFactory.GetRepository();
                var transmissionRepo = TransmissionRepositoryFactory.GetRepository();
                var colorRepo = ColorRepositoryFactory.GetRepository();
                var intColorRepo = InteriorColorRepositoryFactory.GetRepository();

                model.Make = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");
                model.VehicleModel = new SelectList(vehicleModelRepo.GetAll(), "VehicleModelID", "ModelName");
                model.Condition = new SelectList(conditionRepo.GetAll(), "ConditionID", "ConditionType");
                model.BodyStyle = new SelectList(bodyRepo.GetAll(), "BodyID", "BodyStyle");
                model.Transmission = new SelectList(transmissionRepo.GetAll(), "TransmissionID", "TransmissionType");
                model.Color = new SelectList(colorRepo.GetAll(), "ColorID", "ColorName");
                model.InteriorColor = new SelectList(intColorRepo.GetAll(), "InteriorColorID", "InteriorColorName");

                return View(model);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            ViewBag.Message = "Edit Vehicle.";

            var model = new AdminEditVehicleVM();

            var makeRepo = MakeRepositoryFactory.GetRepository();
            /*var vehicleModelRepo = VehicleModelRepositoryFactory.GetRepository();*/
            var conditionRepo = ConditionRepositoryFactory.GetRepository();
            var bodyRepo = BodyRepositoryFactory.GetRepository();
            var transmissionRepo = TransmissionRepositoryFactory.GetRepository();
            var colorRepo = ColorRepositoryFactory.GetRepository();
            var intColorRepo = InteriorColorRepositoryFactory.GetRepository();
            var vehicleRepo = VehicleRepositoryFactory.GetRepository();

            model.Make = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");
            /*model.VehicleModel = new SelectList(vehicleModelRepo.GetAll(), "VehicleModelID", "ModelName");*/
            model.Condition = new SelectList(conditionRepo.GetAll(), "ConditionID", "ConditionType");
            model.BodyStyle = new SelectList(bodyRepo.GetAll(), "BodyID", "BodyStyle");
            model.Transmission = new SelectList(transmissionRepo.GetAll(), "TransmissionID", "TransmissionType");
            model.Color = new SelectList(colorRepo.GetAll(), "ColorID", "ColorName");
            model.InteriorColor = new SelectList(intColorRepo.GetAll(), "InteriorColorID", "InteriorColorName");
            
            model.Vehicle = vehicleRepo.GetByID(id);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditVehicle(AdminEditVehicleVM model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();

                try
                {
                    var oldVehicle = repo.GetByID(model.Vehicle.VehicleID);

                    if (model.UploadImage != null && model.UploadImage.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.UploadImage.FileName);
                        string extension = Path.GetExtension(model.UploadImage.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        model.UploadImage.SaveAs(filePath);
                        model.Vehicle.VehicleImageFile = Path.GetFileName(filePath);
                    }
                    else
                    {
                        // they did not replace the old file, so keep the old file name
                        model.Vehicle.VehicleImageFile = oldVehicle.VehicleImageFile;
                    }
                    oldVehicle.VehicleModel.VehicleModelID = model.Vehicle.VehicleModel.VehicleModelID;
                    oldVehicle.VehicleModel.Make.MakeID = model.Vehicle.VehicleModel.Make.MakeID;
                    oldVehicle.VinNumber = model.Vehicle.VinNumber;
                    repo.Update(model.Vehicle);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var makeRepo = MakeRepositoryFactory.GetRepository();
                /*var vehicleModelRepo = VehicleModelRepositoryFactory.GetRepository();*/
                var conditionRepo = ConditionRepositoryFactory.GetRepository();
                var bodyRepo = BodyRepositoryFactory.GetRepository();
                var transmissionRepo = TransmissionRepositoryFactory.GetRepository();
                var colorRepo = ColorRepositoryFactory.GetRepository();
                var intColorRepo = InteriorColorRepositoryFactory.GetRepository();
                var vehicleRepo = VehicleRepositoryFactory.GetRepository();

                model.Make = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");
                /*model.VehicleModel = new SelectList(vehicleModelRepo.GetAll(), "VehicleModelID", "ModelName");*/
                model.Condition = new SelectList(conditionRepo.GetAll(), "ConditionID", "ConditionType");
                model.BodyStyle = new SelectList(bodyRepo.GetAll(), "BodyID", "BodyStyle");
                model.Transmission = new SelectList(transmissionRepo.GetAll(), "TransmissionID", "TransmissionType");
                model.Color = new SelectList(colorRepo.GetAll(), "ColorID", "ColorName");
                model.InteriorColor = new SelectList(intColorRepo.GetAll(), "InteriorColorID", "InteriorColorName");

                model.Vehicle = vehicleRepo.GetByID(model.Vehicle.VehicleID);

                model.VehicleModel = model.Make;

                return View(model);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult DeleteVehicle(int id)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}