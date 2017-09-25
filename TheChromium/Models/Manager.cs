using System;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheChromium.Models
{
    public class Manager
    {
        public int Id  { get; set; }

        [Display(Name = "Manager ID")]
        public string ManagerId { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public class SendingEmail
        {

            public static void Main(string[] args)
            {
                Console.WriteLine(SendSimpleMessage().Content.ToString());
            }

            public static IRestResponse SendSimpleMessage()
            {
                RestClient client = new RestClient();
                client.BaseUrl = new Uri("https://api.mailgun.net/v3/sandbox1f745e8795e24fb29f42cd512f9ac382.mailgun.org");
                client.Authenticator =
                       new HttpBasicAuthenticator("api",
                                                  "key-302ef79c84e28163d77e98bcf9fdb1b0");
                RestRequest request = new RestRequest();
                request.AddParameter("domain", "sandbox1f745e8795e24fb29f42cd512f9ac382.mailgun.org");
                request.Resource = "{domain}/messages";
                request.AddParameter("from", "Excited User <mailgun@sandbox1f745e8795e24fb29f42cd512f9ac382.mailgun.org> ");
                request.AddParameter("to", "allmemberslist@sandbox1f745e8795e24fb29f42cd512f9ac382.mailgun.org");
                request.AddParameter("subject", "Hello");
                request.AddParameter("text", "Have You checked out our new event? Head on over to Club Chromium for more under events.");
                request.Method = Method.POST;
                request.AddParameter("html", "<html><p>Put html here.</p></html>");

                return client.Execute(request);
            }
        }
    }
}