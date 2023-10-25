using System.ComponentModel.DataAnnotations;

namespace QuarterlySalesApp11.Models.Validation
{
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext ctx)
        {
            if (value is DateTime)
            {
                DateTime datetoCheck = (DateTime)value;

                if (datetoCheck < DateTime.Today)
                {
                    return ValidationResult.Success;
                }
            }

            string msg = base.ErrorMessage ?? $"{ctx.DisplayName} must be a valid past date";

            return new ValidationResult(msg);
        }
    }
}
