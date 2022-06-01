using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class PurchaseVehicleVM : IValidatableObject
    {
        public Sale Sale { get; set; }
        public Vehicle Vehicle { get; set; }
        /*public Make Make { get; set; }*/
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> PurchaseTypes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Sale.CustomerName))
            {
                errors.Add(new ValidationResult("Customer name is required."));
            }
            if (string.IsNullOrEmpty(Sale.CustomerEmail) && string.IsNullOrEmpty(Sale.CustomerPhone))
            {
                errors.Add(new ValidationResult("Either phone or e-mail is required."));
            }
            if (string.IsNullOrEmpty(Sale.CustomerStreet1))
            {
                errors.Add(new ValidationResult("Street address is required."));
            }
            if (string.IsNullOrEmpty(Sale.CustomerCity))
            {
                errors.Add(new ValidationResult("City is required."));
            }
            if (string.IsNullOrEmpty(Sale.CustomerZip))
            {
                errors.Add(new ValidationResult("Zip code is required."));
            }
            if (Sale.SalePurchasePrice < (Vehicle.SalePrice * (95.00m / 100.00m)))
            {
                errors.Add(new ValidationResult("Purchase price cannot be less than 95% of the sales price."));
            }
            if (Sale.SalePurchasePrice > Vehicle.MSRP)
            {
                errors.Add(new ValidationResult("Purchase price cannot exceed the MSRP."));
            }

            return errors;
        }
    }
}