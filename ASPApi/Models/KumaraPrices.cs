using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASPApi.Models
{
	public class KumaraPrices
	{
		[Key]
		public string Month { get; set; }
		public double? Price { get; set; }
	}
}