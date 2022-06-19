using ContactsAndCallsAccountingSystem.BLL.Validation;

namespace ContactsAndCallsAccountingSystem.BLL.Models
{
    public class CallPhoneModel
    {
        public decimal Billing { get; set; }

        [PhoneNumberOnly]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
