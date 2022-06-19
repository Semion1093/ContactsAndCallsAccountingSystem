using AutoMapper;
using ContactsAndCallsAccountingSystem.BLL.Interfaces;
using ContactsAndCallsAccountingSystem.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Profile = ContactsAndCallsAccountingSystem.DAL.Entities.Profile;

namespace ContactsAndCallsAccountingSystem.DAL.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private ContactsAndCallsAccountingSystemContext _context;
        private IMapper _mapper;

        public ProfileRepository(ContactsAndCallsAccountingSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddProfile(ProfileModel profileModel)
        {
            var profile = _mapper.Map<Profile>(profileModel);
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfile(ProfileModel profileModel)
        {
            var profile = _mapper.Map<Profile>(profileModel);
            _context.Update(profile);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfile(string phoneNumber)
        {
            _context.Entry(new Profile { PhoneNumber = phoneNumber, IsDeleted = true })
                .Property(x => x.IsDeleted).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task<ProfileModel> GetProfileByPhoneNumber(string phoneNumber)
        {
            var profile = await _context.Profiles
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

            return _mapper.Map<ProfileModel>(profile);
        }

        public async Task<List<ProfileModel>> GetAllProfiles()
        {
            var profiles = await _context.Profiles
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            return _mapper.Map<List<ProfileModel>>(profiles);
        }
    }
}
