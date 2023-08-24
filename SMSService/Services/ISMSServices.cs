using Twilio.Rest.Api.V2010.Account;

namespace SMSService.Services
{
    public interface ISMSServices
    {
         Task<MessageResource>  SendSMS(string mobileNumber, string body);
    }
}
