using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace petOwnerOneStopShop.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        [ForeignKey("PetBusiness")]
        public int? PetBusinessId { get; set; }
        public PetBusiness PetBusiness { get; set; }
    }
}
