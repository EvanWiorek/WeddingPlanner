
using System.ComponentModel.DataAnnotations;

public class FutureDateAttribute : ValidationAttribute
{
  protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
  {
    if ((DateTime?)value < DateTime.Now)
    {
      return new ValidationResult("Wedding must be after today's date.");
    }
    else
    {
      return ValidationResult.Success;
    }
  }
}