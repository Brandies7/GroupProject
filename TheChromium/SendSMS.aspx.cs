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


namespace TheChromium
{
    public partial class SendSMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string accountSid = ConfigurationManager.AppSettings["SMSAccountIdentification"];
            string authToken = ConfigurationManager.AppSettings["SMSAccountPassword"];
            string fromNumber = ConfigurationManager.AppSettings["SMSAccountFrom"];

            TwilioRestClient client = new TwilioRestClient(accountSid, authToken);
            //client.SendSmsMessage(fromNumber, ToNumber.Text, Message.Text);
        }
    }
}