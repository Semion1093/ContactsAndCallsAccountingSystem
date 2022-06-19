using ContactsAndCallsAccountingSystem.BLL.Exceptions;
using ContactsAndCallsAccountingSystem.BLL.Interfaces;
using ContactsAndCallsAccountingSystem.BLL.Models;

namespace ContactsAndCallsAccountingSystem.BLL.Services
{
    public class ProfileService : IProfileService
    {
        private IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task AddProfile(ProfileModel profileModel)
        {
            var exitingProfile = await _profileRepository.GetProfileByPhoneNumber(profileModel.PhoneNumber);

            if (exitingProfile is not null)
            {
                throw new ConflictException("Профиль с таким номером телефона уже существует");
            }

            await _profileRepository.AddProfile(profileModel);
        }

        public async Task UpdateProfile(ProfileModel profileModel)
        {
            var exitingProfile = await _profileRepository.GetProfileByPhoneNumber(profileModel.PhoneNumber);

            if (exitingProfile is null)
            {
                throw new EntityNotFoundException($"Профиль не был найден");
            }

            await _profileRepository.UpdateProfile(profileModel);
        }

        public async Task DeleteProfile(string phoneNumber)
        {
            var exitingProfile = await _profileRepository.GetProfileByPhoneNumber(phoneNumber);

            if (exitingProfile is null)
            {
                throw new EntityNotFoundException($"Профиль не был найден");
            }

            await _profileRepository.DeleteProfile(phoneNumber);
        }

        public async Task<List<ProfileModel>> GetAllProfiles()
        {
            var profiles = await _profileRepository.GetAllProfiles();

            return profiles;
        }
    }
}
