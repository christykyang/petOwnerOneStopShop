using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace petOwnerOneStopShop.Models
{
    public class ViewModelPetProfiles
    {
        public List<PetProfile> PetProfiles { get; set; }
        public PetProfile PetProfile { get; set; }
        public List<PetType> PetTypes { get; set; }
        public PetType PetType { get; set; }
        public Dictionary<int, string> IsMale { get; set; }
        public Dictionary<int, string> IsAdopted { get; set; }
        public int Age { get; set; }
        [Display(Name = "Pet Owner")]
        public int PetOwnerId { get; set; }
        [Display(Name = "PetType")]
        public int PetTypeId { get; set; }
        [Display(Name = "Gender Specific?")]
        public int GenderSelection { get; set; }
        [Display(Name = "Is Adopted?")]
        public int AdoptionStatus { get; set; }
    }
}
