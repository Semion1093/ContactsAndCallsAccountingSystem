using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ContactsAndCallsAccountingSystem.BLL.Validation
{
    public class TextOnly : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            Regex regex = new(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$");

            string? strValue = value as string;

            return !regex.IsMatch(strValue) ? new ValidationResult("Введите текст") : null;
        }
    }
}
