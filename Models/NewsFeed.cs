using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using static PawentsOneStopShop.Models.PetOwner;

namespace PawentsOneStopShop.Models
{
    public class NewsFeed
    {
        public int Id { get; set; }
        [ForeignKey("PetOwner")]
        [Display(Name = "Pet Owner")]
        public int? PetOwnerId { get; set; }
        public PetOwner PetOwner { get; set; }
        //[ForeignKey("IdentityUser")]
        //[Display(Name = "IdentityUser")]
        //public string IdentityUserId { get; set; }
        //public IdentityUser IdentityUser { get; set; }
        [ForeignKey("Follow")]
        [Display(Name = "Follow")]
        public int? FollowId { get; set; }
        public Follow Follow { get; set; }
        [ForeignKey("FeedUpdate")]
        [Display(Name = "Update Entry")]
        public int? FeedUpdateId { get; set; }
        public FeedUpdate FeedUpdate { get; set; }
    }
}
