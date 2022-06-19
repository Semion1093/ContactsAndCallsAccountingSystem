namespace ContactsAndCallsAccountingSystem.DAL
{
    public interface IContextFactory
    {
        ContactsAndCallsAccountingSystemContext GetContext();
    }
}
