using System.ComponentModel.DataAnnotations;

public class NotEmptyAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string str && string.IsNullOrWhiteSpace(str))
        {
            return new ValidationResult($"The field {validationContext.MemberName} cannot be empty.");
        }


        return ValidationResult.Success;
    }
}
