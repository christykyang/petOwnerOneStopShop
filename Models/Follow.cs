using System;
using System.Collections.Generic;
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
        public int? PetOwnerId { get; set; }
        public PetOwner PetOwner { get; set; }
        [ForeignKey("BusinessType")]
        public int? BusinessTypeId { get; set; }
        public BusinessType BusinessType { get; set; }
    }
}
