using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheChromium.Models
{
    public class MembershipStatus
    {
        public int id { get; set; }

        public string CurrentStats { get; set; }
    }
}