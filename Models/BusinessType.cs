using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace petOwnerOneStopShop.Models
{
    public class BusinessType
    {
        public int Id { get; set; }
        [Display(Name = "Type of Business")]
        public string TypeOfBusiness {get; set;}
    }
}
