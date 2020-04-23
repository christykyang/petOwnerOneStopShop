﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace petOwnerOneStopShop.Models
{
    public class Invite
    {
        public int Id { get; set; }
        public bool? isInvitationAccepted { get; set; }
        [ForeignKey("IdentityUser")]
        [Display(Name = "IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [ForeignKey("Event")]
        [Display(Name = "Event")]
        public int? CalendarEventId { get; set; }
        public CalendarEvent Event { get; set; }
    }
}
