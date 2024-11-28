using System;
using System.ComponentModel.DataAnnotations;
using ASPNET10.Attributes;

public class ConsultationFormModel
{
    [Required(ErrorMessage = "Ім'я та прізвище є обов'язковими.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Email є обов'язковим.")]
    [EmailAddress(ErrorMessage = "Неправильний формат Email.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Вибір продукту є обов'язковим.")]
    public string Product { get; set; }

    [Required(ErrorMessage = "Дата консультації є обов'язковою.")]
    [FutureDate(ErrorMessage = "Дата повинна бути в майбутньому та не потрапляти на вихідний.")]
    [ProductDateValidation("Product", ErrorMessage = "Консультації щодо 'Основи' не проводяться по понеділках.")]
    public DateTime? ConsultationDate { get; set; }
}