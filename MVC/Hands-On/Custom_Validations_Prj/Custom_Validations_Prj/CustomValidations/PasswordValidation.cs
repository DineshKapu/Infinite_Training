using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
namespace Custom_Validations_Prj.CustomValidations
{
    public class PasswordValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = Convert.ToString(value);
            Regex pattern = new Regex(@"^[A-Z][0-9].{5}$");

            if (pattern.IsMatch(password))
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}