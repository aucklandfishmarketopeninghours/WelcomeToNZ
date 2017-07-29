using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASPApi.Models
{
	public class RadiationRates
	{
		[Key]
		public string Month { get; set; }
		public double? AverageRadiation { get; set; }
	}
}