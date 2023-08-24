using Microsoft.Extensions.Options;
using SMSService.Helpers;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SMSService.Services
{
    public class SMSServices :ISMSServices
    {
        private readonly TwailioSettings _twilio;
        public SMSServices(IOptions<TwailioSettings> twilio) 
        {
            _twilio=twilio.Value; 
        
        }

        public async  Task<MessageResource> SendSMS(string mobileNumber, string body)
        {
            TwilioClient.Init(_twilio.AccountSid, _twilio.AuthToken);
            var res = await MessageResource.CreateAsync(
                    body:body,
                    from: new Twilio.Types.PhoneNumber(_twilio.TwilioPhoneNumber) ,
                    to: new Twilio.Types.PhoneNumber(mobileNumber)
                );
            return res;
        }
    }
}
