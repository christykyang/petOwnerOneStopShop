using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static PawentsOneStopShop.Models.PetOwner;

namespace PawentsOneStopShop.Models
{
    public class PetProfile
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Gender")]
        public bool? IsMale { get; set; }
        [Display(Name = "Adoption Status")]
        public bool? IsAdopted { get; set; }
        [ForeignKey("PetType")]
        [Display(Name = "Type of Pet")]
        public int? PetTypeId { get; set; }
        public PetType PetType { get; set; }
        [ForeignKey("PetOwner")]
        [Display(Name = "Pet Owner")]
        public int? PetOwnerId { get; set; }
        public PetOwner PetOwner { get; set; }
        [Display(Name = "Picture")]
        public string? ProfilePicture { get; set; }
    }
}
