using ContactsAndCallsAccountingSystem.BLL.Models;

namespace ContactsAndCallsAccountingSystem.API.InputModels
{
    public class ConferenceInputModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IReadOnlyList<CallPhoneModel> CallPhoneModel { get; set; } = new List<CallPhoneModel>();
    }
}
