namespace ContactsAndCallsAccountingSystem.BLL.Models
{
    public class AddCallModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal BillingFirst { get; set; }
        public decimal BillingSecond { get; set; }
        public string PhoneNumberFirst { get; set; } = string.Empty;
        public string PhoneNumberSecond { get; set; } = string.Empty;
    }
}
