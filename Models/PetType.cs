﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace petOwnerOneStopShop.Models
{
    public class PetType
    {
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }

    }
}
