using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheChromium.Models
{
    public class Events
    {   
        [Key]
        public int EventId { get; set; }

        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Display(Name = "Date of Event")]
        public string DateOfEvent { get; set; }

        [Display(Name = "Event Starting Time")]
        public string StartOfEvent { get; set; }

        [Display(Name = "Event Ending Time")]
        public string EndOfEvent { get; set; }

        [Display(Name = "Number of Participants")]
        public int Particpants { get; set; }

        [ForeignKey ("MembershipRequired")]
        public string Memberid { get; set; }

        [Display(Name = "Membership Required: ")]
        public IdentityRole MembershipRequired { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        public IEnumerable<IdentityRole> Memberships { get; set; }
    }
}