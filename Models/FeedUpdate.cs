using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PawentsOneStopShop.Models
{
    public class FeedUpdate
    {
        public int Id { get; set; }
        [Display(Name = "entry Message")]
        public string Description { get; set; }
        [Display(Name = "Date Published")]
        public string PubDate { get; set; }
        [ForeignKey("Pet Business")]
        public int? PetBusinessId { get; set; }
        public PetBusiness PetBusiness { get; set; }
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }
    }
}
