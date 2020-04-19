using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace petOwnerOneStopShop.Models
{
    public class Follow
    {
        public int Id { get; set; }
        public bool? IsFollowing { get; set; }
        [ForeignKey("PetOwner")]
        [Display(Name = "Pet Owner")]
        public int? PetOwnerId { get; set; }
        public PetOwner PetOwner { get; set; }
        [ForeignKey("BusinessType")]
        [Display(Name = "Type of Business")]
        public int? BusinessTypeId { get; set; }
        public BusinessType BusinessType { get; set; }
    }
}
