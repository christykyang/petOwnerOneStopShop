using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace petOwnerOneStopShop.Models
{
    public class Adoptable
    {
        public int Id { get; set; }
        public bool? isAdoptable { get; set; }
        [ForeignKey("PetProfile")]
        public int? PetProfileId { get; set; }
        public PetProfile PetProfile { get; set; }
        [ForeignKey("PetBusiness")]
        public int? PetBusinessId { get; set; }
        public PetBusiness PetBusiness { get; set; }
    }
}
