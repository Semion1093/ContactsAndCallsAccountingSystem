using ContactsAndCallsAccountingSystem.BLL.Interfaces;
using ContactsAndCallsAccountingSystem.BLL.Services;
using ContactsAndCallsAccountingSystem.DAL.Repositories;

namespace ContactsAndCallsAccountingSystem.API
{
    public static class ServiceProviderExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICallService, CallService>();
            services.AddScoped<IProfileService, ProfileService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICallRepository, CallRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
        }
    }
}
