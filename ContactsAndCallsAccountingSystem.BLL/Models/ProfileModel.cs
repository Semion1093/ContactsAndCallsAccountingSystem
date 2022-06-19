namespace ContactsAndCallsAccountingSystem.BLL.Models
{
    public class ProfileModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public IReadOnlyList<CallModel> CallModels { get; set; } = new List<CallModel>();
    }
}
