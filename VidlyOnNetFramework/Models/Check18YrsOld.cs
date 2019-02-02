using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyOnNetFramework.Models
{
    public class Check18YrsOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Customer
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required for register");
            }
            else if(DateTime.Now.Year - customer.BirthDate.Value.Year > 18)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Birthdate is less than 18");
            }
        }
    }
}