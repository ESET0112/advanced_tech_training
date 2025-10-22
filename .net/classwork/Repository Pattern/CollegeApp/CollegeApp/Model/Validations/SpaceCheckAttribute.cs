using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CollegeApp.Model.Validations
{
    public class DateCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = value as DateTime?;

            if (date == null)
            {
                return new ValidationResult("Please enter a date.");
            }

            // Compare only date part (ignore time)
            if (date.Value.Date <= DateTime.Now.Date)
            {
                return new ValidationResult("Date must be greater than today's date.");
            }

            return ValidationResult.Success;
        }
    }

    // ✅ Space Validation - no spaces allowed
    public class SpaceCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var input = value as string;

            if (string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult("Please enter a valid value.");
            }

            if (input.Contains(" "))
            {
                return new ValidationResult("Spaces are not allowed.");
            }

            return ValidationResult.Success;
        }
    }
    public class CapitalCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var input = value as string;
            if ( ! Regex.IsMatch(input, @"^[A-Z]"))
            {
                return new ValidationResult("First Letter must be Capital");
            }

            return ValidationResult.Success;
        }
    }
}
