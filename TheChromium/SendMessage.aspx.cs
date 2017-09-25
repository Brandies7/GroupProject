using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Twilio;
using Twilio.Clients;
using System.Web.Services.Description;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace TheChromium
{
    public class SmsService : System.Web.UI.Page, IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            string accountSid = ConfigurationManager.AppSettings["SMSAccountIdentification"];

            string authToken = ConfigurationManager.AppSettings["SMSAccountPassword"];

            string fromNumber = ConfigurationManager.AppSettings["SMSAccountFrom"];

            // Initialize the Twilio client

            TwilioClient.Init(accountSid, authToken);

            MessageResource result = MessageResource.Create(

                    from: new PhoneNumber(fromNumber),

                    to: new PhoneNumber(message.Destination),

                    body: message.Body);


            return Task.FromResult(0);
        }
    }
}