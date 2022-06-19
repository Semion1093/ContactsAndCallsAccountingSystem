using ContactsAndCallsAccountingSystem.BLL.Models;
using ContactsAndCallsAccountingSystem.DAL.Entities;

namespace ContactsAndCallsAccountingSystem.AutoMapperConfiguration
{
    public class DALMapper : AutoMapper.Profile
    {
        public DALMapper()
        {
            CreateMap<AddCallModel, Call>().ConvertUsing<AddCallModelToCall>();
            CreateMap<AddConferenceModel, Call>().ConvertUsing<AddConferenceModelToCall>();

            CreateMap<CallModel, Call>();
            CreateMap<Call, CallModel>();
            CreateMap<Profile, ProfileModel>().ReverseMap();
            CreateMap<CallProfile, CallModel>();
        }
    }
}
