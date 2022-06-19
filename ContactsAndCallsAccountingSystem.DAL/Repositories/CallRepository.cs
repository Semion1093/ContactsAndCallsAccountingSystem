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
        private readonly IContextFactory _context;
        private readonly IMapper _mapper;

        public CallRepository(IContextFactory context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> AddCall(AddCallModel CallModel)
        {
            var call = _mapper.Map<Call>(CallModel);
            var context = _context.GetContext();
            var addedCall = context.Calls.Add(call);
            await context.SaveChangesAsync();

            return addedCall.Entity.Id;
        }

        public async Task<Guid> AddConference(AddConferenceModel conferenceModel)
        {
            var conference = _mapper.Map<Call>(conferenceModel);
            var context = _context.GetContext();
            var addedConference = context.Calls.Add(conference);
            await context.SaveChangesAsync();

            return addedConference.Entity.Id;
        }

        public async Task UpdateCall(CallModel callModel)
        {
            var call = _mapper.Map<Call>(callModel);
            var context = _context.GetContext();
            context.Update(call);

            await context.SaveChangesAsync();
        }

        public async Task DeleteCall(Guid id)
        {
            var context = _context.GetContext();
            context.Entry(new Call { Id = id, IsDeleted = true })
                .Property(x => x.IsDeleted).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task<CallModel> GetCallById(Guid id)
        {
            var context = _context.GetContext();
            var call = await context.Calls
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<CallModel>(call);
        }

        public async Task<List<CallModel>> GetAllCalls()
        {
            var context = _context.GetContext();
            var calls = await context.Calls
                .Where(x => !x.IsDeleted)
                .Where(x => x.Calltype == CallType.Call)
                .Include(x => x.CallProfile)
                .SelectMany(x => x.CallProfile)
                .ToListAsync();

            return _mapper.Map<List<CallModel>>(calls);
        }

        public async Task<List<CallModel>> GetAllConferences()
        {
            var context = _context.GetContext();
            var calls = await context.Calls
                .Where(x => !x.IsDeleted)
                .Where(x => x.Calltype == CallType.Conference)
                .Include(x => x.CallProfile)
                .SelectMany(x => x.CallProfile)
                .ToListAsync();

            return _mapper.Map<List<CallModel>>(calls);
        }

        public async Task<List<CallModel>> GetAll()
        {
            var context = _context.GetContext();
            var calls = await context.Calls
                .Where(x => !x.IsDeleted)
                .Include(x => x.CallProfile)
                .SelectMany(x => x.CallProfile)
                .ToListAsync();

            return _mapper.Map<List<CallModel>>(calls);
        }

        public async Task<List<CallModel>> GetCallsByPeriodAndPhone(DateTime startDate, DateTime endDate, string phoneNumber)
        {
            var context = _context.GetContext();
            var calls = await context.Calls
                .Where(x => !x.IsDeleted)
                .Include(x => x.CallProfile.Where(y => y.PhoneProfile == phoneNumber))
                .Where(x => x.StartDate >= startDate && x.EndDate <= endDate)
                .ToListAsync();

            return _mapper.Map<List<CallModel>>(calls);
        }
    }
}
