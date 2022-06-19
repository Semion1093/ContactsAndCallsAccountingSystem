using ContactsAndCallsAccountingSystem.BLL.Models;

namespace ContactsAndCallsAccountingSystem.BLL.Interfaces
{
    public interface ICallService
    {
        Task AddCall(AddCallModel callModels);
        Task AddConference(AddConferenceModel conferenceModel);
        Task DeleteCall(Guid id);
        Task<List<CallModel>> GetAll();
        Task<List<CallModel>> GetAllCalls();
        Task<List<CallModel>> GetAllConferences();
        Task<List<CallModel>> GetCallsByPeriodAndPhone(DateTime startDate, DateTime endDate, string phoneNumber);
        Task UpdateCall(CallModel callModel);
    }
}