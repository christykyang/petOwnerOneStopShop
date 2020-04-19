﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace petOwnerOneStopShop.Models
{
    public class PetBusiness
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        [ForeignKey("IdentityUser")]
        [Display(Name = "Identity User")]
        public string IdentityUserId { get; set; }
        public IdentityUser identityUser { get; set; }
        [ForeignKey("BusinessType")]
        [Display(Name = "Business Type")]
        public int? BusinessTypeId { get; set; }
        public BusinessType BusinessType { get; set; }
    }
}
