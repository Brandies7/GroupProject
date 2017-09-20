﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheChromium.Models
{
    public class Events
    {
        public Events()
        {
            VIPRequired = "No";
        }
        
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

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Number of Participants")]
        public int Particpants { get; set; }

        [Display(Name = "VIP Required: ")]
        public string VIPRequired { get; set; }

    }
}