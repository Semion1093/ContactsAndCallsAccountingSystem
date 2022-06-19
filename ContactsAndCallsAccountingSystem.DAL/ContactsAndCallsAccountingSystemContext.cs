using ContactsAndCallsAccountingSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsAndCallsAccountingSystem.DAL
{
    public class ContactsAndCallsAccountingSystemContext : DbContext
    {
        public ContactsAndCallsAccountingSystemContext() { }
        public ContactsAndCallsAccountingSystemContext(
            DbContextOptions<ContactsAndCallsAccountingSystemContext> options) : base(options) { }

        public DbSet<Call> Calls { get; set; }
        public DbSet<CallProfile> CallProfile { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CallProfile>()
                .HasOne(x => x.Call)
                .WithMany(m => m.CallProfile)
                .HasForeignKey(x => x.CallId);

            modelBuilder.Entity<CallProfile>()
                .HasOne(x => x.Profile)
                .WithMany(e => e.CallProfile)
                .HasForeignKey(x => x.PhoneProfile);

            modelBuilder.Entity<Call>()
                .Property(a => a.IsDeleted)
                .HasDefaultValue(0);

            modelBuilder.Entity<Profile>()
                .Property(a => a.IsDeleted)
                .HasDefaultValue(0);
        }
    }
}
