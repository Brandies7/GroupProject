using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Twilio;
using System.Configuration;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.AspNet.Identity;

namespace TheChromium
{
    public partial class SendMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            IdentityMessage message;
            message = new IdentityMessage();
            string accountSid = ConfigurationManager.AppSettings["SMSAccountIdentification"];

            string authToken = ConfigurationManager.AppSettings["SMSAccountPassword"];

            string fromNumber = ConfigurationManager.AppSettings["SMSAccountFrom"];

            TwilioClient.Init(accountSid, authToken);
                
            MessageResource.Create(
                from: new PhoneNumber(fromNumber),
                to: new PhoneNumber(TextBox1.Text),
                body: (TextBox2.Text));
        }
    }
}