namespace ContactsAndCallsAccountingSystem.BLL.Exсeptions
{
    internal class ConflictException : Exception
    {
        public ConflictException(string message) : base(message) { }
    }
}
