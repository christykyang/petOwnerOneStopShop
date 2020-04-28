using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static PawentsOneStopShop.Models.PetOwner;

namespace PawentsOneStopShop.Models
{
    public class ViewModelPetProfile
    {
        [Display(Name = "Pets")]
        public List<PetProfile> PetProfiles { get; set; }
        [Display(Name = "Pet")]
        public PetProfile PetProfile { get; set; }
        public int PetProfileId { get; set; }
        [Display(Name = "List of Pet Types")]
        public List<PetType> PetTypes { get; set; }
        [Display(Name = "Type of Pet")]
        public PetType PetType { get; set; }
        [Required(ErrorMessage = "Please enter age")]
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Pet Owner")]
        public int? PetOwnerId { get; set; }
        [Display(Name = "Pet Owner")]
        public PetOwner PetOwner { get; set; }
        [Required(ErrorMessage = "Please choose type of pet")]
        [Display(Name = "Type of Pet")]
        public int PetTypeId { get; set; }
        [Display(Name = "Gender")]
        public int GenderSelection { get; set; }
        [Display(Name = "Adoption Status")]
        public int AdoptionStatus { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
        [Display(Name = "Gender")]
        public Dictionary<int, string> GenderOptions { get; set; }
        [Display(Name = "Adoption Status")]
        public Dictionary<int, string> Adoption { get; set; }
        [Display(Name = "Gender")]
        public bool IsMale { get; set; }
        [Display(Name = "Adoption Status")]
        public bool IsAdopted { get; set; }
    }
}
