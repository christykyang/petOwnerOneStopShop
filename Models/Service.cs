﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PawentsOneStopShop.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Display(Name = "Service")]
        public string ServiceName { get; set; }
    }
}
