using ContactsAndCallsAccountingSystem.BLL;

namespace ContactsAndCallsAccountingSystem.DAL.Entities
{
    public class Call
    {
        public Guid Id { get; set; }
        public CallType Calltype { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<CallProfile> CallProfile { get; set; } = new List<CallProfile>();
        public bool IsDeleted { get; set; }
    }
}
