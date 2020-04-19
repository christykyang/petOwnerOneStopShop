using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace petOwnerOneStopShop.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Display(Name = "Service")]
        public string ServiceName { get; set; }
    }
}
