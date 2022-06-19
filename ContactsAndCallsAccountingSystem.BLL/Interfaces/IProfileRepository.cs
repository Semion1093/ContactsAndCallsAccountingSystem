using ContactsAndCallsAccountingSystem.BLL.Models;

namespace ContactsAndCallsAccountingSystem.BLL.Interfaces
{
    public interface IProfileRepository
    {
        Task AddProfile(ProfileModel profileModel);
        Task DeleteProfile(string phoneNumber);
        Task<List<ProfileModel>> GetAllProfiles();
        Task<ProfileModel> GetProfileByPhoneNumber(string phoneNumber);
        Task UpdateProfile(ProfileModel profileModel);
    }
}