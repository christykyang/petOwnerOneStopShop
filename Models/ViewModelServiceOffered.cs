using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static PawentsOneStopShop.Models.PetOwner;

namespace PawentsOneStopShop.Models
{
    public class ViewModelServiceOffered
    {
        public List<ServiceOffered> ServicesOffered { get; set; }
        public PetBusiness PetBusiness { get; set; }
        public Address Address { get; set; }
        public Service Service { get; set; }
        public BusinessType BusinessType { get; set; }
        public List<PetBusiness> PetBusinesses { get; set; }
        public List<BusinessType> BusinessTypes { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Service> Services { get; set; }
        [Display(Name = "Pet Business")]
        public int PetBusinessId { get; set; }
        [Display(Name = "Business Type")]
        public int BusinessTypeId { get; set; }
        [Display(Name = "Address by Zipcode")]
        public int AddressId { get; set; }
        [Display(Name = "Service")]
        public int ServiceId { get; set; }
        [Display(Name = "Pet Owner")]
        public int PetOwnerId { get; set; }
        public string Cost { get; set; }
        public PetOwner PetOwner { get; set; }
        public List<PetOwner> PetOwners { get; set; }
        [Display(Name = "Pet Profile")]
        public int PetProfileId { get; set; }
        public PetProfile PetProfile { get; set; }
        public List<PetProfile> PetProfiles { get; set; }
        [Display(Name = "Follow")]
        public int FollowId { get; set; }
        public Follow Follow { get; set; }
        public List<Follow> Follows { get; set; }
    }
}
