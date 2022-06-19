namespace ContactsAndCallsAccountingSystem.API.OutputModels
{
    public class CallOutputModel
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Billing { get; set; }
    }
}
