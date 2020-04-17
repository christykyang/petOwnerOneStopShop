using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace petOwnerOneStopShop.Models
{
    public class PetOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("IdentityUser")]
        [Display(Name = "IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser identityUser { get; set; }
    }
}
