using AutoMapper;
using ContactsAndCallsAccountingSystem.BLL.Interfaces;
using ContactsAndCallsAccountingSystem.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Profile = ContactsAndCallsAccountingSystem.DAL.Entities.Profile;

namespace ContactsAndCallsAccountingSystem.DAL.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IContextFactory _context;
        private readonly IMapper _mapper;

        public ProfileRepository(IContextFactory context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddProfile(ProfileModel profileModel)
        {
            var profile = _mapper.Map<Profile>(profileModel);
            var context = _context.GetContext();
            context.Profiles.Add(profile);
            await context.SaveChangesAsync();
        }

        public async Task UpdateProfile(ProfileModel profileModel)
        {
            var profile = _mapper.Map<Profile>(profileModel);
            var context = _context.GetContext();
            context.Update(profile);

            await context.SaveChangesAsync();
        }

        public async Task DeleteProfile(string phoneNumber)
        {
            var context = _context.GetContext();
            context.Entry(new Profile { PhoneNumber = phoneNumber, IsDeleted = true })
                .Property(x => x.IsDeleted).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task<ProfileModel> GetProfileByPhoneNumber(string phoneNumber)
        {
            var context = _context.GetContext();
            var profile = await context.Profiles
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

            return _mapper.Map<ProfileModel>(profile);
        }

        public async Task<List<ProfileModel>> GetAllProfiles()
        {
            var context = _context.GetContext();
            var profiles = await context.Profiles
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            return _mapper.Map<List<ProfileModel>>(profiles);
        }
    }
}
