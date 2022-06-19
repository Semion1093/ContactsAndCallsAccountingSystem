using AutoMapper;
using ContactsAndCallsAccountingSystem.BLL;
using ContactsAndCallsAccountingSystem.BLL.Models;
using ContactsAndCallsAccountingSystem.DAL.Entities;

namespace ContactsAndCallsAccountingSystem.AutoMapperConfiguration
{
    public class AddConferenceModelToCall : ITypeConverter<AddConferenceModel, Call>
    {
        public Call Convert(AddConferenceModel source, Call destination, ResolutionContext context)
        {
            return new Call
            {
                StartDate = source.StartDate,
                EndDate = source.EndDate,
                Calltype = CallType.Conference,

                CallProfile = source.CallPhoneModel.Select(x => new CallProfile
                {
                    Billing = x.Billing,
                    PhoneProfile = x.PhoneNumber,
                }
                ).ToList()
            };
        }
    }
}
