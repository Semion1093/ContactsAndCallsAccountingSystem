using ContactsAndCallsAccountingSystem.BLL.Models;

namespace ContactsAndCallsAccountingSystem.BLL.Interfaces
{
    public interface IProfileService
    {
        Task AddProfile(ProfileModel profileModel);
        Task DeleteProfile(string phoneNumber);
        Task<List<ProfileModel>> GetAllProfiles();
        Task UpdateProfile(ProfileModel profileModel);
    }
}