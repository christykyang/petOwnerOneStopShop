using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PawentsOneStopShop.Models
{
    public class ViewModelPetBusiness
    {
        [Display(Name = "Busisness Name")]
        public string Name { get; set; }
        [Display(Name = "Address")]
        public Address Address { get; set; }
        public int? AddressId { get; set; }
        [Display(Name = "Identity User")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [Display(Name = "Type of Business")]
        public int? BusinessTypeId { get; set; }
        public BusinessType BusinessType { get; set; }
        public int PetBusinessId { get; set; }
        public PetBusiness PetBusiness { get; set; }
        public Follow Follow { get; set; }
        public int? FollowId { get; set; }
        [Display(Name = "Follow Status")]
        public bool IsFollowing { get; set; }
        public int PetOwnerId { get; set; }
        public PetOwner PetOwner { get; set; }
    }
}
