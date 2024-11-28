using System.ComponentModel.DataAnnotations;

namespace ASPNET10.Attributes;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime date)
        {
            if (date <= DateTime.Now)
                return new ValidationResult("Дата повинна бути в майбутньому.");
            
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return new ValidationResult("Дата не повинна бути на вихідний.");
        }

        return ValidationResult.Success;
    }
}