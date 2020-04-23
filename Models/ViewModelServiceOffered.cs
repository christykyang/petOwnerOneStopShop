using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace petOwnerOneStopShop.Models
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
        public string Cost { get; set; }
    //    [Display(Name = "Resource")]
    //    public int ServiceOfferedId { get; set; }
    //    [Display(Name = "Minimum Cost")]
    //    public string MinCost { get; set; }
    //    [Display(Name = "Maximum Cost")]
    //    public string MaxCost { get; set; }
    }
}
