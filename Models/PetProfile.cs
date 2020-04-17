using System;
using System.Collections.Generic;
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
        public bool?  isMale { get; set; }
        public bool? isAdopted { get; set; }
        [ForeignKey("PetType")]
        public int? PetTypeId { get; set; }
        public PetType PetType { get; set; }
        [ForeignKey("PetOwner")]
        public int? PetOwnerId { get; set; }
        public PetOwner PetOwner { get; set; }
    }
}
