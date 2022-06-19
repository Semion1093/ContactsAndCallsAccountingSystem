using ContactsAndCallsAccountingSystem.BLL.Models;

namespace ContactsAndCallsAccountingSystem.BLL.Interfaces
{
    public interface ICallRepository
    {
        Task<Guid> AddCall(AddCallModel CallModel);
        Task<Guid> AddConference(AddConferenceModel conferenceModel);
        Task DeleteCall(Guid id);
        Task<List<CallModel>> GetAll();
        Task<List<CallModel>> GetAllCalls();
        Task<List<CallModel>> GetAllConferences();
        Task<CallModel> GetCallById(Guid id);
        Task<List<CallModel>> GetCallsByPeriodAndPhone(DateTime startDate, DateTime endDate, string phoneNumber);
        Task UpdateCall(CallModel CallModel);
    }
}