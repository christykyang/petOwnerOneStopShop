using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PawentsOneStopShop.Models
{
    public class ViewModelPetBusiness
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public int? AddressId { get; set; }
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public int? BusinessTypeId { get; set; }
        public BusinessType BusinessType { get; set; }
    }
}
