using ContactsAndCallsAccountingSystem.BLL.Interfaces;
using ContactsAndCallsAccountingSystem.BLL.Services;
using ContactsAndCallsAccountingSystem.DAL.Repositories;

namespace ContactsAndCallsAccountingSystem.API
{
    public static class ServiceProviderExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ICallService, CallService>();
            services.AddSingleton<IProfileService, ProfileService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ICallRepository, CallRepository>();
            services.AddSingleton<IProfileRepository, ProfileRepository>();
        }
    }
}
