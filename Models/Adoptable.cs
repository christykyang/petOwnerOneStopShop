using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PawentsOneStopShop.Models
{
    public class Adoptable
    {
        public int Id { get; set; }
        [Display(Name = "Adoption Status")]
        public bool? isAdoptable { get; set; }
        [ForeignKey("PetProfile")]
        [Display(Name = "Pet")]
        public int? PetProfileId { get; set; }
        public PetProfile PetProfile { get; set; }
        [ForeignKey("PetBusiness")]
        [Display(Name = "Pet Business")]
        public int? PetBusinessId { get; set; }
        public PetBusiness PetBusiness { get; set; }
    }
}
