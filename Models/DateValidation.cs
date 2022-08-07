#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class DateValidation : ValidationAttribute
{
    protected bool UnderEighteen(DateTime dateOfBirth)
    {
        DateTime eighteenthBday = dateOfBirth.AddYears(18);
        if (eighteenthBday <= DateTime.Now)
        {
            return false;
        }
        return true;
    }

    protected override ValidationResult? IsValid(object dateOfBirth, ValidationContext validationContext)
    {
        if((DateTime)dateOfBirth > DateTime.Now)
        {
            return new ValidationResult("Must be a date in the past!");
        }
        else if(this.UnderEighteen((DateTime)dateOfBirth))
        {
            return new ValidationResult("Must be over 18!");
        }
        return ValidationResult.Success;
    }
}