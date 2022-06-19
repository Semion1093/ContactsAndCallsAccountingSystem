using AutoMapper;
using ContactsAndCallsAccountingSystem.API.InputModels;
using ContactsAndCallsAccountingSystem.API.OutputModels;
using ContactsAndCallsAccountingSystem.BLL.Models;

namespace ContactsAndCallsAccountingSystem.AutoMapperConfiguration
{
    public class APIMapper : Profile
    {
        public APIMapper()
        {
            CreateMap<ProfileInputModel, ProfileModel>();
            CreateMap<ProfileUpdateModel, ProfileModel>();
            CreateMap<ProfileModel, ProfileOutputModel>();

            CreateMap<CallInputModel, AddCallModel>();
            CreateMap<CallUpdateModel, CallModel>();
            CreateMap<ConferenceInputModel, AddConferenceModel>();
            CreateMap<CallModel, CallOutputModel>();
        }
    }
}
