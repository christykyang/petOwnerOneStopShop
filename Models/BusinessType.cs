using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PawentsOneStopShop.Models
{
    public class BusinessType
    {
        public int Id { get; set; }
        [Display(Name = "Type of Business")]
        public string TypeOfBusiness { get; set; }
    }
}
