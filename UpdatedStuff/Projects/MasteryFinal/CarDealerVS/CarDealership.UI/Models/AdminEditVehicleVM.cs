using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AdminEditVehicleVM : IValidatableObject
    {
        public Vehicle Vehicle { get; set; }
        public IEnumerable<SelectListItem> Make { get; set; }
        public IEnumerable<SelectListItem> VehicleModel { get; set; }
        public IEnumerable<SelectListItem> Condition { get; set; }
        public IEnumerable<SelectListItem> BodyStyle { get; set; }
        public IEnumerable<SelectListItem> Transmission { get; set; }
        public IEnumerable<SelectListItem> Color { get; set; }
        public IEnumerable<SelectListItem> InteriorColor { get; set; }
        public HttpPostedFileBase UploadImage { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Vehicle.VehicleDescription))
            {
                errors.Add(new ValidationResult("Description is required."));
            }
            if (string.IsNullOrEmpty(Vehicle.VinNumber))
            {
                errors.Add(new ValidationResult("VIN Number is required."));
            }
            if ((Vehicle.VehicleYear < 2000) || (Vehicle.VehicleYear > (DateTime.Today.Year + 1)))
            {
                errors.Add(new ValidationResult("Vehicle year must be between 2000 & one year greater than this year."));
            }
            if ((Vehicle.Condition.ConditionID == 1) && (Vehicle.Mileage < 0))
            {
                errors.Add(new ValidationResult("New vehicles must have mileage between 0 and 1000."));
            }
            if ((Vehicle.Condition.ConditionID == 1) && (Vehicle.Mileage > 1000))
            {
                errors.Add(new ValidationResult("New vehicles must have mileage between 0 and 1000."));
            }
            if ((Vehicle.Condition.ConditionID == 2) && (Vehicle.Mileage < 1000))
            {
                errors.Add(new ValidationResult("Used vehicles must have mileage greater than 1000."));
            }
            if (Vehicle.MSRP >= 1000000)
            {
                errors.Add(new ValidationResult("MSRP price must be less than $1,000,000."));
            }
            if (Vehicle.MSRP < 1000)
            {
                errors.Add(new ValidationResult("MSRP price must be greater than $1000."));
            }
            if (Vehicle.SalePrice <= 0)
            {
                errors.Add(new ValidationResult("Sale price must be greater than $0."));
            }
            if (Vehicle.SalePrice > Vehicle.MSRP)
            {
                errors.Add(new ValidationResult("Sale price may not exceed MSRP price."));
            }
            if (UploadImage == null)
            {
                errors.Add(new ValidationResult("Vehicle must have an image."));
            }
            if (UploadImage != null && UploadImage.ContentLength > 0)
            {
                var extensions = new string[] { ".png", ".jpg", ".jpeg" };

                var extension = Path.GetExtension(UploadImage.FileName);

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a png, jpg, or jpeg."));
                }
            }

            return errors;
        }
    }
}