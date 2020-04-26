using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PawentsOneStopShop.Models
{
    public class FeedUpdate
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PubDate { get; set; }
        [ForeignKey("Pet Business")]
        public int? PetBusinessId { get; set; }
        public PetBusiness PetBusiness { get; set; }
        public string BusinessName { get; set; }
    }
}
