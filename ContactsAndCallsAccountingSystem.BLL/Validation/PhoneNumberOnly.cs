using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ContactsAndCallsAccountingSystem.BLL.Validation
{
    public class PhoneNumberOnly : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            Regex regex = new(@"^\+\d{1}-\d{3}-\d{3}-\d{2}-\d{2}$");

            string? strValue = value as string;

            return !regex.IsMatch(strValue) ? new ValidationResult("Введите номер телефона в формате +Х-ХХХ-ХХХ-ХХ-ХХ") : null;
        }
    }
}
