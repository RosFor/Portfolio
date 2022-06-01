using CarDealership.Data.Factory;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class VehicleModelVM : IValidatableObject
    {
        public List<VehicleModel> VehicleModelList { get; set; }
        public IEnumerable<SelectListItem> MakeList { get; set; }
        public VehicleModel VehicleModel { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(VehicleModel.ModelName))
            {
                errors.Add(new ValidationResult("Model name name is required."));
            }
            var repo = VehicleModelRepositoryFactory.GetRepository();
            VehicleModelList = repo.GetAll();
            if (VehicleModelList.Where(x => x.ModelName == VehicleModel.ModelName).FirstOrDefault() != null)
            {
                errors.Add(new ValidationResult("Model name already exists."));
            }
            //Tried:
            //VehicleModel.ModelName == VehicleModel.ModelName
            //VehicleModelList.Any(x => x.ModelName.Contains(VehicleModel.ModelName))
            return errors;
        }
    }
}