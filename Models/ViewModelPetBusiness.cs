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
        public List<Address> Addresses { get; set; }
        [Display(Name = "Identity User")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [Display(Name = "Type of Business")]
        public int? BusinessTypeId { get; set; }
        public BusinessType BusinessType { get; set; }
        public List<BusinessType> BusinessTypes { get; set; }
        [Display(Name = "Pet Business")]
        public int PetBusinessId { get; set; }
        public PetBusiness PetBusiness { get; set; }
        public List<PetBusiness> PetBusinesses { get; set; }
        public Follow Follow { get; set; }
        public int? FollowId { get; set; }
        [Display(Name = "Follow Status")]
        public bool IsFollowing { get; set; }
        public int PetOwnerId { get; set; }
        public PetOwner PetOwner { get; set; }
        [Display(Name = "Service")]
        public int? ServiceId { get; set; }
        public Service Service { get; set; }
        public List<Service> Services { get; set; }
        public int? ServiceOffered { get; set; }
        public List<ServiceOffered> ServicesOffered { get; set; }

    }
}
