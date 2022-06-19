using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsAndCallsAccountingSystem.DAL.Entities
{
    public class CallProfile
    {
        public Guid Id { get; set; }
        public Profile Profile { get; set; }
        public string PhoneProfile { get; set; } = string.Empty;
        public Call Call { get; set; }
        public Guid CallId { get; set; }
        public decimal Billing { get; set; }
    }
}
