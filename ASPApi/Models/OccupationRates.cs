using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASPApi.Models
{
	public class OccupationRates
	{
		[Key]
		public string Month { get; set; }
		public double? OccupationRate { get; set; }
	}
}