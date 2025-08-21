using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Custom_Validations_Prj.CustomValidations
{
    public class DOBValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dob = Convert.ToDateTime(value);
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (dob > today.AddYears(-age)) age--;

            if (age >= 21 && age <= 25)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}