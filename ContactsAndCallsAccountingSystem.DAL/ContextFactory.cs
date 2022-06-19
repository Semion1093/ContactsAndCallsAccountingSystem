namespace ContactsAndCallsAccountingSystem.DAL
{
    public class ContextFactory : IContextFactory
    {
        public ContactsAndCallsAccountingSystemContext GetContext()
        {
            return new ContactsAndCallsAccountingSystemContext();
        }
    }
}
