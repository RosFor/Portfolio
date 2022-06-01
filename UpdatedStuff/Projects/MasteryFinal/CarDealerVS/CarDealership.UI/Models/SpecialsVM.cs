using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class SpecialsVM : IValidatableObject
    {
        public List<Specials> SpecialsList { get; set; }
        public Specials Specials { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Specials.SpecialsTitle))
            {
                errors.Add(new ValidationResult("Title is required."));
            }
            if (string.IsNullOrEmpty(Specials.SpecialsDescription))
            {
                errors.Add(new ValidationResult("Description is required."));
            }
            return errors;
        }
    }
}