using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class ContactVM : IValidatableObject
    {
        public Contact Contact { get; set; }
        public string VinNumber { get; set; }

        public ContactVM()
        {
            Contact = new Contact();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Contact.ContactName))
            {
                errors.Add(new ValidationResult("Name is required."));
            }

            if (string.IsNullOrEmpty(Contact.ContactEmail) && string.IsNullOrEmpty(Contact.ContactPhone))
            {
                errors.Add(new ValidationResult("Choose one: email or phone is required."));
            }

            if (string.IsNullOrEmpty(Contact.ContactMessage))
            {
                errors.Add(new ValidationResult("Message is required."));
            }

            /*if (this.Contact != null)
            {
                if (string.IsNullOrEmpty(Contact.ContactName))
                {
                    errors.Add(new ValidationResult("Name is required."));
                }

                if (string.IsNullOrEmpty(Contact.ContactEmail) && string.IsNullOrEmpty(Contact.ContactPhone))
                {
                    errors.Add(new ValidationResult("Choose one: email or phone is required."));
                }

                if (string.IsNullOrEmpty(Contact.ContactMessage))
                {
                    errors.Add(new ValidationResult("Message is required."));
                }
            }*/

            return errors;
        }
    }
}