namespace ContactsAndCallsAccountingSystem.BLL.Models
{
    public class AddConferenceModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IReadOnlyList<CallPhoneModel> CallPhoneModel { get; set; } = new List<CallPhoneModel>();
    }
}
