using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheChromium.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
    }
}