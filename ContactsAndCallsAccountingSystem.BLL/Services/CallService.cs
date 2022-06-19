using ContactsAndCallsAccountingSystem.BLL.Exeptions;
using ContactsAndCallsAccountingSystem.BLL.Exсeptions;
using ContactsAndCallsAccountingSystem.BLL.Interfaces;
using ContactsAndCallsAccountingSystem.BLL.Models;

namespace ContactsAndCallsAccountingSystem.BLL.Services
{
    public class CallService : ICallService
    {
        private readonly ICallRepository _callRepository;
        private readonly IProfileRepository _profileRepository;

        public CallService(ICallRepository callRepository, IProfileRepository contactRepository)
        {
            _callRepository = callRepository;
            _profileRepository = contactRepository;
        }

        public async Task AddCall(AddCallModel callModel)
        {
            var profileFirst = await _profileRepository.GetProfileByPhoneNumber(callModel.PhoneNumberFirst);
            var profileSecond = await _profileRepository.GetProfileByPhoneNumber(callModel.PhoneNumberSecond);

            if (profileFirst is null)
            {
                throw new ConflictException($"Номер телефона {callModel.PhoneNumberFirst} отсутствует в базе данных");
            }

            if (profileSecond is null)
            {
                throw new ConflictException($"Номер телефона {callModel.PhoneNumberSecond} отсутствует в базе данных");
            }

            await _callRepository.AddCall(callModel);
        }

        public async Task AddConference(AddConferenceModel conferenceModel)
        {
            foreach(var phone in conferenceModel.CallPhoneModel)
            {
                var phoneNumber = await _profileRepository.GetProfileByPhoneNumber(phone.PhoneNumber);

                if (phoneNumber is null)
                {
                    throw new ConflictException($"Номер телефона {phone.PhoneNumber} отсутствует в базе данных");
                }
            }
            await _callRepository.AddConference(conferenceModel);
        }

        public async Task UpdateCall(CallModel callModel)
        {
            var exitingCall = await _callRepository.GetCallById(callModel.Id);

            if (exitingCall is null)
            {
                throw new EntityNotFoundException($"Звонок не был найден");
            }

            await _callRepository.UpdateCall(callModel);
        }

        public async Task DeleteCall(Guid id)
        {
            var exitingCall = await _callRepository.GetCallById(id);

            if (exitingCall is null)
            {
                throw new EntityNotFoundException($"Звонок не был найден");
            }

            await _callRepository.DeleteCall(id);
        }

        public async Task<List<CallModel>> GetAll()
        {
            var calls = await _callRepository.GetAll();

            return calls;
        }

        public async Task<List<CallModel>> GetAllCalls()
        {
            var calls = await _callRepository.GetAllCalls();

            return calls;
        }
        public async Task<List<CallModel>> GetAllConferences()
        {
            var calls = await _callRepository.GetAllConferences();

            return calls;
        }

        public async Task<List<CallModel>> GetCallsByPeriodAndPhone(DateTime startDate, DateTime endDate, string phoneNumber)
        {
            var calls = await _callRepository.GetCallsByPeriodAndPhone(startDate, endDate, phoneNumber);

            return calls;
        }
    }
}
