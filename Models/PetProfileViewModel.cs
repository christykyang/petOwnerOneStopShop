using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace petOwnerOneStopShop.Models
{
    public class PetProfileViewModel
    {
        [Required(ErrorMessage = "Please enter name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter age")]
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please choose gender")]
        public bool IsMale { get; set; }
        public bool IsAdopted { get; set; }
        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
        [ForeignKey("PetOwner")]
        [Display(Name = "Pet Owner")]
        public int? PetOwnerId { get; set; }
        public PetOwner PetOwner { get; set; }
        [ForeignKey("PetType")]
        [Display(Name = "Type of Pet")]
        public int? PetTypeId { get; set; }
        public PetType PetType { get; set; }
    }
}
