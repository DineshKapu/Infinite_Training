using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Custom_Validations_Prj.CustomValidations
{
    public class DOJValidation:ValidationAttribute
    {
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    DateTime doj = Convert.ToDateTime(value);
        //    var app = (JobApplication)validationContext.ObjectInstance;
        //    DateTime dob = app.birthdate;
        //    if(doj<dob)
        //        return new ValidationResult("Date of Joining cannot be earlier than Date of Birth");
        //    if (doj <= DateTime.Today)
        //        return ValidationResult.Success;
        //    else
        //        return new ValidationResult(ErrorMessage);
        //}

        public override bool IsValid(object value)
        {
            DateTime doj = Convert.ToDateTime(value);
            return doj <= DateTime.Today;
        }

    }
}