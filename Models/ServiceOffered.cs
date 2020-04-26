using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PawentsOneStopShop.Models
{
    public class ServiceOffered
    {
        public int Id { get; set; }
        public string Cost { get; set; }
        [ForeignKey("PetBusiness")]
        public int PetBusinessId { get; set; }
        public PetBusiness PetBusiness { get; set; }
        [ForeignKey("Service")]
        [Display(Name = "Service")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
