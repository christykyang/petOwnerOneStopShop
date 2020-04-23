using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace petOwnerOneStopShop.Models
{
    public class PetProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool?  IsMale { get; set; }
        public bool? IsAdopted { get; set; }
        [ForeignKey("PetType")]
        [Display(Name = "Type of Pet")]
        public int? PetTypeId { get; set; }
        public PetType PetType { get; set; }
        [ForeignKey("PetOwner")]
        [Display(Name = "Pet Owner")]
        public int? PetOwnerId { get; set; }
        public PetOwner PetOwner { get; set; }
        public string ProfilePicture { get; set; }

    }
}
