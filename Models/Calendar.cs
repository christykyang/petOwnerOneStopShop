using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace petOwnerOneStopShop.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        [ForeignKey("IdentityUser")]
        [Display(Name = "Identity User")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
