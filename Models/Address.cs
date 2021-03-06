﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PawentsOneStopShop.Models
{
    public class Address
    {
		public int Id { get; set; }
		[Required]
		[Display(Name = "Street Address")]
		public string StreetAddress { get; set; }
		[Required]
		[Display(Name = "City")]
		public string City { get; set; }
		[Required]
		[Display(Name = "State")]
		public string State { get; set; }
		[Required]
		[Display(Name = "Zipcode")]
		public string ZipCode { get; set; }
		public double Lat { get; set; }
		public double Lng { get; set; }
	}
}
