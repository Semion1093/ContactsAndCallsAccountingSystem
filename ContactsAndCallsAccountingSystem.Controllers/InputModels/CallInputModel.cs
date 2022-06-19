using ContactsAndCallsAccountingSystem.BLL.Validation;

namespace ContactsAndCallsAccountingSystem.API.InputModels
{
    public class CallInputModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal BillingFirst { get; set; }
        public decimal BillingSecond{ get; set; }

        [PhoneNumberOnly]
        public string PhoneNumberFirst { get; set; } = string.Empty;

        [PhoneNumberOnly]
        public string PhoneNumberSecond { get; set; } = string.Empty;
    }
}
