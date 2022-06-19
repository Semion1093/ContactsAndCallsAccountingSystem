using AutoMapper;
using ContactsAndCallsAccountingSystem.BLL;
using ContactsAndCallsAccountingSystem.BLL.Interfaces;
using ContactsAndCallsAccountingSystem.BLL.Models;
using ContactsAndCallsAccountingSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsAndCallsAccountingSystem.DAL.Repositories
{
    public class CallRepository : ICallRepository
    {
        private readonly ContactsAndCallsAccountingSystemContext _context;
        private readonly IMapper _mapper;

        public CallRepository(ContactsAndCallsAccountingSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> AddCall(AddCallModel CallModel)
        {
            var call = _mapper.Map<Call>(CallModel);
            var addedCall = _context.Calls.Add(call);
            await _context.SaveChangesAsync();

            return addedCall.Entity.Id;
        }

        public async Task<Guid> AddConference(AddConferenceModel conferenceModel)
        {
            var conference = _mapper.Map<Call>(conferenceModel);
            var addedConference = _context.Calls.Add(conference);
            await _context.SaveChangesAsync();

            return addedConference.Entity.Id;
        }

        public async Task UpdateCall(CallModel callModel)
        {
            var call = _mapper.Map<Call>(callModel);
            _context.Update(call);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCall(Guid id)
        {
            _context.Entry(new Call { Id = id, IsDeleted = true })
                .Property(x => x.IsDeleted).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task<CallModel> GetCallById(Guid id)
        {
            var call = await _context.Calls
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<CallModel>(call);
        }

        public async Task<List<CallModel>> GetAllCalls()
        {
            var calls = await _context.Calls
                .Where(x => !x.IsDeleted)
                .Where(x => x.Calltype == CallType.Call)
                .Include(x => x.CallProfile)
                .SelectMany(x => x.CallProfile)
                .ToListAsync();

            return _mapper.Map<List<CallModel>>(calls);
        }

        public async Task<List<CallModel>> GetAllConferences()
        {
            var calls = await _context.Calls
                .Where(x => !x.IsDeleted)
                .Where(x => x.Calltype == CallType.Conference)
                .Include(x => x.CallProfile)
                .SelectMany(x => x.CallProfile)
                .ToListAsync();

            return _mapper.Map<List<CallModel>>(calls);
        }

        public async Task<List<CallModel>> GetAll()
        {
            var calls = await _context.Calls
                .Where(x => !x.IsDeleted)
                .Include(x => x.CallProfile)
                .SelectMany(x => x.CallProfile)
                .ToListAsync();

            return _mapper.Map<List<CallModel>>(calls);
        }

        public async Task<List<CallModel>> GetCallsByPeriodAndPhone(DateTime startDate, DateTime endDate, string phoneNumber)
        {
            var calls = await _context.Calls
                .Where(x => !x.IsDeleted)
                .Include(x => x.CallProfile.Where(y => y.PhoneProfile == phoneNumber))
                .Where(x => x.StartDate >= startDate && x.EndDate <= endDate)
                .ToListAsync();

            return _mapper.Map<List<CallModel>>(calls);
        }
    }
}
