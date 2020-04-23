using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace petOwnerOneStopShop.Models
{
    public class NewsFeed
    {
        public int Id { get; set; }
        [ForeignKey("PetBusiness")]
        [Display(Name = "Pet-Friendly Business")]
        public int PetBusinessId { get; set; }
        public PetBusiness PetBusiness { get; set; }
        [ForeignKey("IdentityUser")]
        [Display(Name = "IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
