using System;
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


    }
}