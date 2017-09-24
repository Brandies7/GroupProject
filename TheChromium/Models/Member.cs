using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheChromium.Models
{
    public class Member
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [ForeignKey("MembershipId")]
        public string Memberid { get; set; }

        [Display(Name = "Membership Type")]
        public IdentityRole MembershipId { get; set; }


        [ForeignKey("MemberStatus")]
        public int StatusId { get; set; }

        [Display(Name = "Subscription Status")]
        public MembershipStatus MemberStatus { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Driver's License ID")]
        public string DriverID { get; set; }


        public IEnumerable<IdentityRole> MemberType { get; set; }

        public IEnumerable<MembershipStatus> StatusOptions { get; set; }
    }
}