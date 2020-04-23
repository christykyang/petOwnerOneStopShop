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
        public bool IsFollowing { get; set; }
        [ForeignKey("PetOwner")]
        [Display(Name = "Pet Owner")]
        public int? PetOwnerId { get; set; }
        public PetOwner PetOwner { get; set; }
        [ForeignKey("PetBusiness")]
        [Display(Name = "Pet-Friendly Business")]
        public int? PetBusinessId { get; set; }
        public PetBusiness PetBusiness { get; set; }
    }
}
