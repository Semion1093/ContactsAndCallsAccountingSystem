namespace ContactsAndCallsAccountingSystem.BLL.Models
{
    public class CallModel
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Billing { get; set; }
        public IReadOnlyList<ProfileModel> ProfileModels { get; set; } = new List<ProfileModel>();
    }
}