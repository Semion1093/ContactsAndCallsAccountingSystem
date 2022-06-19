using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsAndCallsAccountingSystem.DAL.Entities
{
    public class CallProfile
    {
        public Guid Id { get; set; }
        public Profile Profile { get; set; } = new Profile();
        public string PhoneProfile { get; set; } = string.Empty;
        public Call Call { get; set; } = new Call();
        public Guid CallId { get; set; }
        public decimal Billing { get; set; }
    }
}
