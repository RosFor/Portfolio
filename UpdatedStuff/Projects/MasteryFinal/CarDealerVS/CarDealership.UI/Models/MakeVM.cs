using CarDealership.Data.Factory;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class MakeVM : IValidatableObject
    {
        public List<Make> MakeList { get; set; }
        public Make Make { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Make.MakeName))
            {
                errors.Add(new ValidationResult("Make name is required."));
            }
            var repo = MakeRepositoryFactory.GetRepository();
            MakeList = repo.GetAll();
            if (MakeList.Where(x => x.MakeName == Make.MakeName).FirstOrDefault() != null)
            {
                errors.Add(new ValidationResult("Make name already exists."));
            }

            return errors;
        }
    }
}