using ContactsAndCallsAccountingSystem.BLL.Validation;
using System.ComponentModel.DataAnnotations;

namespace ContactsAndCallsAccountingSystem.API.InputModels
{
    public class ProfileInputModel
    {
        [Required(ErrorMessage = "Введите имя")]
        [TextOnly]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите фамилию")]
        [TextOnly]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите отчество")]
        [TextOnly]
        public string Patronymic { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите номер телефона")]
        [PhoneNumberOnly]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
