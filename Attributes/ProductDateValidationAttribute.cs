using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

public class ProductDateValidationAttribute : ValidationAttribute
{
    private readonly string _productProperty;

    public ProductDateValidationAttribute(string productProperty)
    {
        _productProperty = productProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var productProperty = validationContext.ObjectType.GetProperty(_productProperty);
        if (productProperty == null)
        {
            return new ValidationResult($"Поле '{_productProperty}' не знайдено.");
        }

        var productValue = productProperty.GetValue(validationContext.ObjectInstance)?.ToString();

        if (productValue != "Основи")
        {
            return ValidationResult.Success;
        }

        if (value is DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Monday)
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }
}