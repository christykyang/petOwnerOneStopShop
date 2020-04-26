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
        [Display(Name = "Services Being Offered")]
        public List<ServiceOffered> ServicesOffered { get; set; }
        [Display(Name = "Pet Business")]
        public PetBusiness PetBusiness { get; set; }
        [Display(Name = "Address")]
        public Address Address { get; set; }
        [Display(Name = "Service")]
        public Service Service { get; set; }
        [Display(Name = "Business Type")]
        public BusinessType BusinessType { get; set; }
        [Display(Name = "Businesses")]
        public List<PetBusiness> PetBusinesses { get; set; }
        [Display(Name = "List of Pet Business Types")]
        public List<BusinessType> BusinessTypes { get; set; }
        [Display(Name = "Addresses")]
        public List<Address> Addresses { get; set; }
        [Display(Name = "Services")]
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
        [Display(Name = "Service Price")]
        public string Cost { get; set; }
        [Display(Name = "Owner")]
        public PetOwner PetOwner { get; set; }
        [Display(Name = "Owners")]
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
