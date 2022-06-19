using AutoMapper;
using ContactsAndCallsAccountingSystem.BLL;
using ContactsAndCallsAccountingSystem.BLL.Models;
using ContactsAndCallsAccountingSystem.DAL.Entities;

namespace ContactsAndCallsAccountingSystem.AutoMapperConfiguration
{
    public class AddCallModelToCall : ITypeConverter<AddCallModel, Call>
    {
        public Call Convert(AddCallModel source, Call destination, ResolutionContext context)
        {
            return new Call
            {
                StartDate = source.StartDate,
                EndDate = source.EndDate,
                Calltype = CallType.Call,

                CallProfile = new List<CallProfile>
                {
                    new CallProfile
                    {
                        Billing = source.BillingFirst,
                        PhoneProfile = source.PhoneNumberFirst,
                    },
                    new CallProfile
                    {
                        Billing = source.BillingSecond,
                        PhoneProfile = source.PhoneNumberSecond,
                    },
                }
            };
        }
    }
}