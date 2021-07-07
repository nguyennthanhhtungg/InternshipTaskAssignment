using System;
using System.ComponentModel.DataAnnotations;

namespace TaskAssignment.CustomValidations
{
    public class MoreOrEqual18YearsOldAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateTime = Convert.ToDateTime(value);

            if (value == null || DateTime.Now.AddYears(-18).CompareTo(dateTime) >= 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Age of employee must be more than equal 18 years old!");
            }
        }
    }
}
