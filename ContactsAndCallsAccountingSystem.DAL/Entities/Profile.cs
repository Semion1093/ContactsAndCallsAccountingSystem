using System.ComponentModel.DataAnnotations;

namespace ContactsAndCallsAccountingSystem.DAL.Entities
{
    public class Profile
    {
        [Key]
        public string PhoneNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public virtual ICollection<CallProfile> CallProfile { get; set; } = new List<CallProfile>();
        public bool IsDeleted { get; set; }
    }
}
